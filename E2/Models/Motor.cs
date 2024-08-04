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
        private bool _estado;

        public void Ligar()
        {
            _estado = true;
            Console.WriteLine("Motor ligado");
        }

        public void Desligar()
        {
            _estado = false;
            Console.WriteLine("Motor desligado");
        }

        public bool Estado
        {
            get { return _estado; }
        }
    }
}
