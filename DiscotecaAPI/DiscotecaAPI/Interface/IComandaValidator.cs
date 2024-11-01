using DiscotecaAPI.Models;

namespace DiscotecaAPI.Validators
{
    public interface IComandaValidator
    {
        void ValidarComanda(Comanda comanda);
        void ValidarProdutoComanda(ProdutoComanda produtoComanda);
    }
}
