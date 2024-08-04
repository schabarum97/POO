using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Models
{
    public class Moto : Veiculo
    {
        public Moto(string placa, string modelo, string marca, int ano, double precoDiario, Motor motorMoto)
            : base(placa, modelo, marca, ano, precoDiario)
        {
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
}
