using DiscotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscotecaAPI.Data
{
    // Classe que define o contexto do banco de dados em memória utilizando o Entity Framework Core.
    public class InMemoryDbContext : DbContext
    {
        // Definição das tabelas que serão manipuladas no banco de dados
        public DbSet<Bebida> Bebidas { get; set; }  // Representa a tabela 'Bebidas'
        public DbSet<Cliente> Clientes { get; set; }  // Representa a tabela 'Clientes'
        public DbSet<Comanda> Comandas { get; set; }  // Representa a tabela 'Comandas'

        // Construtor que passa as opções do contexto (geralmente usadas para configurar a conexão com o banco de dados).
        // A sobrecarga do construtor permite que a configuração do contexto seja feita externamente (injeção de dependência).
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options)
        {
        }
    }
}