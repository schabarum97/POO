using DiscotecaAPI.Models;

namespace DiscotecaAPI.Services
{
    public interface IClienteService
    {
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ListarTodos();
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(int id);
    }
}
