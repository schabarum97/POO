namespace GerenciamentoVeiculos
{
    // Classe base Veiculo
    public class Veiculo
    {
        // Atributos da classe base Veiculo
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Cor { get; private set; }

        // Construtor da classe base Veiculo
        // Inicializa os atributos Marca, Modelo, Ano e Cor
        public Veiculo(string marca, string modelo, int ano, string cor)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
        }

        // Método virtual que retorna a descrição do veículo
        // Pode ser sobrescrito nas subclasses para incluir mais informações
        public virtual string ObterDescricao()
        {
            return $"Marca: {Marca}, Modelo: {Modelo}, Ano: {Ano}, Cor: {Cor}";
        }
    }
}
