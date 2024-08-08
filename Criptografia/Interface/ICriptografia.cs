using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Interface
{
    public interface ICriptografia
    {
        public string Criptografar(string plainText);
        public string Descriptografar(string cipherText);
    }
}
