using System.Text.Json;
using BookControl.Classes;

namespace BookControl.Services
{
    public static class Sistema
    {
        public static List<Cliente> Clientes { get; set; }
            = new List<Cliente>();

        public static List<Livro> Livros { get; set; }
            = new List<Livro>();

        public static List<Venda> Vendas { get; set; }
            = new List<Venda>();

        public static void CadastrarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public static void CadastrarLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        public static Cliente BuscarCliente(string cpf)
        {
            return Clientes.Find(c => c.CPF == cpf);
        }

        public static Livro BuscarLivro(int id)
        {
            return Livros.Find(l => l.Id == id);
        }

        public static void SalvarDados()
        {
            var dados = new
            {
                Clientes,
                Livros
            };

            string json = JsonSerializer.Serialize(
                dados,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            File.WriteAllText("dados.json", json);

            Console.WriteLine("Dados salvos com sucesso!");
        }
    }
}