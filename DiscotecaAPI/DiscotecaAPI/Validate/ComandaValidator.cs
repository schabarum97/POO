using DiscotecaAPI.Models;

namespace DiscotecaAPI.Validators
{
    public class ComandaValidator : IComandaValidator
    {
        public void ValidarComanda(Comanda comanda)
        {
            if (comanda == null)
            {
                throw new ArgumentNullException(nameof(comanda), "Comanda não pode ser nula.");
            }
            // Adicione mais validações conforme necessário
        }

        public void ValidarProdutoComanda(ProdutoComanda produtoComanda)
        {
            if (produtoComanda == null)
            {
                throw new ArgumentNullException(nameof(produtoComanda), "ProdutoComanda não pode ser nulo.");
            }
            if (produtoComanda.Preco <= 0)
            {
                throw new ArgumentException("Preço do produto deve ser maior que zero.");
            }
            // Adicione mais validações conforme necessário
        }
    }
}
