using E2.Interface;
using E2.Interfaces;

namespace E2.Models
{
    /*
     Aqui, seguimos o princípio de Liskov Substitution (LSP), 
     mantendo a classe abstrata para garantir que todas as subclasses implementem os métodos necessários.
     Também aplicando SoC separando as responsabilidades em interfaces.*/
    public abstract class Veiculo : IVeiculo, ILocavel, IInformavel, IControlavel
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public double PrecoDiaria { get; set; }

        protected Veiculo(string placa, string modelo, string marca, int ano, double precoDiaria)
        {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            PrecoDiaria = precoDiaria;
        }

        public abstract void Frear();
        public abstract void Mover();

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Placa: {Placa}, Modelo: {Modelo}, Marca: {Marca}, Ano: {Ano}, Preço: {PrecoDiaria:C}");
        }

        public double CalcularPrecoLocacao(int dias)
        {
            if (dias <= 0) throw new ArgumentException("Número de dias inválido.");
            return dias * PrecoDiaria;
        }

        public abstract string GetIdentificadorUnico();
    }
}
