/*
Design Patterns Utilizados:
Domain Model Pattern:
Os Models representam o núcleo da lógica de negócios do sistema. Cada classe reflete diretamente as entidades do domínio.
Utilizado para encapsular lógica relevante ao domínio, como o método CalcularValor no ProdutoComanda.
Motivo de Uso:
Facilita a separação de responsabilidades, mantendo as regras de negócio isoladas no núcleo do sistema.
Reduz o acoplamento entre camadas, especialmente em sistemas com múltiplos pontos de integração, como APIs.
*/
namespace DiscotecaAPI.Models
{
    // Representa uma entidade Bebida no sistema
    public class Bebida
    {
        // Identificador único da bebida
        public int Id { get; set; }

        // Nome da bebida
        public string Nome { get; set; }

        // Preço da bebida
        public decimal Preco { get; set; }

        // Quantidade disponível em estoque
        public int Quantidade { get; set; }

        // Tipo da bebida (exemplo: alcoólica ou não alcoólica)
        public string Tipo { get; set; }
    }
}
