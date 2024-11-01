// ClienteValidator.cs
using DiscotecaAPI.Models;
using System;

namespace DiscotecaAPI.Validations
{
    public class ClienteValidator
    {
        public void Validar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                throw new ArgumentException("O nome do cliente não pode ser vazio.");
            }
        }
    }
}
