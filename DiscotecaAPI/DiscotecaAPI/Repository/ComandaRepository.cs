using DiscotecaAPI.Data;
using DiscotecaAPI.Models;

namespace DiscotecaAPI.Repositories
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly InMemoryDbContext _dbContext;

        public ComandaRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Comanda ObterPorId(int id)
        {
            return _dbContext.Comandas.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Comanda> ListarTodas()
        {
            return _dbContext.Comandas.ToList();
        }

        public void CriarComanda(Comanda comanda)
        {
            _dbContext.Comandas.Add(comanda);
            _dbContext.SaveChanges();
        }

        public void VincularCliente(int comandaId, Cliente cliente)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null && cliente != null)
            {
                comanda.Cliente = cliente;
                _dbContext.SaveChanges();
            }
        }

        public void AdicionarProduto(int comandaId, ProdutoComanda produtoComanda)
        {
            var comanda = ObterPorId(comandaId);
            if (comanda != null)
            {
                comanda.Produtos.Add(produtoComanda);
                _dbContext.SaveChanges();
            }
        }

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
