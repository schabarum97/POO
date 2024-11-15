using DiscotecaAPI.Data;
using DiscotecaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiscotecaAPI.Repository
{
    // Classe responsável pela manipulação de dados da entidade Bebida no repositório
    public class BebidaRepository : IBebidaRepository
    {
        private readonly InMemoryDbContext _dbContext;

        // Construtor que injeta o contexto do banco de dados
        public BebidaRepository(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtém uma bebida pelo seu ID
        public Bebida ObterPorId(int id)
        {
            return _dbContext.Bebidas.FirstOrDefault(b => b.Id == id);
        }

        // Lista todas as bebidas
        public IEnumerable<Bebida> ListarTodas()
        {
            return _dbContext.Bebidas.ToList();
        }

        // Adiciona uma nova bebida ao banco de dados
        public void Adicionar(Bebida bebida)
        {
            _dbContext.Bebidas.Add(bebida);
            _dbContext.SaveChanges();
        }

        // Atualiza as informações de uma bebida existente no banco de dados
        public void Atualizar(Bebida bebida)
        {
            _dbContext.Bebidas.Update(bebida);
            _dbContext.SaveChanges();
        }

        // Remove uma bebida do banco de dados
        public void Remover(Bebida bebida)
        {
            _dbContext.Bebidas.Remove(bebida);
            _dbContext.SaveChanges();
        }
    }
}