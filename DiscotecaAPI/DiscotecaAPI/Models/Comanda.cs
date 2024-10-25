using System.Collections.Generic;

namespace DiscotecaAPI.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ProdutoComanda> Produtos { get; set; } = new();
        public bool Paga { get; set; } = false;

        public Comanda(int id)
        {
            Id = id;
        }

        // Método para adicionar produto à comanda
        public void AdicionarProduto(ProdutoComanda produto)
        {
            Produtos.Add(produto);
        }

        // Método para calcular o total da comanda
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var produto in Produtos)
            {
                total += produto.CalcularValor();
            }
            return total;
        }

        // Método para marcar a comanda como paga
        public void Pagar()
        {
            Paga = true;
        }
    }
}
