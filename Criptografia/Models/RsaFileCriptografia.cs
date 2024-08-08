using System.Security.Cryptography;

public class RsaFileCriptografia
{
    private readonly RSACryptoServiceProvider _rsa;

    public RsaFileCriptografia()
    {
        _rsa = new RSACryptoServiceProvider(2048);
    }

    public string ExportPublicKey()
    {
        return _rsa.ToXmlString(false); // Exportar apenas a chave pública
    }

    public void ImportPublicKey(string publicKey)
    {
        _rsa.FromXmlString(publicKey);
    }

    public string ExportPrivateKey()
    {
        return _rsa.ToXmlString(true); // Exportar a chave pública e privada
    }

    public void ImportPrivateKey(string privateKey)
    {
        _rsa.FromXmlString(privateKey);
    }

    public byte[] EncryptData(byte[] data)
    {
        return _rsa.Encrypt(data, false);
    }

    public byte[] DecryptData(byte[] data)
    {
        return _rsa.Decrypt(data, false);
    }
}