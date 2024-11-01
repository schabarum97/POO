using DiscotecaAPI.Data;
using DiscotecaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiscotecaAPI.Repository
{
    public class BebidaRepository : IBebidaRepository
    {
        private readonly InMemoryDbContext _dbContext;

        public BebidaRepository(InMemoryDbContext dbContext)
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
            _dbContext.Bebidas.Update(bebida);
            _dbContext.SaveChanges();
        }

        public void Remover(Bebida bebida)
        {
            _dbContext.Bebidas.Remove(bebida);
            _dbContext.SaveChanges();
        }
    }
}
