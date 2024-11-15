using Microsoft.AspNetCore.Mvc;
using DiscotecaAPI.DTO;
using DiscotecaAPI.Data;
using DiscotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DiscotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly InMemoryDbContext _dbContext;

        // Injeção de dependência para o contexto do banco de dados
        public ClienteController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lista todos os clientes cadastrados.
        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var clientes = await _dbContext.Clientes.ToListAsync(); // Busca assíncrona de clientes
            return Ok(clientes); // Retorna o resultado com status 200
        }

        // Retorna os detalhes de um cliente pelo ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id); // Busca o cliente pelo ID
            if (cliente == null) return NotFound(); // Retorna 404 se o cliente não for encontrado
            return Ok(cliente);
        }

        // Adiciona um novo cliente.
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest(); // Valida se o cliente é nulo

            await _dbContext.Clientes.AddAsync(cliente); // Adiciona o cliente ao banco
            await _dbContext.SaveChangesAsync(); // Salva as mudanças
            return CreatedAtAction(nameof(ObterPorId), new { id = cliente.Id }, cliente); // Retorna 201 com o ID criado
        }

        // Atualiza um cliente existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Cliente clienteDto)
        {
            if (clienteDto == null || id != clienteDto.Id) return BadRequest(); // Valida os dados de entrada

            var clienteExistente = await _dbContext.Clientes.FindAsync(id); // Busca o cliente existente
            if (clienteExistente == null) return NotFound();

            // Atualiza os dados do cliente
            clienteExistente.Nome = clienteDto.Nome;
            clienteExistente.Email = clienteDto.Email;

            _dbContext.Clientes.Update(clienteExistente); // Marca a entidade como atualizada
            await _dbContext.SaveChangesAsync(); // Salva as alterações
            return NoContent(); // Retorna 204 indicando sucesso
        }

        // Remove um cliente pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id); // Busca o cliente pelo ID
            if (cliente == null) return NotFound();

            _dbContext.Clientes.Remove(cliente); // Remove o cliente
            await _dbContext.SaveChangesAsync(); // Salva as mudanças
            return NoContent(); // Retorna 204 indicando sucesso
        }
    }
}
