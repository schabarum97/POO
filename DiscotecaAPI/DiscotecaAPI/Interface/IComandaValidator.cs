using DiscotecaAPI.Models;

/*
Design Pattern:
Validation Pattern: Segue o princípio de validação para separar as regras de validação em uma camada dedicada.
*/

namespace DiscotecaAPI.Validators
{
    // Interface para validações relacionadas às comandas
    public interface IComandaValidator
    {
        // Valida se a comanda possui informações consistentes
        void ValidarComanda(Comanda comanda);

        // Valida os dados do produto associado a uma comanda
        void ValidarProdutoComanda(ProdutoComanda produtoComanda);
    }
}
