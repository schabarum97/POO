﻿using E2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Models
{
    // Classe que herda as propriedades do veiculo
    public class Carro : Veiculo
    {
        private IInerciavel _motor;

        // Construtor atualizado com todos os parâmetros necessários
        public Carro(string placa, string modelo, string marca, int ano, double precoDiario, IInerciavel motor)
            : base(placa, modelo, marca, ano, precoDiario) // Chama o construtor da classe base
        {
            _motor = motor;
        }

        // Método para frear o carro
        public override void Frear()
        {
            Console.WriteLine("Carro freando");
        }

        // Método para mover o carro
        public override void Mover()
        {
            Console.WriteLine("Carro se movendo");
        }

        // Obtém o identificador único do carro
        public override string GetIdentificadorUnico()
        {
            return $"CAR-{Placa}";
        }

        // Liga o carro
        public void Ligar()
        {
            _motor.Ligar();
            Console.WriteLine("Carro ligado");
        }

        // Desliga o carro
        public void Desligar()
        {
            _motor.Desligar();
            Console.WriteLine("Carro desligado");
        }
    }
}
