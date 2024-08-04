using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Interface
{
    public interface IVeiculo
    {
        string GetIdentificadorUnico();
        void Frear();
        void Mover();
        string Placa { get; set; }
        string Modelo { get; set; }
        string Marca { get; set; }
        int Ano { get; set; }
        double PrecoDiaria { get; set; }

        public void ExibirInformacoes();
        public double CalcularPrecoLocacao(int dias);
    }
}
