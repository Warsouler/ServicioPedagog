using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;



namespace Servicio.Infraestructure.Facades.Files
{
    public static class Cryptography
    {
        #region Settings

        private static int _iterations = 2;
        private static int _keySize = 256;

        private static string _hash = "SHA1";
        private static string password = "D3T31C3T4L3Nt911"; // Random
        private static string _salt = "TNihIeZTFoR5g153"; // Random
        private static string _vector = "qiCTKtAechG43D3t"; // Random

        //private static string _salt = "aselrias38490a32"; // Random
        //private static string _vector = "8947az34awl34kjq"; // Random

        private static System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        #endregion

        public static string Encrypt(string value)
        {
            return Encrypt<AesManaged>(value);
        }
        public static string Encrypt<T>(string value)
                where T : SymmetricAlgorithm, new()
        {
            
            byte[] vectorBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = encoding.GetBytes(value);

            byte[] encrypted;
            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes =
                    new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }
                cipher.Clear();
            }
            string returner= Convert.ToBase64String(encrypted).Replace("/", "#");
            return returner;
        }

        public static string Decrypt(string value)
        {
            return Decrypt<AesManaged>(value);
        }
        public static string Decrypt<T>(string value) where T : SymmetricAlgorithm, new()
        {
            value = value.Replace("#", "/");
            //byte[] vectorBytes = GetBytes<ASCIIEncoding>(_vector);
            //byte[] saltBytes = GetBytes<ASCIIEncoding>(_salt);
            byte[] vectorBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(valueBytes))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return String.Empty;
                }

                cipher.Clear();
            }
            
            return encoding.GetString(decrypted, 0, decryptedByteCount);
        }

    }
}