using DiscotecaAPI.DTO;
using System.Collections.Generic;

/*
Design Pattern:
Service Pattern: Responsável por implementar as regras de negócio e orquestrar as operações entre o controller e o repositório.
*/

namespace DiscotecaAPI.Service
{
    // Interface para a lógica de negócios relacionada à entidade Bebida
    public interface IBebidaService
    {
        // Obtém uma bebida pelo ID e converte para DTO para maior flexibilidade
        BebidaDTO ObterPorId(int id);

        // Retorna uma lista de todas as bebidas em formato DTO
        IEnumerable<BebidaDTO> ListarTodas();

        // Adiciona uma nova bebida com regras de validação e retorno de sucesso/erro
        bool Adicionar(BebidaDTO bebidaDto);

        // Atualiza informações de uma bebida existente, aplicando validações
        bool Atualizar(BebidaDTO bebidaDto);

        // Remove uma bebida pelo ID e retorna sucesso/erro
        bool Remover(int id);
    }
}
