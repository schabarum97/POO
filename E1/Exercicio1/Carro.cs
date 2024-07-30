namespace GerenciamentoVeiculos
{
    // Subclasse Carro que herda de Veiculo
    public class Carro : Veiculo
    {
        // Atributo específico da classe Carro: número de portas
        public int NumeroDePortas { get; private set; }

        // Construtor da classe Carro
        // Inicializa a classe base Veiculo com os parâmetros marca, modelo, ano e cor
        // E inicializa o atributo específico NumeroDePortas
        public Carro(string marca, string modelo, int ano, string cor, int numeroDePortas)
            : base(marca, modelo, ano, cor)
        {
            NumeroDePortas = numeroDePortas;
        }

        // Método sobrescrito da classe base Veiculo
        // Retorna a descrição completa do carro, incluindo o número de portas
        public override string ObterDescricao()
        {
            return base.ObterDescricao() + $", Número de Portas: {NumeroDePortas}";
        }

        // Método que simula a ação de acelerar o carro
        public void Acelerar()
        {
            Console.WriteLine("O carro está acelerando.");
        }

        // Método que simula a ação de frear o carro
        public void Frear()
        {
            Console.WriteLine("O carro está freando.");
        }
    }
}
