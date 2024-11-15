using DiscotecaAPI.DTOs;
using DiscotecaAPI.Models;
using DiscotecaAPI.Repositories;
using DiscotecaAPI.Validators;

namespace DiscotecaAPI.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository _comandaRepository; // Repositório para operações com comandas.
        private readonly IComandaValidator _comandaValidator; // Validador para garantir que os dados da comanda estão corretos.

        public ComandaService(IComandaRepository comandaRepository, IComandaValidator comandaValidator)
        {
            _comandaRepository = comandaRepository; // Inicializa o repositório de comandas.
            _comandaValidator = comandaValidator; // Inicializa o validador de comandas.
        }

        // Método para obter uma comanda pelo ID.
        public Comanda ObterPorId(int id)
        {
            return _comandaRepository.ObterPorId(id);
        }

        // Método para listar todas as comandas.
        public IEnumerable<Comanda> ListarTodas()
        {
            return _comandaRepository.ListarTodas();
        }

        // Método para criar uma nova comanda.
        public void CriarComanda(Comanda comanda)
        {
            _comandaValidator.ValidarComanda(comanda); // Valida a comanda antes de criar.
            _comandaRepository.CriarComanda(comanda); // Cria a comanda no repositório.
        }

        // Método para vincular um cliente a uma comanda.
        public void VincularCliente(int comandaId, Cliente cliente)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null && cliente != null)
            {
                _comandaRepository.VincularCliente(comandaId, cliente); // Vincula o cliente à comanda no repositório.
            }
        }

        // Método para adicionar um produto à comanda.
        public void AdicionarProduto(int comandaId, ProdutoComanda produtoComanda)
        {
            _comandaValidator.ValidarProdutoComanda(produtoComanda); // Valida o produto antes de adicionar.
            _comandaRepository.AdicionarProduto(comandaId, produtoComanda); // Adiciona o produto na comanda no repositório.
        }

        // Método para calcular o total da comanda.
        public decimal CalcularTotal(int comandaId)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null)
            {
                return comanda.Produtos.Sum(p => p.CalcularValor()); // Calcula o valor total dos produtos da comanda.
            }

            return 0;
        }

        // Método para pagar a comanda.
        public void PagarComanda(int comandaId)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null)
            {
                _comandaRepository.PagarComanda(comandaId); // Marca a comanda como paga no repositório.
            }
        }

        // Método não implementado para criar comanda com DTO.
        public void CriarComanda(ComandaDTO comanda)
        {
            throw new NotImplementedException();
        }
    }
}
