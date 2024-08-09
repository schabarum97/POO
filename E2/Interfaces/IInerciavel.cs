using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E2.Interface
{   // Interface que define as operações básicas para um objeto inercial.
    public interface IInerciavel
    {
        // Liga o objeto, ativando sua funcionalidade principal.
        public void Ligar();

        // Desliga o objeto, desativando sua funcionalidade principal.
        public void Desligar();

        // Obtém um valor indicando se o objeto está ligado ou desligado.
        bool Estado { get; }
    }
}
