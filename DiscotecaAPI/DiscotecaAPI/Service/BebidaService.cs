using DiscotecaAPI.DTO;
using DiscotecaAPI.Models;
using DiscotecaAPI.Repository;
using DiscotecaAPI.Validate;

namespace DiscotecaAPI.Service
{
    public class BebidaService : IBebidaService
    {
        private readonly IBebidaRepository _bebidaRepository;
        private readonly BebidaValidator _bebidaValidator;

        public BebidaService(IBebidaRepository bebidaRepository, BebidaValidator bebidaValidator)
        {
            _bebidaRepository = bebidaRepository;
            _bebidaValidator = bebidaValidator;
        }

        public BebidaDTO ObterPorId(int id)
        {
            var bebida = _bebidaRepository.ObterPorId(id);
            if (bebida == null) return null;

            return new BebidaDTO
            {
                Id = bebida.Id,
                Nome = bebida.Nome,
                Preco = bebida.Preco,
                Tipo = bebida.Tipo
            };
        }

        public IEnumerable<BebidaDTO> ListarTodas()
        {
            return _bebidaRepository.ListarTodas().Select(b => new BebidaDTO
            {
                Id = b.Id,
                Nome = b.Nome,
                Preco = b.Preco,
                Tipo = b.Tipo
            });
        }

        public bool Adicionar(BebidaDTO bebidaDto)
        {
            if (!_bebidaValidator.Validar(bebidaDto)) return false;

            var bebida = new Bebida
            {
                Nome = bebidaDto.Nome,
                Preco = bebidaDto.Preco,
                Tipo = bebidaDto.Tipo
            };

            _bebidaRepository.Adicionar(bebida);
            return true;
        }

        public bool Atualizar(BebidaDTO bebidaDto)
        {
            var bebida = _bebidaRepository.ObterPorId(bebidaDto.Id);
            if (bebida == null || !_bebidaValidator.Validar(bebidaDto)) return false;

            bebida.Nome = bebidaDto.Nome;
            bebida.Preco = bebidaDto.Preco;
            bebida.Tipo = bebidaDto.Tipo;

            _bebidaRepository.Atualizar(bebida);
            return true;
        }

        public bool Remover(int id)
        {
            var bebida = _bebidaRepository.ObterPorId(id);
            if (bebida == null) return false;

            _bebidaRepository.Remover(bebida);
            return true;
        }
    }
}
