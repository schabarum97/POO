using DiscotecaAPI.Data;
using DiscotecaAPI.Models;

namespace DiscotecaAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly InMemoryDbContext _dbContext;

        public ClienteService(InMemoryDbContext dbContext)
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
            var clienteExistente = ObterPorId(cliente.Id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                _dbContext.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var cliente = ObterPorId(id);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                _dbContext.SaveChanges();
            }
        }
    }
}
