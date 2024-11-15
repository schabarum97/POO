/*
Design Pattern Utilizado:
DTO Pattern (Data Transfer Object):
Facilita a transferência de dados entre camadas, reduzindo a quantidade de dados desnecessários enviados ou recebidos.
Permite uma abstração entre o modelo de domínio (entidades) e o transporte de dados.
Motivo de Uso:
Evita expor diretamente as entidades do modelo de domínio.
Simplifica o controle sobre quais informações são transferidas, adicionando segurança e flexibilidade.
*/

namespace DiscotecaAPI.DTOs
{
    // DTO para representar um produto dentro de uma comanda
    public class ProdutoComandaDTO
    {
        // Identificador único do produto
        public int Id { get; set; }

        // Preço do produto
        public decimal Preco { get; set; }

        // Quantidade do produto na comanda
        public int Quantidade { get; set; }

        // Calcula o valor total do produto com base no preço e quantidade
        public decimal CalcularValor()
        {
            return Preco * Quantidade; // Aplica a fórmula de valor total (Preço x Quantidade)
        }
    }
}
