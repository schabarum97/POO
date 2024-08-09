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
        // Propriedade para obter o cliente associado à locação
        public Cliente Cliente { get; private set; }

        // Propriedade para obter o veículo associado à locação
        public IVeiculo Veiculo { get; private set; }

        // Propriedade para obter a data de início da locação
        public DateTime DataInicio { get; private set; }

        // Propriedade para obter a data de término da locação
        public DateTime DataFim { get; private set; }

        // Propriedade para obter o valor total da locação
        public double ValorTotal { get; private set; }

        // Construtor para inicializar uma nova instância da classe Locacao com os parâmetros fornecidos
        public Locacao(Cliente cliente, IVeiculo veiculo, DateTime dataInicio, DateTime dataFim)
        {
            Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente)); // Inicializa o cliente ou lança exceção se for nulo
            Veiculo = veiculo ?? throw new ArgumentNullException(nameof(veiculo)); // Inicializa o veículo ou lança exceção se for nulo
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValorTotal = CalcularValorTotal(); // Calcula o valor total da locação
        }

        // Método para calcular o valor total da locação
        public double CalcularValorTotal()
        {
            int dias = (DataFim - DataInicio).Days; // Calcula o número de dias da locação
            if (dias <= 0) throw new ArgumentException("A data final deve ser posterior à data inicial.");
            return Veiculo.CalcularPrecoLocacao(dias); // Calcula o valor total da locação usando o método do veículo
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
