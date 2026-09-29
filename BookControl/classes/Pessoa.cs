namespace BookControl.Classes
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public Pessoa(string nome)
        {
            this.Nome = nome;
        }

        public virtual void ExibirDados()
        {
            Console.WriteLine("Nome: " + Nome);
        }
    }
}