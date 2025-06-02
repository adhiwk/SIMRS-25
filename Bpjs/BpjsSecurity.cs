using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace SIMRS25.Bpjs
{
    public class BpjsSecurity
    {
		public static string Decrypt(string key, string data)
		{
			string? decData = null;
			byte[][] keys = GetHashKeys(key);

			try
			{
				decData = DecryptStringFromBytes_Aes(data, keys[0], keys[1]);
			}
			catch (CryptographicException UnusedCryptographicException)
			{
				Console.WriteLine(UnusedCryptographicException.Message);
			}
			catch (ArgumentNullException UnusedArgumentNullException)
			{
				Console.WriteLine(UnusedArgumentNullException.Message);
			}

            return decData ?? string.Empty;
        }
		public static string DecryptStringFromBytes_Aes(string cipherTextString, byte[] Key, byte[] IV)
		{
			var cipherText = Convert.FromBase64String(cipherTextString);
			if (cipherText == null || cipherText.Length <= 0)
			{
				throw new ArgumentNullException("cipherText");
			}
			if (Key == null || Key.Length <= 0)
			{
				throw new ArgumentNullException("Key");
			}
			if (IV == null || IV.Length <= 0)
			{
				throw new ArgumentNullException("IV");
			}

			string? plaintext = null;

			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;
				ICryptoTransform decryptor = (ICryptoTransform)aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using var msDecrypt = new MemoryStream(cipherText);
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                plaintext = srDecrypt.ReadToEnd();
            }

			return plaintext;
		}
		public static byte[][] GetHashKeys(string key)
		{
			var result = new byte[2][];
			var enc = Encoding.UTF8;
			using var sha2 = SHA256.Create();
            var rawKey = enc.GetBytes(key);
			var rawIV = enc.GetBytes(key);
			byte[] hashKey = sha2.ComputeHash(rawKey);
			byte[] hashIV = sha2.ComputeHash(rawIV);
			Array.Resize(ref hashIV, 16);
			result[0] = hashKey;
			result[1] = hashIV;
			return result;
		}

	}
}
