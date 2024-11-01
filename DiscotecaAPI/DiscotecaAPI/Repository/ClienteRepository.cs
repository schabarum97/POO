using DiscotecaAPI.Data;
using DiscotecaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiscotecaAPI.Repositories
{
    public class ClienteRepository
    {
        private readonly InMemoryDbContext _dbContext;

        public ClienteRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cliente ObterPorId(int id)
        {
            return _dbContext.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            return _dbContext.Clientes.ToList();
        }

        public void Adicionar(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void Atualizar(Cliente cliente)
        {
            _dbContext.Clientes.Update(cliente);
            _dbContext.SaveChanges();
        }

        public void Remover(Cliente cliente)
        {
            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();
        }
    }
}
