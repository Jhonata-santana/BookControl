namespace BookControl.Classes
{
    public class Cliente : Pessoa
    {
        public string CPF { get; set; }
        public string Telefone { get; set; }

        public Cliente(string nome, string cpf, string telefone)
            : base(nome)
        {
            this.CPF = cpf;
            this.Telefone = telefone;
        }

        public override void ExibirDados()
        {
            Console.WriteLine("Cliente: " + Nome);
            Console.WriteLine("CPF: " + CPF);
            Console.WriteLine("Telefone: " + Telefone);
        }
    }
}