using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.Framework.Services.Localization;

namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class RSAHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plain"></param>
        /// <returns></returns>
        public static string EncryptSystem(string plain)
        {
            return Encrypt1024(plain, Constants.SystemRsaPublicKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plain"></param>
        /// <returns></returns>
        public static string DecryptSystem(string plain)
        {
            return Decrypt1024(plain, Constants.SystemRsaPublicKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plain"></param>
        /// <returns></returns>
        public static string EncryptData(string plain)
        {
            return "";
            // return Encrypt1024(plain, _cmsSetting.DataRsaPublicKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plain"></param>
        /// <returns></returns>
        public static string DecryptData(string plain)
        {
            return "";
            // return Decrypt1024(plain, _cmsSetting.DataRsaPrivateKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string DecryptClient(string result)
        {
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plain"></param>
        /// <param name="RSAKey"></param>
        /// <returns></returns>
        public static string Encrypt1024(string plain, string RSAKey)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024))
                {
                    RSA.ImportParameters(GetRSAParameters(RSAKey));
                    encryptedData = RSA.Encrypt(System.Text.Encoding.Unicode.GetBytes(plain), false);
                }
                return Convert.ToBase64String(encryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plain"></param>
        /// <param name="RSAKey"></param>
        /// <returns></returns>
        public static string Decrypt1024(string plain, string RSAKey)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024))
                {
                    RSA.ImportParameters(GetRSAParameters(RSAKey));
                    encryptedData = RSA.Decrypt(System.Text.Encoding.Unicode.GetBytes(plain), false);
                }
                return Convert.ToBase64String(encryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        private static RSAParameters GetRSAParameters(string Key)
        {
            byte[] lDer;

            //Set RSAKeyInfo to the public key values. 
            // int lBeginStart = "-----BEGIN PUBLIC KEY-----".Length;
            // int lEndLenght = "-----END PUBLIC KEY-----".Length;
            // string KeyString = pPublicKey.Substring(lBeginStart, (pPublicKey.Length - lBeginStart - lEndLenght));
            lDer = Convert.FromBase64String(Key);


            //Create a new instance of the RSAParameters structure.
            RSAParameters lRSAKeyInfo = new RSAParameters();

            lRSAKeyInfo.Modulus = GetModulus(lDer);
            lRSAKeyInfo.Exponent = GetExponent(lDer);

            return lRSAKeyInfo;
        }
        private static byte[] GetModulus(byte[] pDer)
        {
            //Size header is 29 bits
            //The key size modulus is 128 bits, but in hexa string the size is 2 digits => 256 
            string lModulus = BitConverter.ToString(pDer).Replace("-", "").Substring(58, 256);

            return StringHexToByteArray(lModulus);
        }

        private static byte[] GetExponent(byte[] pDer)
        {
            int lExponentLenght = pDer[pDer.Length - 3];
            string lExponent = BitConverter.ToString(pDer).Replace("-", "").Substring((pDer.Length * 2) - lExponentLenght * 2, lExponentLenght * 2);

            return StringHexToByteArray(lExponent);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringHexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }

}
