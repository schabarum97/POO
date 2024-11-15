using DiscotecaAPI.Models;

namespace DiscotecaAPI.Validators
{
    // Classe responsável pela validação dos dados de Comanda.
    public class ComandaValidator : IComandaValidator
    {
        // Valida a comanda, garantindo que ela não seja nula.
        public void ValidarComanda(Comanda comanda)
        {
            if (comanda == null)  // Se a comanda for nula
            {
                throw new ArgumentNullException(nameof(comanda), "Comanda não pode ser nula.");  // Lança uma exceção informando o erro
            }
            // Adicione mais validações conforme necessário (ex: data, status, etc.)
        }

        // Valida um ProdutoComanda, garantindo que não seja nulo e que o preço seja válido.
        public void ValidarProdutoComanda(ProdutoComanda produtoComanda)
        {
            if (produtoComanda == null)  // Se o ProdutoComanda for nulo
            {
                throw new ArgumentNullException(nameof(produtoComanda), "ProdutoComanda não pode ser nulo.");  // Lança uma exceção informando o erro
            }
            if (produtoComanda.Preco <= 0)  // Se o preço for zero ou negativo
            {
                throw new ArgumentException("Preço do produto deve ser maior que zero.");  // Lança uma exceção informando o erro
            }
        }
    }
}