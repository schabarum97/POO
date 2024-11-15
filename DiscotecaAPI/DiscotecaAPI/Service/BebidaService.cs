using DiscotecaAPI.DTO;
using DiscotecaAPI.Models;
using DiscotecaAPI.Repository;
using DiscotecaAPI.Validate;

namespace DiscotecaAPI.Service
{
    public class BebidaService : IBebidaService
    {
        private readonly IBebidaRepository _bebidaRepository; // Repositório para operações com dados de bebida.
        private readonly BebidaValidator _bebidaValidator; // Validador para garantir que os dados da bebida estão corretos.

        public BebidaService(IBebidaRepository bebidaRepository, BebidaValidator bebidaValidator)
        {
            _bebidaRepository = bebidaRepository; // Inicializa o repositório de bebidas.
            _bebidaValidator = bebidaValidator; // Inicializa o validador de bebidas.
        }

        // Método para obter uma bebida pelo ID.
        public BebidaDTO ObterPorId(int id)
        {
            var bebida = _bebidaRepository.ObterPorId(id);
            if (bebida == null) return null;

            // Converte o modelo de bebida para o DTO (Data Transfer Object) antes de retornar.
            return new BebidaDTO
            {
                Id = bebida.Id,
                Nome = bebida.Nome,
                Preco = bebida.Preco,
                Tipo = bebida.Tipo
            };
        }

        // Método para listar todas as bebidas.
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

        // Método para adicionar uma nova bebida.
        public bool Adicionar(BebidaDTO bebidaDto)
        {
            // Valida a bebida antes de adicionar.
            if (!_bebidaValidator.Validar(bebidaDto)) return false;

            var bebida = new Bebida
            {
                Nome = bebidaDto.Nome,
                Preco = bebidaDto.Preco,
                Tipo = bebidaDto.Tipo
            };

            // Adiciona a bebida no repositório.
            _bebidaRepository.Adicionar(bebida);
            return true;
        }

        // Método para atualizar uma bebida existente.
        public bool Atualizar(BebidaDTO bebidaDto)
        {
            var bebida = _bebidaRepository.ObterPorId(bebidaDto.Id);
            if (bebida == null || !_bebidaValidator.Validar(bebidaDto)) return false;

            bebida.Nome = bebidaDto.Nome;
            bebida.Preco = bebidaDto.Preco;
            bebida.Tipo = bebidaDto.Tipo;

            // Atualiza a bebida no repositório.
            _bebidaRepository.Atualizar(bebida);
            return true;
        }

        // Método para remover uma bebida.
        public bool Remover(int id)
        {
            var bebida = _bebidaRepository.ObterPorId(id);
            if (bebida == null) return false;

            // Remove a bebida do repositório.
            _bebidaRepository.Remover(bebida);
            return true;
        }
    }
}
