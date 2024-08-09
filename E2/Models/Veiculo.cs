using E2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Models
{
    public abstract class Veiculo : IVeiculo
    {
        protected string _placa; // Campo protegido para armazenar a placa do veículo
        protected string _modelo; // Campo protegido para armazenar o modelo do veículo
        protected string _marca; // Campo protegido para armazenar a marca do veículo
        protected int _ano; // Campo protegido para armazenar o ano de fabricação do veículo
        protected double _precoDiaria; // Campo protegido para armazenar o preço diário de locação do veículo

        // Construtor para inicializar uma nova instância da classe Veiculo com os parâmetros fornecidos
        public Veiculo(string placa, string modelo, string marca, int ano, double precoDiaria)
        {
            _placa = placa;
            _modelo = modelo;
            _marca = marca;
            _ano = ano;
            _precoDiaria = precoDiaria;
        }

        // Métodos abstratos que devem ser implementados pelas classes derivadas
        public abstract string GetIdentificadorUnico();
        public abstract void Frear();
        public abstract void Mover();

        // Propriedade para acessar e modificar a placa do veículo
        public string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }

        // Propriedade para acessar e modificar o modelo do veículo
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        // Propriedade para acessar e modificar a marca do veículo
        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        // Propriedade para acessar e modificar o ano de fabricação do veículo
        public int Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }

        // Propriedade para acessar e modificar o preço diário de locação do veículo
        public double PrecoDiaria
        {
            get { return _precoDiaria; }
            set { _precoDiaria = value; }
        }

        // Método para exibir as informações do veículo
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Modelo: {Modelo}, Marca: {Marca}, Ano: {Ano}, Preço Diária: {PrecoDiaria:C}");
        }

        // Método para calcular o preço total da locação com base no número de dias
        public double CalcularPrecoLocacao(int dias)
        {
            return PrecoDiaria * dias;
        }

        // Método para calcular a idade do veículo com base no ano atual
        public int CalcularIdade()
        {
            return DateTime.Now.Year - Ano;
        }
    }
}
