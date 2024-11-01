using DiscotecaAPI.DTOs;
using DiscotecaAPI.Models;
using DiscotecaAPI.Repositories;
using DiscotecaAPI.Validators;

namespace DiscotecaAPI.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository _comandaRepository;
        private readonly IComandaValidator _comandaValidator;

        public ComandaService(IComandaRepository comandaRepository, IComandaValidator comandaValidator)
        {
            _comandaRepository = comandaRepository;
            _comandaValidator = comandaValidator;
        }

        public Comanda ObterPorId(int id)
        {
            return _comandaRepository.ObterPorId(id);
        }

        public IEnumerable<Comanda> ListarTodas()
        {
            return _comandaRepository.ListarTodas();
        }

        public void CriarComanda(Comanda comanda)
        {
            _comandaValidator.ValidarComanda(comanda);
            _comandaRepository.CriarComanda(comanda);
        }

        public void VincularCliente(int comandaId, Cliente cliente)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null && cliente != null)
            {
                _comandaRepository.VincularCliente(comandaId, cliente);
            }
        }

        public void AdicionarProduto(int comandaId, ProdutoComanda produtoComanda)
        {
            _comandaValidator.ValidarProdutoComanda(produtoComanda);
            _comandaRepository.AdicionarProduto(comandaId, produtoComanda);
        }

        public decimal CalcularTotal(int comandaId)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null)
            {
                return comanda.Produtos.Sum(p => p.CalcularValor());
            }

            return 0;
        }

        public void PagarComanda(int comandaId)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null)
            {
                _comandaRepository.PagarComanda(comandaId);
            }
        }

        public void CriarComanda(ComandaDTO comanda)
        {
            throw new NotImplementedException();
        }
    }
}
