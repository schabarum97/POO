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
        Moto moto = new Moto("ABC-1234", "CG 150", "Honda", 2020, 80.0, motorMoto);
        // Adicionando veículos à locadora
        locadora.AdicionarVeiculo(carro);
        locadora.AdicionarVeiculo(moto);

        // Criando alguns clientes
        var cliente1 = new Cliente("João da Silva", "123456789", "Rua das Flores, 123", "987654321");
        var cliente2 = new Cliente("Maria Oliveira", "987654321", "Avenida Central, 456", "123456789");

        // Adicionando clientes à locadora
        locadora.AdicionarCliente(cliente1);
        locadora.AdicionarCliente(cliente2);

        locadora.CriarLocacao(cliente1, moto, 5);
        locadora.CriarLocacao(cliente2, carro, 5);
        
        var veiculos = locadora.ListarVeiculos();
        foreach (var veiculo in veiculos)
        {
            veiculo.ExibirInformacoes();
        }

        var clientes = locadora.ListarClientes();
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Cliente: {cliente.Nome}");
        }

        var locacoes = locadora.ListarLocacoes();
        foreach (var locacao in locacoes)
        {
            Console.WriteLine($"Locação para o cliente: {locacao.Cliente.Nome}");
        }
     
        // Buscando e exibindo locações por cliente
        var locacoesCliente1 = locadora.BuscarLocacoesPorCliente(cliente1);
        Console.WriteLine($"Número de locações para {cliente1.Nome}: {locacoesCliente1.Count}");
    }
}