/*
Design Pattern Utilizado:
DTO Pattern (Data Transfer Object):
Facilita a transferência de dados entre camadas, reduzindo a quantidade de dados desnecessários enviados ou recebidos.
Permite uma abstração entre o modelo de domínio (entidades) e o transporte de dados.
Motivo de Uso:
Evita expor diretamente as entidades do modelo de domínio.
Simplifica o controle sobre quais informações são transferidas, adicionando segurança e flexibilidade.
*/

using DiscotecaAPI.DTO;

namespace DiscotecaAPI.DTOs
{
    // DTO para representar uma comanda
    public class ComandaDTO
    {
        // Identificador único da comanda
        public int Id { get; set; }

        // Indica se a comanda já foi paga
        public bool Paga { get; set; }

        // Lista de produtos associados à comanda
        public List<ProdutoComandaDTO> Produtos { get; set; }

        // Cliente associado à comanda
        public ClienteDTO Cliente { get; set; }
    }
}
