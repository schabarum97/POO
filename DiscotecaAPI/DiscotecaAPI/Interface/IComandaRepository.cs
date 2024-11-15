using DiscotecaAPI.Models;

/*
Design Pattern:
Repository Pattern: Simplifica e centraliza as operações de persistência de dados para as comandas.
*/

namespace DiscotecaAPI.Repositories
{
    // Interface para manipulação de dados da entidade Comanda
    public interface IComandaRepository
    {
        // Obtém uma comanda específica pelo ID
        Comanda ObterPorId(int id);

        // Lista todas as comandas disponíveis no repositório
        IEnumerable<Comanda> ListarTodas();

        // Cria uma nova comanda no repositório
        void CriarComanda(Comanda comanda);

        // Vincula um cliente a uma comanda específica
        void VincularCliente(int comandaId, Cliente cliente);

        // Adiciona um produto a uma comanda existente
        void AdicionarProduto(int comandaId, ProdutoComanda produtoComanda);

        // Marca a comanda como paga e realiza as alterações necessárias
        void PagarComanda(int comandaId);
    }
}
