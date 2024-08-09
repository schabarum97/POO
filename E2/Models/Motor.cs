using E2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Models
{
    public class Motor : IInerciavel
    {
        private bool _estado; // Campo privado para armazenar o estado do motor

        // Método para ligar o motor
        public void Ligar()
        {
            _estado = true;
            Console.WriteLine("Motor ligado");
        }

        // Método para desligar o motor
        public void Desligar()
        {
            _estado = false;
            Console.WriteLine("Motor desligado");
        }

        // Propriedade para obter o estado atual do motor (ligado ou desligado)
        public bool Estado
        {
            get { return _estado; }
        }
    }
}
