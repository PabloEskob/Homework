using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionUtility
{
    private static byte[] GetKeyBytes(string password, int keySize)
    {
        using (var key = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("salt12345"), 10000))
        {
            return key.GetBytes(keySize / 8);
        }
    }

    public static string Encrypt(string plainText, string password)
    {
        byte[] iv = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(iv);
        }

        byte[] keyBytes = GetKeyBytes(password, 256);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = keyBytes;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                }
                return Convert.ToBase64String(iv.Concat(msEncrypt.ToArray()).ToArray());
            }
        }
    }

    public static string Decrypt(string encryptedText, string password)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] iv = encryptedBytes.Take(16).ToArray();
        byte[] encryptedData = encryptedBytes.Skip(16).ToArray();

        byte[] keyBytes = GetKeyBytes(password, 256);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = keyBytes;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}