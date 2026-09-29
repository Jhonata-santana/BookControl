namespace BookControl.Classes
{
    public class ItemVenda
    {
        public Livro Livro { get; set; }
        public int Quantidade { get; set; }

        public ItemVenda(Livro livro, int quantidade)
        {
            this.Livro = livro;
            this.Quantidade = quantidade;
        }

        public double CalcularSubtotal()
        {
            return Livro.Preco * Quantidade;
        }
    }
}