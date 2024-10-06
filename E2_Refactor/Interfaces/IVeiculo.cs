using E2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace E2.Interface
{
    public interface IVeiculo
    {
        void ExibirInformacoes();


        /*Aplicando o princípio de Interface Segregation(ISP), separamos responsabilidades que podem ser 
* opcionais para alguns veículos(como exibir informações ou calcular o preço da locação) em interfaces dedicadas.
Sendo elas ILocavel, IInformavel, IControlavel*/
        public interface IVeiculo
        {
            string Placa { get; }
            string Modelo { get; }
            string Marca { get; }
            int Ano { get; }
            double PrecoDiaria { get; }

            void Frear();
            void Mover();
            void ExibirInformacoes();
        }
    }
}
