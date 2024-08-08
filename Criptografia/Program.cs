using Criptografia.Interface;
using System;
using System.IO;
using System.Text;

public class Programa
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\nEscolha a operação:");
        Console.WriteLine("1. Criptografar/Descriptografar texto");
        Console.WriteLine("2. Criptografar/Descriptografar arquivo");

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                ProcessarTexto();
                break;

            case "2":
                ProcessarArquivo();
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    private static void ProcessarTexto()
    {
        Console.WriteLine("Escolha o tipo de criptografia (SIM/NSIM):");
        string tipo = Console.ReadLine().ToUpper();

        ICriptografia criptografia = CriaCriptografia.CriarCriptografia(tipo);

        if (criptografia == null)
        {
            Console.WriteLine("Tipo de criptografia desconhecido.");
            return;
        }

        Console.WriteLine("Por favor insira um texto para criptografia:");
        string texto = Console.ReadLine();

        string textoCriptografado = criptografia.Criptografar(texto);
        Console.WriteLine($"Texto criptografado: {textoCriptografado}");

        string textoDescriptografado = criptografia.Descriptografar(textoCriptografado);
        Console.WriteLine($"Texto descriptografado: {textoDescriptografado}");

        Console.ReadKey();
    }

    private static void ProcessarArquivo()
    {
        Console.Write("Digite a senha para criptografia: ");
        string password = Console.ReadLine();

        byte[] salt = Encoding.UTF8.GetBytes("salt1234"); // Em um cenário real, gere um salt aleatório

        Console.Write("Digite o caminho do arquivo a ser criptografado: ");
        string inputFile = Console.ReadLine();

        Console.Write("Digite o caminho onde o arquivo criptografado será salvo: ");
        string encryptedFile = Console.ReadLine();

        Console.Write("Digite o caminho onde o arquivo descriptografado será salvo: ");
        string decryptedFile = Console.ReadLine();

        // Criptografia Simétrica
        var fileEncryptor = new AesFileCriptografia(password, salt);

        // Criptografia Assimétrica
        var asymmetricEncryptor = new RsaFileCriptografia();

        // Exportar e importar a chave pública e privada
        string publicKey = asymmetricEncryptor.ExportPublicKey();
        Console.WriteLine("Chave pública:");
        Console.WriteLine(publicKey);

        string privateKey = asymmetricEncryptor.ExportPrivateKey();
        Console.WriteLine("Chave privada:");
        Console.WriteLine(privateKey);

        try
        {
            // 1. Criptografar o arquivo com AES
            fileEncryptor.EncryptFile(inputFile, encryptedFile);
            Console.WriteLine("Arquivo criptografado com sucesso!");

            // 2. Criptografar a chave e IV com RSA
            byte[] encryptedKey = asymmetricEncryptor.EncryptData(fileEncryptor.Key);
            byte[] encryptedIV = asymmetricEncryptor.EncryptData(fileEncryptor.IV);

            // Salvar as chaves criptografadas
            File.WriteAllBytes(encryptedFile + ".key", encryptedKey);
            File.WriteAllBytes(encryptedFile + ".iv", encryptedIV);

            // Para simular a transferência, criar uma nova instância e importar a chave privada
            var decryptor = new RsaFileCriptografia();
            decryptor.ImportPrivateKey(privateKey);

            // 3. Descriptografar a chave e IV com RSA
            byte[] decryptedKey = decryptor.DecryptData(File.ReadAllBytes(encryptedFile + ".key"));
            byte[] decryptedIV = decryptor.DecryptData(File.ReadAllBytes(encryptedFile + ".iv"));
            
            // Configurar o FileEncryptor com a chave e IV descriptografadas
            var fileDecryptor = new AesFileCriptografia(password, salt)
            {
                Key = decryptedKey,
                IV = decryptedIV
            };
            

            // 4. Descriptografar o arquivo com AES
            fileDecryptor.DecryptFile(encryptedFile, decryptedFile);
            Console.WriteLine("Arquivo descriptografado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}
