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
    // DTO para transportar informações do cliente
    public class ClienteDTO
    {
        // Identificador único do cliente
        public int Id { get; set; }

        // Nome do cliente
        public string Nome { get; set; }
    }
}
