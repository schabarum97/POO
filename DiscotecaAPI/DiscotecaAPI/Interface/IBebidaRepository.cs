using DiscotecaAPI.Models;
using System.Collections.Generic;

/*
Design Pattern:
Repository Pattern: Utilizado aqui para encapsular a lógica de acesso a dados, permitindo uma camada intermediária entre a aplicação e o banco de dados.
*/

namespace DiscotecaAPI.Repository
{
    // Interface para manipulação de dados da entidade Bebida
    public interface IBebidaRepository
    {
        // Retorna uma bebida específica com base no ID
        Bebida ObterPorId(int id);

        // Lista todas as bebidas disponíveis no repositório
        IEnumerable<Bebida> ListarTodas();

        // Adiciona uma nova bebida ao repositório
        void Adicionar(Bebida bebida);

        // Atualiza as informações de uma bebida existente
        void Atualizar(Bebida bebida);

        // Remove uma bebida do repositório
        void Remover(Bebida bebida);
    }
}
