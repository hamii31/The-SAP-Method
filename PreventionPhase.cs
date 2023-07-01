using System.Security.Cryptography;
using System.Text;

namespace The_BCSAP_Method
{
    internal class PreventionPhase
    {
        // PREVENTION PHASE
        // <summary>
        // In this phase, an encrypting algorithm takes the customly generated password in the previous 
        // phase and uses it to securily encrypt the sensitive data in a 256 bit manner. 
        // A copy of the decrypted data is sent to the Server Admin for safekeeping in case the original data 
        // gets corrupted or deleted. 
        // <summary>
        public static string Encrypt(int id, string text, string password)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            using (SymmetricAlgorithm crypt = Aes.Create())
            using (HashAlgorithm hash = MD5.Create())
            using (MemoryStream memorystream = new MemoryStream())
            {
                crypt.Key = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                crypt.GenerateIV();
                using (CryptoStream cryptoStream = new CryptoStream(
            memorystream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(buffer, 0, buffer.Length);
                }

                string base64IV = Convert.ToBase64String(crypt.IV);
                string base64Ciphertext = Convert.ToBase64String(memorystream.ToArray());
                var deciphered = Decrypt(base64Ciphertext, crypt.Key, crypt.IV);
                ServerAdmin.AddToDataHolder(id, deciphered);
                return base64Ciphertext;
            }
        }
        public static string Decrypt(string base64Ciphertext, byte[] key, byte[] iV)
        {
            var plaintext = string.Empty;
            var base64Decipheredtext = Convert.FromBase64String(base64Ciphertext);
            using (var aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = iV;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (var msDecrypt = new MemoryStream(base64Decipheredtext))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
