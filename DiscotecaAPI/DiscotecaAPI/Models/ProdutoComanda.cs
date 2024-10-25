using DiscotecaAPI.Models;

public class ProdutoComanda
{
    public int Id { get; set; }
    public int Quantidade { get; set; }
    public Bebida Bebida { get; set; }

    public ProdutoComanda() { }

    public ProdutoComanda(Bebida bebida, int quantidade)
    {
        Bebida = bebida;
        Quantidade = quantidade;
    }

    // Método CalcularValor que multiplica o preço pela quantidade
    public decimal CalcularValor()
    {
        return Bebida.Preco * Quantidade;
    }
}
