using DiscotecaAPI.DTO;

namespace DiscotecaAPI.DTOs
{
    public class ComandaDTO
    {
        public int Id { get; set; }
        public bool Paga { get; set; }
        public List<ProdutoComandaDTO> Produtos { get; set; }
        public ClienteDTO Cliente { get; set; }
    }
}
