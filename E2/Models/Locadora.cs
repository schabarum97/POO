using E2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Models
{
    public class Locadora
    {
        private List<IVeiculo> veiculos; // Lista de veículos disponíveis para locação
        private List<Cliente> clientes; // Lista de clientes registrados
        private List<Locacao> locacoes; // Lista de locações realizadas

        // Construtor para inicializar as listas de veículos, clientes e locações
        public Locadora()
        {
            veiculos = new List<IVeiculo>();
            clientes = new List<Cliente>();
            locacoes = new List<Locacao>();
        }

        // Método para adicionar um veículo à lista de veículos
        public void AdicionarVeiculo(IVeiculo veiculo)
        {
            veiculos.Add(veiculo);
            Console.WriteLine("Veículo adicionado com sucesso!");
        }

        // Método para adicionar um cliente à lista de clientes
        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        // Método para criar uma nova locação
        public void CriarLocacao(Cliente cliente, IVeiculo veiculo, DateTime dataInicio, DateTime dataFim)
        {
            Locacao locacao = new Locacao(cliente, veiculo, dataInicio, dataFim);
            locacoes.Add(locacao);
            Console.WriteLine("Locação criada com sucesso!");
        }

        // Método para listar todos os veículos disponíveis
        public void ListarVeiculos()
        {
            Console.WriteLine("Veículos Disponíveis:");
            foreach (var veiculo in veiculos)
            {
                veiculo.ExibirInformacoes();
            }
        }

        // Método para listar todos os clientes registrados
        public void ListarClientes()
        {
            Console.WriteLine("Clientes:");
            foreach (var cliente in clientes)
            {
                cliente.ExibirInformacoes();
            }
        }

        // Método para listar todas as locações realizadas
        public void ListarLocacoes()
        {
            Console.WriteLine("Locações:");
            foreach (var locacao in locacoes)
            {
                locacao.ExibirInfo();
            }
        }

        // Método para buscar um veículo pela placa
        public IVeiculo BuscarVeiculoPorPlaca(string placa)
        {
            return veiculos.FirstOrDefault(v => v.Placa == placa);
        }

        // Método para buscar um cliente pelo documento (CPF)
        public Cliente BuscarClientePorCpf(string cpf)
        {
            return clientes.FirstOrDefault(c => c.Documento == cpf);
        }

        // Método para buscar todas as locações de um cliente específico
        public List<Locacao> BuscarLocacoesPorCliente(Cliente cliente)
        {
            return locacoes.Where(l => l.Cliente == cliente).ToList();
        }
    }
}
