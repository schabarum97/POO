/*
Design Pattern Utilizado:
DTO Pattern (Data Transfer Object):
Facilita a transferência de dados entre camadas, reduzindo a quantidade de dados desnecessários enviados ou recebidos.
Permite uma abstração entre o modelo de domínio (entidades) e o transporte de dados.
Motivo de Uso:
Evita expor diretamente as entidades do modelo de domínio.
Simplifica o controle sobre quais informações são transferidas, adicionando segurança e flexibilidade.
*/
namespace DiscotecaAPI.DTO
{
    // DTO (Data Transfer Object) para a entidade Bebida
    public class BebidaDTO
    {
        // Identificador único da bebida
        public int Id { get; set; }

        // Nome da bebida
        public string Nome { get; set; }

        // Preço da bebida
        public decimal Preco { get; set; }

        // Quantidade disponível da bebida
        public int Quantidade { get; set; }

        // Tipo da bebida (exemplo: alcoólica ou não alcoólica)
        public string Tipo { get; set; }
    }
}
