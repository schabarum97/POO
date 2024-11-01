using DiscotecaAPI.Data;
using DiscotecaAPI.DTO;
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

        public ClienteDTO ObterPorId(int id)
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(c => c.Id == id);
            return cliente != null ? new ClienteDTO { Id = cliente.Id, Nome = cliente.Nome } : null;
        }

        public IEnumerable<ClienteDTO> ListarTodos()
        {
            return _dbContext.Clientes.Select(c => new ClienteDTO { Id = c.Id, Nome = c.Nome }).ToList();
        }

        public void Adicionar(ClienteDTO clienteDto)
        {
            var cliente = new Cliente { Nome = clienteDto.Nome };
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

        public void Atualizar(int id, ClienteDTO clienteDto)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente != null)
            {
                cliente.Nome = clienteDto.Nome;
                _dbContext.SaveChanges();
            }
        }

        public void Remover(int id)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                _dbContext.SaveChanges();
            }
        }
    }
}
