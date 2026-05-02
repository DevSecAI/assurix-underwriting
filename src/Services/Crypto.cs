// ASR-SAST-008: TripleDES + ECB.
using System.Security.Cryptography;

public static class Crypto
{
    public static byte[] Encrypt(byte[] plain, byte[] key)
    {
        using var alg = TripleDES.Create();
        alg.Key  = key;
        alg.Mode = CipherMode.ECB;
        alg.Padding = PaddingMode.PKCS7;
        using var enc = alg.CreateEncryptor();
        return enc.TransformFinalBlock(plain, 0, plain.Length);
    }
}
