using Microsoft.AspNetCore.Mvc;
using DiscotecaAPI.Models;
using DiscotecaAPI.Services;
using DiscotecaAPI.Data;
using DiscotecaAPI.Service;

namespace DiscotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidaController : ControllerBase
    {
        private readonly IBebidaService _bebidaService;
        private readonly InMemoryDbContext _dbContext;

        public BebidaController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
            _bebidaService = new BebidaService(_dbContext);
        }

        [HttpGet]
        public IActionResult ListarTodas()
        {
            var bebidas = _bebidaService.ListarTodas();
            return Ok(bebidas);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var bebida = _bebidaService.ObterPorId(id);
            if (bebida == null) return NotFound();
            return Ok(bebida);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Bebida bebida)
        {
            _bebidaService.Adicionar(bebida);
            return CreatedAtAction(nameof(ObterPorId), new { id = bebida.Id }, bebida);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Bebida bebida)
        {
            var bebidaExistente = _bebidaService.ObterPorId(id);
            if (bebidaExistente == null) return NotFound();

            _bebidaService.Atualizar(bebida);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var bebida = _bebidaService.ObterPorId(id);
            if (bebida == null) return NotFound();

            _bebidaService.Remover(id);
            return NoContent();
        }
    }
}
