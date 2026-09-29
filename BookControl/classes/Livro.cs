namespace BookControl.Classes
{
    public class Livro : Produto
    {
        public string Autor { get; set; }

        public Livro(
            int id,
            string nome,
            double preco,
            int estoque,
            string autor)
            : base(id, nome, preco, estoque)
        {
            this.Autor = autor;
        }

        public override void ExibirProduto()
        {
            Console.WriteLine(
                $"ID: {Id} | Livro: {Nome} | Autor: {Autor} | " +
                $"Preço: R$ {Preco:F2} | Estoque: {Estoque}"
            );
        }
    }
}