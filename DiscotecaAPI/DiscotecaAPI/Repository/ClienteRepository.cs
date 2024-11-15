using DiscotecaAPI.Data;
using DiscotecaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiscotecaAPI.Repositories
{
    // Classe responsável pela manipulação de dados da entidade Cliente no repositório
    public class ClienteRepository
    {
        private readonly InMemoryDbContext _dbContext;

        // Construtor que injeta o contexto do banco de dados
        public ClienteRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtém um cliente pelo seu ID
        public Cliente ObterPorId(int id)
        {
            return _dbContext.Clientes.FirstOrDefault(c => c.Id == id);
        }

        // Lista todos os clientes
        public IEnumerable<Cliente> ListarTodos()
        {
            return _dbContext.Clientes.ToList();
        }

        // Adiciona um novo cliente ao banco de dados
        public void Adicionar(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

        // Atualiza as informações de um cliente existente no banco de dados
        public void Atualizar(Cliente cliente)
        {
            _dbContext.Clientes.Update(cliente);
            _dbContext.SaveChanges();
        }

        // Remove um cliente do banco de dados
        public void Remover(Cliente cliente)
        {
            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();
        }
    }
}