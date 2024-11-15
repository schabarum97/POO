using DiscotecaAPI.DTO;

namespace DiscotecaAPI.Validate
{
    // Classe responsável pela validação dos dados de Bebida.
    public class BebidaValidator
    {
        // Valida se os dados de uma bebida estão corretos (Nome e Tipo não podem ser nulos ou vazios, Preço deve ser maior que zero).
        public bool Validar(BebidaDTO bebida)
        {
            return !string.IsNullOrEmpty(bebida.Nome) &&  // Verifica se o nome não está vazio
                   !string.IsNullOrEmpty(bebida.Tipo) &&  // Verifica se o tipo não está vazio
                   bebida.Preco > 0;  // Verifica se o preço é maior que zero
        }
    }
}