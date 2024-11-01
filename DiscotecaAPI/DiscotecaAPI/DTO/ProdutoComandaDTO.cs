namespace DiscotecaAPI.DTOs
{
    public class ProdutoComandaDTO
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public decimal CalcularValor()
        {
            return Preco * Quantidade;
        }
    }
}
