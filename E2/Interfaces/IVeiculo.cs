using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Interface
{
    public interface IVeiculo
    {
        // Obtém um identificador único do veículo.
        string GetIdentificadorUnico();

        // Método para frear o veículo.
        public void Frear();

        // Método para mover o veículo.
        public void Mover();

        // Propriedade para obter ou definir a placa do veículo.
        string Placa { get; set; }

        // Propriedade para obter ou definir o modelo do veículo.
        string Modelo { get; set; }

        // Propriedade para obter ou definir a marca do veículo.
        string Marca { get; set; }

        // Propriedade para obter ou definir o ano de fabricação do veículo.
        int Ano { get; set; }

        // Propriedade para obter ou definir o preço da diária de locação do veículo.
        double PrecoDiaria { get; set; }

        // Método para exibir as informações do veículo.
        public void ExibirInformacoes();

        // Método para calcular o preço da locação com base no número de dias.
        public double CalcularPrecoLocacao(int dias);
    }
}
