using DiscotecaAPI.DTO;

/*
Design Pattern:
Service Pattern: Responsável por implementar as regras de negócio e orquestrar as operações entre o controller e o repositório.
*/

public interface IClienteService
{
    // Obtém um cliente específico pelo ID
    ClienteDTO ObterPorId(int id);

    // Lista todos os clientes disponíveis em formato DTO
    IEnumerable<ClienteDTO> ListarTodos();

    // Adiciona um novo cliente aplicando regras de validação
    void Adicionar(ClienteDTO clienteDto);

    // Atualiza informações de um cliente existente com base no ID
    void Atualizar(int id, ClienteDTO clienteDto);

    // Remove um cliente com base no ID
    void Remover(int id);
}
