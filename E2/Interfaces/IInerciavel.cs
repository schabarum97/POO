﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Interface
{
    public interface IInerciavel
    {
        void Ligar();
        void Desligar();
        bool Estado { get; }
    }
}
