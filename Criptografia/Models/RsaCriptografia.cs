using Criptografia.Interface;
using System;
using System.Security.Cryptography;
using System.Text;

public class RsaCriptografia : ICriptografia
{
    private readonly RSA _rsa;

    public RsaCriptografia()
    {
        _rsa = RSA.Create();
    }

    public string Criptografar(string plainText)
    {
        // Converte o texto plano para um array de bytes usando codificação UTF-8
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);

        // Criptografa o array de bytes usando a instância RSA e o padding PKCS1
        byte[] encryptedData = _rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);

        // Converte o array de bytes criptografados para uma string codificada em Base64 e a retorna
        return Convert.ToBase64String(encryptedData);
    }

    public string Descriptografar(string cipherText)
    {
        // Converte a string codificada em Base64 de volta para um array de bytes
        byte[] dataToDecrypt = Convert.FromBase64String(cipherText);

        // Descriptografa o array de bytes usando a instância RSA e o padding PKCS1
        byte[] decryptedData = _rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.Pkcs1);

        // Converte o array de bytes descriptografados de volta para uma string usando codificação UTF-8 e a retorna
        return Encoding.UTF8.GetString(decryptedData);
    }
}
