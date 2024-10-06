using E2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Models
{
    public class Locacao
    {
        public Cliente Cliente { get; private set; }
        public IVeiculo Veiculo { get; private set; }
        public int Dias { get; private set; }

        public Locacao(Cliente cliente, IVeiculo veiculo, int dias)
        {
            Cliente = cliente;
            Veiculo = veiculo;
            Dias = dias;
        }
    }
}

