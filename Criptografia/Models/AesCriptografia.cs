using Criptografia.Interface;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesCriptografia : ICriptografia
{
    private readonly string _key = "b14ca5898a4e4133bbce2ea2315a1916"; // Chave de 256 bits para AES
    private readonly byte[] _iv = new byte[16]; // Vetor de inicialização de 16 bytes

    public string Criptografar(string plainText)
    {
        byte[] array;

        // Cria uma instância da classe Aes para realizar a criptografia
        using (Aes aes = Aes.Create())
        {
            // Define a chave de criptografia em bytes
            aes.Key = Encoding.UTF8.GetBytes(_key);
            // Define o vetor de inicialização (IV) usado para a criptografia
            aes.IV = _iv;

            // Cria um objeto de transformação para criptografar os dados
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            // Cria um MemoryStream para armazenar os dados criptografados
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Cria um CryptoStream que usa o encryptor para criptografar os dados que são gravados no MemoryStream
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    // Cria um StreamWriter para escrever o texto a ser criptografado no CryptoStream
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        // Escreve o texto plano no CryptoStream, que o criptografa e o grava no MemoryStream
                        streamWriter.Write(plainText);
                    }

                    // Converte o MemoryStream contendo os dados criptografados para um array de bytes
                    array = memoryStream.ToArray();
                }
            }
        }

        // Converte o array de bytes criptografados para uma string codificada em Base64 e a retorna
        return Convert.ToBase64String(array);
    }


    public string Descriptografar(string cipherText)
    {
        // Converte o texto cifrado de Base64 para um array de bytes
        byte[] buffer = Convert.FromBase64String(cipherText);

        // Cria uma instância da classe Aes para realizar a descriptografia
        using (Aes aes = Aes.Create())
        {
            // Define a chave de criptografia em bytes
            aes.Key = Encoding.UTF8.GetBytes(_key);
            // Define o vetor de inicialização (IV) usado para a descriptografia
            aes.IV = _iv;
            // Cria um objeto de transformação para descriptografar os dados
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            // Cria um MemoryStream para ler os dados cifrados a partir do array de bytes
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                // Cria um CryptoStream que usa o decryptor para descriptografar os dados lidos do MemoryStream
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    // Cria um StreamReader para ler o texto descriptografado do CryptoStream
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        // Lê todo o texto descriptografado e o retorna como uma string
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}
