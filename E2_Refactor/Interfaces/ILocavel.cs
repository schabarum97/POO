using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Interfaces
{
    public interface ILocavel
    {
       double PrecoDiaria { get; set; }
       double CalcularPrecoLocacao(int dias);
    }
}
