using System.Security.Cryptography;

namespace Encryption;

public class EncryptionHelper
{
    public byte[] GenerateRandomKey(int sizeInBytes = 16)
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
}