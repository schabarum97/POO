using DiscotecaAPI.DTO;

namespace DiscotecaAPI.Validate
{
    public class BebidaValidator
    {
        public bool Validar(BebidaDTO bebida)
        {
            return !string.IsNullOrEmpty(bebida.Nome) &&
                   !string.IsNullOrEmpty(bebida.Tipo) &&
                   bebida.Preco > 0;
        }
    }
}
