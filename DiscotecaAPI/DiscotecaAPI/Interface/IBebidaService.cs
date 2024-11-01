using DiscotecaAPI.DTO;
using System.Collections.Generic;

namespace DiscotecaAPI.Service
{
    public interface IBebidaService
    {
        BebidaDTO ObterPorId(int id);
        IEnumerable<BebidaDTO> ListarTodas();
        bool Adicionar(BebidaDTO bebidaDto);
        bool Atualizar(BebidaDTO bebidaDto);
        bool Remover(int id);
    }
}
