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
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public double ValorTotal { get; private set; }

        // Construtor
        public Locacao(Cliente cliente, IVeiculo veiculo, DateTime dataInicio, DateTime dataFim)
        {
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            Veiculo = veiculo ?? throw new ArgumentNullException(nameof(veiculo));
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValorTotal = CalcularValorTotal();
        }

        // Método para calcular o valor total da locação
        public double CalcularValorTotal()
        {
            int dias = (DataFim - DataInicio).Days;
            if (dias <= 0) throw new ArgumentException("A data final deve ser posterior à data inicial.");
            return Veiculo.CalcularPrecoLocacao(dias);
        }

        // Método para exibir informações da locação
        public void ExibirInfo()
        {
            Console.WriteLine($"Cliente: {Cliente.Nome}");
            Console.WriteLine($"Veículo: {Veiculo.Modelo} ({Veiculo.Marca})");
            Console.WriteLine($"Data Início: {DataInicio.ToShortDateString()}");
            Console.WriteLine($"Data Fim: {DataFim.ToShortDateString()}");
            Console.WriteLine($"Valor Total: {ValorTotal:C}");
        }
    }
}
