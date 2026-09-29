namespace BookControl.Classes
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemVenda> Itens { get; set; }

        public Venda(int id, Cliente cliente)
        {
            this.Id = id;
            this.Cliente = cliente;
            this.Itens = new List<ItemVenda>();
        }

        public void AdicionarItem(ItemVenda item)
        {
            Itens.Add(item);
        }

        public double CalcularTotal()
        {
            double total = 0;

            foreach (ItemVenda item in Itens)
            {
                total += item.CalcularSubtotal();
            }

            return total;
        }

        public void ExibirVenda()
        {
            Console.WriteLine("\n===== VENDA =====");
            Console.WriteLine("Venda: " + Id);
            Console.WriteLine("Cliente: " + Cliente.Nome);

            foreach (ItemVenda item in Itens)
            {
                Console.WriteLine(
                    $"{item.Livro.Nome} - " +
                    $"{item.Quantidade} unidade(s) - " +
                    $"R$ {item.CalcularSubtotal():F2}"
                );
            }

            Console.WriteLine($"Total: R$ {CalcularTotal():F2}");
        }
    }
}