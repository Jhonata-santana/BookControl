using BookControl.Interfaces;

namespace BookControl.Classes
{
    public class PagamentoDinheiro : IPagamento
    {
        public void RealizarPagamento(double valor)
        {
            Console.WriteLine(
                $"Pagamento em dinheiro realizado: R$ {valor:F2}"
            );
        }
    }
}