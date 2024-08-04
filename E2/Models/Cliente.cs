using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public Cliente(string nome, string documento, string endereco, string telefone)
        {
            Nome = nome;
            Documento = documento;
            Endereco = endereco;
            Telefone = telefone;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}, Documento: {Documento}, Endereço: {Endereco}, Telefone: {Telefone}");
        }
    }
}
