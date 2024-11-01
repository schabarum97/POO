using System.Collections.Generic;

namespace DiscotecaAPI.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ProdutoComanda> Produtos { get; set; } = new();
        public bool Paga { get; set; } = false;
    }
}
