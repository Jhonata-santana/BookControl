using BookControl.Classes;
using BookControl.Services;

namespace BookControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("       BOOKCONTROL");
                Console.WriteLine("   SISTEMA DE LOJA DE LIVROS");
                Console.WriteLine("================================");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("3 - Cadastrar livro");
                Console.WriteLine("4 - Listar livros");
                Console.WriteLine("5 - Realizar venda");
                Console.WriteLine("6 - Salvar dados");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("================================");

                try
                {
                    Console.Write("Digite uma opção: ");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            CadastrarCliente();
                            break;

                        case 2:
                            ListarClientes();
                            break;

                        case 3:
                            CadastrarLivro();
                            break;

                        case 4:
                            ListarLivros();
                            break;

                        case 5:
                            RealizarVenda();
                            break;

                        case 6:
                            Sistema.SalvarDados();
                            break;

                        case 0:
                            Console.WriteLine("Sistema encerrado.");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite apenas números.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        static void CadastrarCliente()
        {
            Console.WriteLine("\n=== CADASTRO DE CLIENTE ===");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(cpf))
            {
                throw new Exception(
                    "Nome e CPF são obrigatórios."
                );
            }

            Cliente cliente =
                new Cliente(nome, cpf, telefone);

            Sistema.CadastrarCliente(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        static void ListarClientes()
        {
            Console.WriteLine("\n=== CLIENTES ===");

            if (Sistema.Clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (Cliente cliente in Sistema.Clientes)
            {
                cliente.ExibirDados();
                Console.WriteLine("------------------------");
            }
        }

        static void CadastrarLivro()
        {
            Console.WriteLine("\n=== CADASTRO DE LIVRO ===");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nome do livro: ");
            string nome = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine());

            Console.Write("Quantidade em estoque: ");
            int estoque = int.Parse(Console.ReadLine());

            if (preco <= 0)
            {
                throw new Exception(
                    "O preço deve ser maior que zero."
                );
            }

            if (estoque < 0)
            {
                throw new Exception(
                    "O estoque não pode ser negativo."
                );
            }

            Livro livro = new Livro(
                id,
                nome,
                preco,
                estoque,
                autor
            );

            Sistema.CadastrarLivro(livro);

            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        static void ListarLivros()
        {
            Console.WriteLine("\n=== LIVROS ===");

            if (Sistema.Livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            foreach (Livro livro in Sistema.Livros)
            {
                livro.ExibirProduto();
            }
        }

        static void RealizarVenda()
        {
            Console.WriteLine("\n=== REALIZAR VENDA ===");

            if (Sistema.Clientes.Count == 0)
            {
                throw new Exception(
                    "É necessário cadastrar um cliente."
                );
            }

            if (Sistema.Livros.Count == 0)
            {
                throw new Exception(
                    "É necessário cadastrar um livro."
                );
            }

            Console.Write("CPF do cliente: ");
            string cpf = Console.ReadLine();

            Cliente cliente = Sistema.BuscarCliente(cpf);

            if (cliente == null)
            {
                throw new Exception(
                    "Cliente não encontrado."
                );
            }

            Console.Write("ID do livro: ");
            int idLivro = int.Parse(Console.ReadLine());

            Livro livro = Sistema.BuscarLivro(idLivro);

            if (livro == null)
            {
                throw new Exception(
                    "Livro não encontrado."
                );
            }

            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            if (quantidade <= 0)
            {
                throw new Exception(
                    "A quantidade deve ser maior que zero."
                );
            }

            if (quantidade > livro.Estoque)
            {
                throw new Exception(
                    "Quantidade maior que o estoque disponível."
                );
            }

            Venda venda = new Venda(
                Sistema.Vendas.Count + 1,
                cliente
            );

            ItemVenda item =
                new ItemVenda(livro, quantidade);

            venda.AdicionarItem(item);

            livro.Estoque -= quantidade;

            Sistema.Vendas.Add(venda);

            venda.ExibirVenda();

            PagamentoDinheiro pagamento =
                new PagamentoDinheiro();

            pagamento.RealizarPagamento(
                venda.CalcularTotal()
            );
        }
    }
}