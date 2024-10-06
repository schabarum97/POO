using E2.Models;
using System.Numerics;

public class Moto : Veiculo
{
    /*Classes herdam a implementação básica da classe abstrata e das interfaces, simplificando seu design.*/
    public Motor Motor { get; private set; }

    // Construtor de Moto que passa os parâmetros ao construtor da classe base Veiculo
    public Moto(string placa, string modelo, string marca, int ano, double precoDiaria, Motor motorVeiculo)
        : base(placa, modelo, marca, ano, precoDiaria) // Passando os argumentos necessários para Veiculo
    {
        Motor = motorVeiculo; // Parâmetro específico de Moto
    }

    public override void Frear()
    {
        Console.WriteLine("Moto freando");
    }

    public override void Mover()
    {
        Console.WriteLine("Moto se movendo");
    }

    public override string GetIdentificadorUnico()
    {
        return $"MOTO-{Placa}";
    }
}