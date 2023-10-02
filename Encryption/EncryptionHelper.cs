using System.Security.Cryptography;

namespace Encryption;

public class EncryptionHelper
{
    public static byte[] GenerateRandomKey(int sizeInBytes)
    {
        using var rng = new RNGCryptoServiceProvider();
        var key = new byte[sizeInBytes];
        rng.GetBytes(key);
        return key;
    }

    public static byte[] GenerateRandomIV(int sizeInBytes)
    {
        using var rng = new RNGCryptoServiceProvider();
        var iv = new byte[sizeInBytes];
        rng.GetBytes(iv);
        return iv;
    }
}