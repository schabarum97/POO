namespace GerenciamentoVeiculos
{
    // Subclasse Aviao que herda de Veiculo
    public class Aviao : Veiculo
    {
        // Atributo específico da classe Aviao: capacidade de passageiros
        public int CapacidadeDePassageiros { get; private set; }

        // Construtor da classe Aviao
        // Inicializa a classe base Veiculo com os parâmetros marca, modelo, ano e cor
        // E inicializa o atributo específico CapacidadeDePassageiros
        public Aviao(string marca, string modelo, int ano, string cor, int capacidadeDePassageiros)
            : base(marca, modelo, ano, cor)
        {
            CapacidadeDePassageiros = capacidadeDePassageiros;
        }

        // Método sobrescrito da classe base Veiculo
        // Retorna a descrição completa do avião, incluindo a capacidade de passageiros
        public override string ObterDescricao()
        {
            return base.ObterDescricao() + $", Capacidade de Passageiros: {CapacidadeDePassageiros}";
        }

        // Método que simula a ação de decolar o avião
        public void Decolar()
        {
            Console.WriteLine("O avião está decolando.");
        }

        // Método que simula a ação de pousar o avião
        public void Pousar()
        {
            Console.WriteLine("O avião está pousando.");
        }
    }
}
