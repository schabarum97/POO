using DiscotecaAPI.Data;
using DiscotecaAPI.DTO;
using DiscotecaAPI.Models;

namespace DiscotecaAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly InMemoryDbContext _dbContext; // Contexto de banco de dados em memória para operações com clientes.

        public ClienteService(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext; // Inicializa o contexto do banco de dados.
        }

        // Método para obter um cliente pelo ID.
        public ClienteDTO ObterPorId(int id)
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(c => c.Id == id);
            return cliente != null ? new ClienteDTO { Id = cliente.Id, Nome = cliente.Nome } : null;
        }

        // Método para listar todos os clientes.
        public IEnumerable<ClienteDTO> ListarTodos()
        {
            return _dbContext.Clientes.Select(c => new ClienteDTO { Id = c.Id, Nome = c.Nome }).ToList();
        }

        // Método para adicionar um novo cliente.
        public void Adicionar(ClienteDTO clienteDto)
        {
            var cliente = new Cliente { Nome = clienteDto.Nome };
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges(); // Salva as alterações no banco de dados.
        }

        // Método para atualizar as informações de um cliente.
        public void Atualizar(int id, ClienteDTO clienteDto)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente != null)
            {
                cliente.Nome = clienteDto.Nome;
                _dbContext.SaveChanges(); // Salva as alterações no banco de dados.
            }
        }

        // Método para remover um cliente.
        public void Remover(int id)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                _dbContext.SaveChanges(); // Salva as alterações no banco de dados.
            }
        }
    }
}
