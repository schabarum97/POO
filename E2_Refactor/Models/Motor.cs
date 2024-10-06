using E2.Interfaces;

namespace E2.Models
{
    public class Motor : IInerciavel
    {
        /*
         Mantendo a simplicidade e aplicando Clean Code, com nomes claros e redução de redundâncias.*/
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

        public bool Estado => _estado;
    }
}
