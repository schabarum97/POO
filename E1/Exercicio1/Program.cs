using System;

namespace GerenciamentoVeiculos
{
    // Classe principal do programa
    class Program
    {
        static void Main(string[] args)
        {
            // Criação de um objeto Carro com os parâmetros fornecidos
            Carro carro = new Carro("Toyota", "Corolla", 2020, "Branco", 4);

            // Criação de um objeto Aviao com os parâmetros fornecidos
            Aviao aviao = new Aviao("Boeing", "737", 2015, "Azul", 180);

            // Exibição das informações do carro e execução de seus métodos
            Console.WriteLine("Informações do Carro:");
            Console.WriteLine(carro.ObterDescricao());
            carro.Acelerar();
            carro.Frear();

            // Exibição das informações do avião e execução de seus métodos
            Console.WriteLine("\nInformações do Avião:");
            Console.WriteLine(aviao.ObterDescricao());
            aviao.Decolar();
            aviao.Pousar();
        }
    }
}
