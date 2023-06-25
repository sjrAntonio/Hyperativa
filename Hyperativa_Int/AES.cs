using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Hyperativa_Interface
{
    public class AES
    {
        private byte[] Key      = new byte[] { 5, 99, 32, 121, 122, 121, 49, 87, 36, 19, 119, 147, 126, 113, 133, 98 };
        private byte[] IniVetor = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        public Aes Algorithm { get; set; }

        public AES()
        {
            Algorithm = Aes.Create();
        }

        public AES(byte[] key, byte[] iniVetor)
        {
            this.Key       = key;
            this.IniVetor  = iniVetor;
            this.Algorithm = Aes.Create();
        }

        public string criptografarAES(string sValorCript)
        {
            byte[] symEncryptedData;

            var dataToProtectAsArray = Encoding.UTF8.GetBytes(sValorCript);

            using (var encryptor    = this.Algorithm.CreateEncryptor(this.Key, this.IniVetor))
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(dataToProtectAsArray, 0, dataToProtectAsArray.Length);
                cryptoStream.FlushFinalBlock();
                symEncryptedData = memoryStream.ToArray();
            }

            this.Algorithm.Dispose();

            return Convert.ToBase64String(symEncryptedData);
        }

        public string descriptografarAES(string sValorDecript)
        {
            var symEncryptedData = Convert.FromBase64String(sValorDecript);

            byte[] symUnencryptedData;

            using (var decryptor = this.Algorithm.CreateDecryptor(this.Key, this.IniVetor))
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(symEncryptedData, 0, symEncryptedData.Length);
                cryptoStream.FlushFinalBlock();
                symUnencryptedData = memoryStream.ToArray();
            }
            this.Algorithm.Dispose();
            return System.Text.Encoding.Default.GetString(symUnencryptedData);
        }
    }
}