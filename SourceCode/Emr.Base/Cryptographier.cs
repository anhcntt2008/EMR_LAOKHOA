using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emr
{
    public static class Cryptographier
    {
        private static readonly byte[] _passphase = new byte[] { 194, 181, 29, 72, 196, 32, 19, 77, 104, 213, 85, 164, 6, 220, 19, 254, 181, 194, 127, 210, 216, 172, 39, 238, 180, 213, 36, 68, 240, 55, 135, 188 };//256bit
        private static readonly byte[] _iv = new byte[] { 190, 107, 169, 157, 65, 190, 89, 34, 135, 65, 0, 137, 63, 43, 235, 100 };

        public static string Encrypt(string text)
        {
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _passphase;
                aesAlg.IV = _iv;
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(text);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string str)
        {
            var cipherText = Convert.FromBase64String(str);
            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _passphase;
                aesAlg.IV = _iv;
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return plaintext;
        }
    }
}
