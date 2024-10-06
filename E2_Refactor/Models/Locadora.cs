using E2.Interface;

namespace E2.Models
{
    /*Para aplicar o princípio Open/Closed (OCP) e reduzir a complexidade, criado métodos reutilizáveis para a busca de clientes e veículos.
     Utilizdo Generics para permitir reutilização de código.*/
    public class Locadora
    {
        private List<IVeiculo> _veiculos;
        private List<Cliente> _clientes;
        private List<Locacao> _locacoes;

        public Locadora()
        {
            _veiculos = new List<IVeiculo>();
            _clientes = new List<Cliente>();
            _locacoes = new List<Locacao>();
        }

        // Método para listar veículos
        public List<IVeiculo> ListarVeiculos()
        {
            return _veiculos;
        }

        // Método para listar clientes
        public List<Cliente> ListarClientes()
        {
            return _clientes;
        }

        // Método para listar locações
        public List<Locacao> ListarLocacoes()
        {
            return _locacoes;
        }

        // Método para buscar locações por cliente
        public List<Locacao> BuscarLocacoesPorCliente(Cliente cliente)
        {
            return _locacoes.Where(l => l.Cliente.Documento == cliente.Documento).ToList();
        }
        public void AdicionarVeiculo(IVeiculo veiculo)
        {
            _veiculos.Add(veiculo);
        }

        // Método para adicionar cliente
        public void AdicionarCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        // Método para criar locação
        public void CriarLocacao(Cliente cliente, IVeiculo veiculo, int dias)
        {
            var locacao = new Locacao(cliente, veiculo, dias);
            _locacoes.Add(locacao);
        }
    }
}
