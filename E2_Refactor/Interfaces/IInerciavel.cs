using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E2.Interfaces {
    // Ajustado somente o nome do método e a remoção de public na interface, pois é redundante.
    // Retirado os comentários que tinha devido a ser auto explicativo o que cada método deve fazer
    public interface IInerciavel
    {
        void Ligar();
        void Desligar();
        bool Estado { get; }
    }
}
