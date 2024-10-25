using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiscotecaAPI.Models;
using DiscotecaAPI.Services;
using DiscotecaAPI.Data;

namespace DiscotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly InMemoryDbContext _dbContext;

        public ClienteController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
            _clienteService = new ClienteService(_dbContext);
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var clientes = _clienteService.ListarTodos();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cliente = _clienteService.ObterPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Cliente cliente)
        {
            _clienteService.Adicionar(cliente);
            return CreatedAtAction(nameof(ObterPorId), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Cliente cliente)
        {
            var clienteExistente = _clienteService.ObterPorId(id);
            if (clienteExistente == null) return NotFound();

            _clienteService.Atualizar(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var cliente = _clienteService.ObterPorId(id);
            if (cliente == null) return NotFound();

            _clienteService.Remover(id);
            return NoContent();
        }
    }
}
