using DiscotecaAPI.Models;

namespace DiscotecaAPI.Repositories
{
    public interface IComandaRepository
    {
        Comanda ObterPorId(int id);
        IEnumerable<Comanda> ListarTodas();
        void CriarComanda(Comanda comanda);
        void VincularCliente(int comandaId, Cliente cliente);
        void AdicionarProduto(int comandaId, ProdutoComanda produtoComanda);
        void PagarComanda(int comandaId);
    }
}
