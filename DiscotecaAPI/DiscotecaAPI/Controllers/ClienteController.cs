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

        public ClienteController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var clientes = await _dbContext.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();

            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPorId), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Cliente clienteDto)
        {
            if (clienteDto == null || id != clienteDto.Id) return BadRequest();

            var clienteExistente = await _dbContext.Clientes.FindAsync(id);
            if (clienteExistente == null) return NotFound();

            // Atualiza os dados do cliente existente
            clienteExistente.Nome = clienteDto.Nome;
            clienteExistente.Email = clienteDto.Email;
            // Adicione outros campos conforme necessário

            _dbContext.Clientes.Update(clienteExistente);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
