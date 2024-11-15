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
    // Representa uma entidade Cliente no sistema
    public class Cliente
    {
        // Identificador único do cliente
        public int Id { get; set; }

        // Nome completo do cliente
        public string Nome { get; set; }

        // CPF do cliente (para validação de identidade no Brasil)
        public string CPF { get; set; }

        // Email do cliente
        public string Email { get; set; }
    }
}
