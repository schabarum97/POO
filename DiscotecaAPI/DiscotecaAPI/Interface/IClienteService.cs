using DiscotecaAPI.DTO;

public interface IClienteService
{
    ClienteDTO ObterPorId(int id);
    IEnumerable<ClienteDTO> ListarTodos();
    void Adicionar(ClienteDTO clienteDto);
    void Atualizar(int id, ClienteDTO clienteDto);
    void Remover(int id);
}
