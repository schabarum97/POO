using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Models
{
    public class Moto : Veiculo
    {
        // Construtor para inicializar uma nova instância da classe Moto com os parâmetros fornecidos
        public Moto(string placa, string modelo, string marca, int ano, double precoDiario, Motor motorMoto)
            : base(placa, modelo, marca, ano, precoDiario) // Chama o construtor da classe base Veiculo
        {
        }

        // Método para frear a moto
        public override void Frear()
        {
            Console.WriteLine("Moto freando");
        }

        // Método para mover a moto
        public override void Mover()
        {
            Console.WriteLine("Moto se movendo");
        }

        // Obtém o identificador único da moto
        public override string GetIdentificadorUnico()
        {
            return $"MOTO-{Placa}";
        }
    }
}
