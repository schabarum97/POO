using E2.Interfaces;
using E2.Models;
using System.Numerics;

public class Carro : Veiculo
{
    /*Classes herdam a implementação básica da classe abstrata e das interfaces, simplificando seu design.*/
    private readonly IInerciavel _motor;

    public Carro(string placa, string modelo, string marca, int ano, double precoDiaria, IInerciavel motor)
        : base(placa, modelo, marca, ano, precoDiaria)
    {
        _motor = motor;
    }

    public override void Frear()
    {
        Console.WriteLine("Carro freando");
    }

    public override void Mover()
    {
        Console.WriteLine("Carro se movendo");
    }

    public override string GetIdentificadorUnico()
    {
        return $"CAR-{Placa}";
    }

    public void Ligar()
    {
        _motor.Ligar();
        Console.WriteLine("Carro ligado");
    }

    public void Desligar()
    {
        _motor.Desligar();
        Console.WriteLine("Carro desligado");
    }
}