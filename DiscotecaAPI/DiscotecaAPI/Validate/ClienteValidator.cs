using DiscotecaAPI.Models;
using System;

namespace DiscotecaAPI.Validations
{
    // Classe responsável pela validação dos dados de Cliente.
    public class ClienteValidator
    {
        // Valida o cliente, especificamente se o nome não é vazio ou em branco.
        public void Validar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nome))  // Se o nome for nulo, vazio ou composto apenas por espaços
            {
                throw new ArgumentException("O nome do cliente não pode ser vazio.");  // Lança uma exceção informando o erro
            }
        }
    }
}
