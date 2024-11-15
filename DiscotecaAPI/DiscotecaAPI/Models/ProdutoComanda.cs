/*
Design Patterns Utilizados:
Domain Model Pattern:
Os Models representam o núcleo da lógica de negócios do sistema. Cada classe reflete diretamente as entidades do domínio.
Utilizado para encapsular lógica relevante ao domínio, como o método CalcularValor no ProdutoComanda.
Motivo de Uso:
Facilita a separação de responsabilidades, mantendo as regras de negócio isoladas no núcleo do sistema.
Reduz o acoplamento entre camadas, especialmente em sistemas com múltiplos pontos de integração, como APIs.
*/


// Representa um produto incluído em uma comanda
public class ProdutoComanda
{
    // Identificador único do produto na comanda
    public int Id { get; set; }

    // Nome do produto
    public string Nome { get; set; }

    // Preço unitário do produto
    public decimal Preco { get; set; }

    // Quantidade de unidades do produto na comanda
    public int Quantidade { get; set; }

    // Calcula o valor total do produto na comanda
    public decimal CalcularValor()
    {
        return Preco * Quantidade; // Valor total = Preço unitário x Quantidade
    }
}
