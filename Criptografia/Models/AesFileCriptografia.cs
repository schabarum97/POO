using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesFileCriptografia
{
    public byte[] Key { get; set; }
    public byte[] IV { get; set; }

    public AesFileCriptografia(string password, byte[] salt)
    {
        using (var keyGenerator = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            Key = keyGenerator.GetBytes(32); // AES-256
            IV = keyGenerator.GetBytes(16);  // AES-128
        }
    }

    public void EncryptFile(string inputFile, string outputFile)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
            using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
            using (var cryptoStream = new CryptoStream(outputFileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                inputFileStream.CopyTo(cryptoStream);
            }
        }
    }

    public void DecryptFile(string inputFile, string outputFile)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
            using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
            using (var cryptoStream = new CryptoStream(inputFileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                cryptoStream.CopyTo(outputFileStream);
            }
        }
    }
}