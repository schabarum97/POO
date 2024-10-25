using DiscotecaAPI.Models;

namespace DiscotecaAPI.Services
{
    public interface IBebidaService
    {
        Bebida ObterPorId(int id);
        IEnumerable<Bebida> ListarTodas();
        void Adicionar(Bebida bebida);
        void Atualizar(Bebida bebida);
        void Remover(int id);
    }
}
