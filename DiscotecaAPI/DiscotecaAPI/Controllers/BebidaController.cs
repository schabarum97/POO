using Microsoft.AspNetCore.Mvc;
using DiscotecaAPI.Models;
using DiscotecaAPI.DTO;
using DiscotecaAPI.Data;

namespace DiscotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidaController : ControllerBase
    {
        private readonly InMemoryDbContext _dbContext;

        public BebidaController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ListarTodas()
        {
            var bebidas = _dbContext.Bebidas.ToList();

            var bebidaDtos = bebidas.Select(b => new BebidaDTO
            {
                Id = b.Id,
                Nome = b.Nome,
                Preco = b.Preco,
                Tipo = b.Tipo
            }).ToList();

            return Ok(bebidaDtos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var bebida = _dbContext.Bebidas.FirstOrDefault(b => b.Id == id);
            if (bebida == null) return NotFound();

            var bebidaDto = new BebidaDTO
            {
                Id = bebida.Id,
                Nome = bebida.Nome,
                Preco = bebida.Preco,
                Tipo = bebida.Tipo
            };

            return Ok(bebidaDto);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] BebidaDTO bebidaDto)
        {
            // Validação básica
            if (string.IsNullOrEmpty(bebidaDto.Nome) || bebidaDto.Preco <= 0)
            {
                return BadRequest("Dados inválidos.");
            }

            var bebida = new Bebida
            {
                Nome = bebidaDto.Nome,
                Preco = bebidaDto.Preco,
                Tipo = bebidaDto.Tipo
            };

            _dbContext.Bebidas.Add(bebida);
            _dbContext.SaveChanges();
            bebidaDto.Id = bebida.Id; // Atribui o ID gerado

            return CreatedAtAction(nameof(ObterPorId), new { id = bebidaDto.Id }, bebidaDto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] BebidaDTO bebidaDto)
        {
            var bebidaExistente = _dbContext.Bebidas.FirstOrDefault(b => b.Id == id);
            if (bebidaExistente == null) return NotFound();

            // Atualiza os campos da bebida existente com os valores do DTO
            bebidaExistente.Nome = bebidaDto.Nome;
            bebidaExistente.Preco = bebidaDto.Preco;
            bebidaExistente.Tipo = bebidaDto.Tipo;

            _dbContext.Bebidas.Update(bebidaExistente);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var bebida = _dbContext.Bebidas.FirstOrDefault(b => b.Id == id);
            if (bebida == null) return NotFound();

            _dbContext.Bebidas.Remove(bebida);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
