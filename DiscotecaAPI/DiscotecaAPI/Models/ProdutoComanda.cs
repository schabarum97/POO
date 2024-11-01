public class ProdutoComanda
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; } // Verifique se esta propriedade existe
    public int Quantidade { get; set; }

    public decimal CalcularValor()
    {
        return Preco * Quantidade;
    }
}
