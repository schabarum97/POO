using DiscotecaAPI.DTOs;
using DiscotecaAPI.Models;

/*
Design Pattern:
Service Pattern: Aqui, além de intermediar a lógica entre controlador e repositório, o serviço implementa uma lógica mais elaborada (como CalcularTotal).
*/

namespace DiscotecaAPI.Services
{
    // Interface para a lógica de negócios da entidade Comanda
    public interface IComandaService
    {
        // Obtém uma comanda pelo ID
        Comanda ObterPorId(int id);

        // Retorna uma lista de todas as comandas em formato DTO
        IEnumerable<Comanda> ListarTodas();

        // Cria uma nova comanda aplicando validações
        void CriarComanda(ComandaDTO comanda);

        // Vincula um cliente a uma comanda existente
        void VincularCliente(int comandaId, Cliente cliente);

        // Adiciona um produto a uma comanda específica
        void AdicionarProduto(int comandaId, ProdutoComanda produtoComanda);

        // Calcula o valor total de uma comanda
        decimal CalcularTotal(int comandaId);

        // Marca a comanda como paga
        void PagarComanda(int comandaId);
    }
}
