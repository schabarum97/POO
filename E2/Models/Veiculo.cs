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
        protected string _placa;
        protected string _modelo;
        protected string _marca;
        protected int _ano;
        protected double _precoDiaria;

        public Veiculo(string placa, string modelo, string marca, int ano, double precoDiaria)
        {
            _placa = placa;
            _modelo = modelo;
            _marca = marca;
            _ano = ano;
            _precoDiaria = precoDiaria;
        }

        public abstract string GetIdentificadorUnico();
        public abstract void Frear();
        public abstract void Mover();

        public string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public int Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }

        public double PrecoDiaria
        {
            get { return _precoDiaria; }
            set { _precoDiaria = value; }
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Modelo: {Modelo}, Marca: {Marca}, Ano: {Ano}, Preço Diária: {PrecoDiaria:C}");
        }

        public double CalcularPrecoLocacao(int dias)
        {
            return PrecoDiaria * dias;
        }

        public int CalcularIdade()
        {
            return DateTime.Now.Year - Ano;
        }
    }
}
