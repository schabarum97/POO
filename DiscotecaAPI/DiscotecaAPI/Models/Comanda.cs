/*
Design Patterns Utilizados:
Domain Model Pattern:
Os Models representam o núcleo da lógica de negócios do sistema. Cada classe reflete diretamente as entidades do domínio.
Utilizado para encapsular lógica relevante ao domínio, como o método CalcularValor no ProdutoComanda.
Motivo de Uso:
Facilita a separação de responsabilidades, mantendo as regras de negócio isoladas no núcleo do sistema.
Reduz o acoplamento entre camadas, especialmente em sistemas com múltiplos pontos de integração, como APIs.
*/

using System.Collections.Generic;

namespace DiscotecaAPI.Models
{
    // Representa uma entidade Comanda no sistema
    public class Comanda
    {
        // Identificador único da comanda
        public int Id { get; set; }

        // Cliente associado à comanda
        public Cliente Cliente { get; set; }

        // Lista de produtos adicionados à comanda
        public List<ProdutoComanda> Produtos { get; set; } = new();

        // Indica se a comanda já foi paga
        public bool Paga { get; set; } = false;
    }
}
