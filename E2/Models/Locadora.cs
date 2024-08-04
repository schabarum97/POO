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
        private List<IVeiculo> veiculos;
        private List<Cliente> clientes;
        private List<Locacao> locacoes;

        public Locadora()
        {
            veiculos = new List<IVeiculo>();
            clientes = new List<Cliente>();
            locacoes = new List<Locacao>();
        }

        public void AdicionarVeiculo(IVeiculo veiculo)
        {
            veiculos.Add(veiculo);
            Console.WriteLine("Veículo adicionado com sucesso!");
        }

        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        public void CriarLocacao(Cliente cliente, IVeiculo veiculo, DateTime dataInicio, DateTime dataFim)
        {
            Locacao locacao = new Locacao(cliente, veiculo, dataInicio, dataFim);
            locacoes.Add(locacao);
            Console.WriteLine("Locação criada com sucesso!");
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("Veículos Disponíveis:");
            foreach (var veiculo in veiculos)
            {
                veiculo.ExibirInformacoes();
            }
        }

        public void ListarClientes()
        {
            Console.WriteLine("Clientes:");
            foreach (var cliente in clientes)
            {
                cliente.ExibirInformacoes();
            }
        }

        public void ListarLocacoes()
        {
            Console.WriteLine("Locações:");
            foreach (var locacao in locacoes)
            {
                locacao.ExibirInfo();
            }
        }

        public IVeiculo BuscarVeiculoPorPlaca(string placa)
        {
            return veiculos.FirstOrDefault(v => v.Placa == placa);
        }

        public Cliente BuscarClientePorCpf(string cpf)
        {
            return clientes.FirstOrDefault(c => c.Documento == cpf);
        }

        public List<Locacao> BuscarLocacoesPorCliente(Cliente cliente)
        {
            return locacoes.Where(l => l.Cliente == cliente).ToList();
        }
    }
}
