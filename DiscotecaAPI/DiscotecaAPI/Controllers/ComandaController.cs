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

        // Injeção de dependência do contexto do banco de dados
        public ComandaController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lista todas as comandas registradas.
        [HttpGet]
        public async Task<IActionResult> ListarTodas()
        {
            var comandas = await _dbContext.Comandas.ToListAsync();
            return Ok(comandas); // Retorna 200 com as comandas
        }

        // Obtém os detalhes de uma comanda pelo ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();
            return Ok(comanda);
        }

        // Cria uma nova comanda.
        [HttpPost]
        public async Task<IActionResult> CriarComanda([FromBody] ComandaDTO comandaDto)
        {
            if (comandaDto == null) return BadRequest(); // Valida o DTO

            var comanda = new Comanda
            {
                // Mapear propriedades do DTO
            };

            await _dbContext.Comandas.AddAsync(comanda);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPorId), new { id = comanda.Id }, comanda);
        }

        // Vincula um cliente a uma comanda.
        [HttpPost("{id}/cliente")]
        public async Task<IActionResult> VincularCliente(int id, [FromBody] Cliente cliente)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();

            comanda.Cliente = cliente;
            _dbContext.Comandas.Update(comanda);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // Adiciona um produto a uma comanda.
        [HttpPost("{id}/produto")]
        public async Task<IActionResult> AdicionarProduto(int id, [FromBody] ProdutoComandaDTO produtoComandaDto)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();

            var produtoComanda = new ProdutoComanda
            {
                // Mapear propriedades do DTO
            };

            comanda.Produtos.Add(produtoComanda);
            _dbContext.Comandas.Update(comanda);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // Marca uma comanda como paga.
        [HttpPut("{id}/pagar")]
        public async Task<IActionResult> PagarComanda(int id)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();

            comanda.Paga = true; // Marca como paga
            _dbContext.Comandas.Update(comanda);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // Calcula o total de uma comanda.
        [HttpGet("{id}/total")]
        public async Task<IActionResult> CalcularTotal(int id)
        {
            var comanda = await _dbContext.Comandas.FindAsync(id);
            if (comanda == null) return NotFound();

            var total = comanda.Produtos.Sum(p => p.Preco); // Soma os preços dos produtos
            return Ok(total);
        }
    }
}
