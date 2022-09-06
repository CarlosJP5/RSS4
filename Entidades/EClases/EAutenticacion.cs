using System;
using System.Security.Cryptography;
using System.Text;

namespace Entidades.EClases
{
    public class EAutenticacion
    {
        private readonly string hash = "W@t3r";

        public string Encriptar(string pwd)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(pwd);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        //public string Encriptar(string pwd)
        //{
        //    byte[] plaintext = Encoding.Unicode.GetBytes(pwd);

        //    CspParameters cspParams = new CspParameters();
        //    cspParams.KeyContainerName = hash;
        //    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048, cspParams))
        //    {
        //        byte[] encryptedData = RSA.Encrypt(plaintext, false);
        //        return Convert.ToBase64String(encryptedData);
        //    }
        //}

        public string Desencriptar(string pwdEcry)
        {
            byte[] data = Convert.FromBase64String(pwdEcry);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        //public string Desencriptar(string pwdEcry)
        //{
        //    byte[] encryptedData = Convert.FromBase64String(pwdEcry);

        //    CspParameters cspParams = new CspParameters();
        //    cspParams.KeyContainerName = hash;
        //    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048, cspParams))
        //    {
        //        byte[] decryptedData = RSA.Decrypt(encryptedData, false);
        //        return Encoding.Unicode.GetString(decryptedData);
        //    }
        //}
    }
}
