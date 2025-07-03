using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.OTAUserAppService.Dtos;
using Microsoft.Extensions.Options;

namespace BookingEngine.Application.OTAUserAppService
{
    public class EncryptionAppService : IEncryptionAppService
    {
        // Replace these with your secure key and IV; 
        // for AES-256, key length = 32 bytes; IV length = 16 bytes.
        private readonly byte[] _key;
        private readonly byte[] _iv;


        public EncryptionAppService()
        {
            var key = "8fQ2z6vLc9kYx4wZB3nJmR7uV8qWa3vE"; ;
            var iv = "2sX4vBnR7kT9qLmZ";

            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Encryption key cannot be null or empty.", nameof(key));
            if (string.IsNullOrWhiteSpace(iv))
                throw new ArgumentException("Encryption IV cannot be null or empty.", nameof(iv));

            _key = Encoding.UTF8.GetBytes(key);
            _iv = Encoding.UTF8.GetBytes(iv);

            if (_key.Length != 32)
                throw new ArgumentException("Key must be 32 bytes for AES-256.", nameof(key));
            if (_iv.Length != 16)
                throw new ArgumentException("IV must be 16 bytes for AES.", nameof(iv));
        }

        public string Encrypt(string plainText)
        {
            if (plainText == null)
                return null;

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string Decrypt(string encryptedText)
        {
            if (encryptedText == null)
                return null;

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

                using MemoryStream ms = new(encryptedBytes);
                using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
                using StreamReader sr = new(cs);
                return sr.ReadToEnd();
            }
        }



    }
}
