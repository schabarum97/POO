using Microsoft.AspNetCore.Mvc;
using DiscotecaAPI.Models;
using DiscotecaAPI.Data;
using DiscotecaAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DiscotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComandaController : ControllerBase
    {
        private readonly InMemoryDbContext _dbContext;

        public ComandaController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodas()
        {
            var comandas = await _dbContext.Comandas.ToListAsync();
            return Ok(comandas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();
            return Ok(comanda);
        }

        [HttpPost]
        public async Task<IActionResult> CriarComanda([FromBody] ComandaDTO comandaDto)
        {
            if (comandaDto == null) return BadRequest();

            var comanda = new Comanda
            {
            };

            await _dbContext.Comandas.AddAsync(comanda);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPorId), new { id = comanda.Id }, comanda);
        }

        [HttpPost("{id}/cliente")]
        public async Task<IActionResult> VincularCliente(int id, [FromBody] Cliente cliente)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();

            // Lógica para vincular o cliente à comanda
            comanda.Cliente = cliente;
            _dbContext.Comandas.Update(comanda);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{id}/produto")]
        public async Task<IActionResult> AdicionarProduto(int id, [FromBody] ProdutoComandaDTO produtoComandaDto)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();

            var produtoComanda = new ProdutoComanda
            {
                // Mapear propriedades de ProdutoComandaDTO para ProdutoComanda
                // Exemplo: Id = produtoComandaDto.Id, ...
            };

            comanda.Produtos.Add(produtoComanda); // Supondo que você tenha uma coleção de Produtos na sua Comanda
            _dbContext.Comandas.Update(comanda);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/pagar")]
        public async Task<IActionResult> PagarComanda(int id)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();

            comanda.Paga = true;
            _dbContext.Comandas.Update(comanda);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}/total")]
        public async Task<IActionResult> CalcularTotal(int id)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();

            var total = comanda.Produtos.Sum(p => p.Preco); // Supondo que cada produto tenha uma propriedade Preco
            return Ok(total);
        }
    }
}
