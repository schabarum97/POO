using DiscotecaAPI.Data;
using DiscotecaAPI.Models;
using DiscotecaAPI.Services;

namespace DiscotecaAPI.Service
{
    public class BebidaService : IBebidaService
    {
        private readonly InMemoryDbContext _dbContext;

        public BebidaService(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Bebida ObterPorId(int id)
        {
            return _dbContext.Bebidas.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Bebida> ListarTodas()
        {
            return _dbContext.Bebidas.ToList();
        }

        public void Adicionar(Bebida bebida)
        {
            _dbContext.Bebidas.Add(bebida);
            _dbContext.SaveChanges();
        }

        public void Atualizar(Bebida bebida)
        {
            var bebidaExistente = ObterPorId(bebida.Id);
            if (bebidaExistente != null)
            {
                bebidaExistente.Nome = bebida.Nome;
                bebidaExistente.Preco = bebida.Preco;
                bebidaExistente.Tipo = bebida.Tipo;
                _dbContext.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var bebida = ObterPorId(id);
            if (bebida != null)
            {
                _dbContext.Bebidas.Remove(bebida);
                _dbContext.SaveChanges();
            }
        }
    }
}
