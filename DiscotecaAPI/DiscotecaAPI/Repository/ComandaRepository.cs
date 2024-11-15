using DiscotecaAPI.Data;
using DiscotecaAPI.Models;

namespace DiscotecaAPI.Repositories
{
    // Classe responsável pela manipulação de dados da entidade Comanda no repositório
    public class ComandaRepository : IComandaRepository
    {
        private readonly InMemoryDbContext _dbContext;

        // Construtor que injeta o contexto do banco de dados
        public ComandaRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtém uma comanda pelo seu ID
        public Comanda ObterPorId(int id)
        {
            return _dbContext.Comandas.FirstOrDefault(c => c.Id == id);
        }

        // Lista todas as comandas
        public IEnumerable<Comanda> ListarTodas()
        {
            return _dbContext.Comandas.ToList();
        }

        // Cria uma nova comanda
        public void CriarComanda(Comanda comanda)
        {
            _dbContext.Comandas.Add(comanda);
            _dbContext.SaveChanges();
        }

        // Vincula um cliente a uma comanda
        public void VincularCliente(int comandaId, Cliente cliente)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null && cliente != null)
            {
                comanda.Cliente = cliente;
                _dbContext.SaveChanges();
            }
        }

        // Adiciona um produto à comanda
        public void AdicionarProduto(int comandaId, ProdutoComanda produtoComanda)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null)
            {
                comanda.Produtos.Add(produtoComanda);
                _dbContext.SaveChanges();
            }
        }

        // Marca a comanda como paga
        public void PagarComanda(int comandaId)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null)
            {
                comanda.Paga = true;
                _dbContext.SaveChanges();
            }
        }
    }
}
