using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIMRS25.Class
{
    public interface IAesEncryptionService
    {
        byte[] Encrypt(string plainText);
        string Decrypt(byte[] cipherBytes);
    }

    public class AesEncryptionService : IAesEncryptionService
    {
        private static byte[]? _key;
        private static byte[]? _iv;

        private AesEncryptionService() { }

        /// <summary>
        /// Inisialisasi key dan IV dari base64 string, sebaiknya dipanggil sekali di awal aplikasi (misalnya di Startup atau Program).
        /// </summary>
        public static void Initialize(string base64Key, string base64IV)
        {
            _key = Convert.FromBase64String(base64Key);
            _iv = Convert.FromBase64String(base64IV);
        }

        /// <summary>
        /// Membuat instance AesEncryptionService setelah Key dan IV diinisialisasi.
        /// </summary>
        public static AesEncryptionService CreateService()
        {
            if (_key == null || _iv == null)
                throw new InvalidOperationException("Encryption key and IV not initialized.");

            return new AesEncryptionService();
        }

        public byte[] Encrypt(string plainText)
        {
            if (_key == null || _iv == null)
                throw new InvalidOperationException("Key/IV belum diinisialisasi");


            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs, Encoding.UTF8))
            {
                sw.Write(plainText);
            }
            return ms.ToArray();
        }

        public string Decrypt(byte[] cipherBytes)
        {
            if (_key == null || _iv == null)
                throw new InvalidOperationException("Key/IV belum diinisialisasi");

            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.UTF8);

            return sr.ReadToEnd();
        }

        public static byte[] GenerateRandomKey(int sizeInBytes = 32) => RandomNumberGenerator.GetBytes(sizeInBytes);
        public static byte[] GenerateRandomIV(int sizeInBytes = 16) => RandomNumberGenerator.GetBytes(sizeInBytes);
    }
}
