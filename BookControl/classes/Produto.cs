namespace BookControl.Classes
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }

        public Produto(int id, string nome, double preco, int estoque)
        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
            this.Estoque = estoque;
        }

        public virtual void ExibirProduto()
        {
            Console.WriteLine(
                $"ID: {Id} | Nome: {Nome} | Preço: R$ {Preco:F2} | Estoque: {Estoque}"
            );
        }
    }
}