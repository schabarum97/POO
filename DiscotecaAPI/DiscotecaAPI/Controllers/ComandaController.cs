using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiscotecaAPI.Models;
using DiscotecaAPI.Services;
using DiscotecaAPI.Data;

namespace DiscotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _comandaService;
        private readonly InMemoryDbContext _dbContext;

        public ComandaController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
            _comandaService = new ComandaService(_dbContext);
        }

        [HttpGet]
        public IActionResult ListarTodas()
        {
            var comandas = _comandaService.ListarTodas();
            return Ok(comandas);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var comanda = _comandaService.ObterPorId(id);
            if (comanda == null) return NotFound();
            return Ok(comanda);
        }

        [HttpPost]
        public IActionResult CriarComanda([FromBody] Comanda comanda)
        {
            _comandaService.CriarComanda(comanda);
            return CreatedAtAction(nameof(ObterPorId), new { id = comanda.Id }, comanda);
        }

        [HttpPost("{id}/cliente")]
        public IActionResult VincularCliente(int id, [FromBody] Cliente cliente)
        {
            var comanda = _comandaService.ObterPorId(id);
            if (comanda == null) return NotFound();

            _comandaService.VincularCliente(id, cliente);
            return NoContent();
        }

        [HttpPost("{id}/produto")]
        public IActionResult AdicionarProduto(int id, [FromBody] ProdutoComanda produtoComanda)
        {
            var comanda = _comandaService.ObterPorId(id);
            if (comanda == null) return NotFound();

            _comandaService.AdicionarProduto(id, produtoComanda);
            return NoContent();
        }

        [HttpGet("{id}/total")]
        public IActionResult CalcularTotal(int id)
        {
            var total = _comandaService.CalcularTotal(id);
            return Ok(total);
        }

        [HttpPost("{id}/pagar")]
        public IActionResult PagarComanda(int id)
        {
            var comanda = _comandaService.ObterPorId(id);
            if (comanda == null) return NotFound();

            _comandaService.PagarComanda(id);
            return NoContent();
        }
    }
}
