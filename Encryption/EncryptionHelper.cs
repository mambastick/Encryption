using System.Security.Cryptography;

namespace Encryption;

public class EncryptionHelper
{
    public byte[] GenerateRandomKey(int sizeInBytes = 32)
    {
        using var rng = new RNGCryptoServiceProvider();
        var key = new byte[sizeInBytes];
        rng.GetBytes(key);
        return key;
    }

    public byte[] GenerateRandomIV(int sizeInBytes = 16)
    {
        using var rng = new RNGCryptoServiceProvider();
        var iv = new byte[sizeInBytes];
        rng.GetBytes(iv);
        return iv;
    }
    
    public byte[] Encrypt(string plainText, byte[] key, byte[] iv)
    {
        using var aesAlg = Aes.Create();
        aesAlg.Key = key;
        aesAlg.IV = iv;

        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }
        }

        return msEncrypt.ToArray();
    }

    public string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
    {
        using var aesAlg = Aes.Create();
        aesAlg.Key = key;
        aesAlg.IV = iv;

        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using var msDecrypt = new MemoryStream(cipherText);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        return srDecrypt.ReadToEnd();
    }
}