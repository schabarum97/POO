using Criptografia.Interface;
using System.Text;

public static class CriaCriptografia
{
    public static ICriptografia CriarCriptografia(string tipo)
    {
        return tipo switch
        {
            "SIM" => new AesCriptografia(), 
            "NSIM" => new RsaCriptografia(),
            _ => throw new ArgumentException("Tipo de criptografia desconhecido.")
        };
    }
}
