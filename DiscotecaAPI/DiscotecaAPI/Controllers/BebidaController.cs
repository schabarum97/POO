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

        // Injeção de dependência do contexto da base de dados
        public BebidaController(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Endpoint para listar todas as bebidas.
        // Este método implementa o padrão "DTO" para retornar apenas os dados necessários ao cliente.
        [HttpGet]
        public IActionResult ListarTodas()
        {
            // Busca as bebidas na base de dados.
            var bebidas = _dbContext.Bebidas.ToList();

            // Converte as entidades do banco para DTOs antes de retornar.
            var bebidaDtos = bebidas.Select(b => new BebidaDTO
            {
                Id = b.Id,
                Nome = b.Nome,
                Preco = b.Preco,
                Tipo = b.Tipo
            }).ToList();

            return Ok(bebidaDtos); // Retorna o resultado com status 200.
        }

        // Endpoint para obter uma bebida específica por ID.
        // Aqui seguimos o padrão "CQRS" separando a leitura da escrita.
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            // Busca a bebida no banco pelo ID fornecido.
            var bebida = _dbContext.Bebidas.FirstOrDefault(b => b.Id == id);
            if (bebida == null) return NotFound(); // Retorna 404 se a bebida não existir.

            // Converte a entidade para um DTO para devolver ao cliente.
            var bebidaDto = new BebidaDTO
            {
                Id = bebida.Id,
                Nome = bebida.Nome,
                Preco = bebida.Preco,
                Tipo = bebida.Tipo
            };

            return Ok(bebidaDto); // Retorna o DTO com status 200.
        }

        // Endpoint para adicionar uma nova bebida.
        // O padrão "DTO" é usado para receber apenas os dados necessários.
        [HttpPost]
        public IActionResult Adicionar([FromBody] BebidaDTO bebidaDto)
        {
            // Validação básica dos dados de entrada.
            if (string.IsNullOrEmpty(bebidaDto.Nome) || bebidaDto.Preco <= 0)
            {
                return BadRequest("Dados inválidos.");
            }

            // Converte o DTO recebido para uma entidade.
            var bebida = new Bebida
            {
                Nome = bebidaDto.Nome,
                Preco = bebidaDto.Preco,
                Tipo = bebidaDto.Tipo
            };

            // Adiciona a nova bebida ao banco de dados.
            _dbContext.Bebidas.Add(bebida);
            _dbContext.SaveChanges();

            // Atualiza o ID no DTO para retornar o dado criado.
            bebidaDto.Id = bebida.Id;

            // Retorna o recurso criado com status 201 e o ID no cabeçalho.
            return CreatedAtAction(nameof(ObterPorId), new { id = bebidaDto.Id }, bebidaDto);
        }

        // Endpoint para atualizar uma bebida existente.
        // Segue o padrão "DTO" para atualizar apenas os campos necessários.
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] BebidaDTO bebidaDto)
        {
            // Verifica se a bebida existe na base.
            var bebidaExistente = _dbContext.Bebidas.FirstOrDefault(b => b.Id == id);
            if (bebidaExistente == null) return NotFound(); // Retorna 404 se não encontrada.

            // Atualiza os dados da entidade com as informações do DTO.
            bebidaExistente.Nome = bebidaDto.Nome;
            bebidaExistente.Preco = bebidaDto.Preco;
            bebidaExistente.Tipo = bebidaDto.Tipo;

            // Salva as alterações no banco de dados.
            _dbContext.Bebidas.Update(bebidaExistente);
            _dbContext.SaveChanges();

            return NoContent(); // Retorna 204 para indicar que a operação foi bem-sucedida.
        }

        // Endpoint para remover uma bebida por ID.
        // Aplica o padrão "Command" para ações de escrita.
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            // Busca a bebida no banco pelo ID fornecido.
            var bebida = _dbContext.Bebidas.FirstOrDefault(b => b.Id == id);
            if (bebida == null) return NotFound(); // Retorna 404 se a bebida não existir.

            // Remove a bebida do banco de dados.
            _dbContext.Bebidas.Remove(bebida);
            _dbContext.SaveChanges();

            return NoContent(); // Retorna 204 para indicar sucesso na exclusão.
        }
    }
}
