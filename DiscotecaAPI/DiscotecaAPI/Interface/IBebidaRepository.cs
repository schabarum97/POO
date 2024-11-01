using DiscotecaAPI.Models;
using System.Collections.Generic;

namespace DiscotecaAPI.Repository
{
    public interface IBebidaRepository
    {
        Bebida ObterPorId(int id);
        IEnumerable<Bebida> ListarTodas();
        void Adicionar(Bebida bebida);
        void Atualizar(Bebida bebida);
        void Remover(Bebida bebida);
    }
}
