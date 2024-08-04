using E2.Interface;
using E2.Models;

class Program
{
    static void Main(string[] args)
    {
        // Criando a instância da locadora
        var locadora = new Locadora();

        // Criando alguns motores
        var motorCarro = new Motor();
        var motorMoto = new Motor();

        // Criando alguns veículos
        IVeiculo carro = new Carro("ABC-1234", "Fusca", "Volkswagen", 1980, 100.0, motorCarro);
        IVeiculo moto = new Moto("XYZ-5678", "CB 500", "Honda", 2020, 50.0, motorMoto);
        // Adicionando veículos à locadora
        locadora.AdicionarVeiculo(carro);
        locadora.AdicionarVeiculo(moto);

        // Criando alguns clientes
        var cliente1 = new Cliente("João da Silva", "123456789", "Rua das Flores, 123", "987654321");
        var cliente2 = new Cliente("Maria Oliveira", "987654321", "Avenida Central, 456", "123456789");

        // Adicionando clientes à locadora
        locadora.AdicionarCliente(cliente1);
        locadora.AdicionarCliente(cliente2);

        // Criando algumas locações// Criando locações com a data de início e data de fim
        DateTime dataInicio1 = DateTime.Now;
        DateTime dataFim1 = dataInicio1.AddDays(5); // 5 dias de locação

        DateTime dataInicio2 = DateTime.Now;
        DateTime dataFim2 = dataInicio2.AddDays(3); // 3 dias de locação

        locadora.CriarLocacao(cliente1, carro, dataInicio1, dataFim1);
        locadora.CriarLocacao(cliente2, moto, dataInicio2, dataFim2);

        // Listando informações
        locadora.ListarVeiculos();
        locadora.ListarClientes();
        locadora.ListarLocacoes();

        // Buscando e exibindo um veículo por placa
        var veiculoBuscado = locadora.BuscarVeiculoPorPlaca("Fusca");
        Console.WriteLine(veiculoBuscado != null ? "Veículo encontrado!" : "Veículo não encontrado.");

        // Buscando e exibindo um cliente por documento
        var clienteBuscado = locadora.BuscarClientePorCpf("123456789");
        Console.WriteLine(clienteBuscado != null ? "Cliente encontrado!" : "Cliente não encontrado.");

        // Buscando e exibindo locações por cliente
        var locacoesCliente1 = locadora.BuscarLocacoesPorCliente(cliente1);
        Console.WriteLine($"Número de locações para {cliente1.Nome}: {locacoesCliente1.Count}");
    }
}