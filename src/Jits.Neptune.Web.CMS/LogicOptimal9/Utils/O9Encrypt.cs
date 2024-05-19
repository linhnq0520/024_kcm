using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class O9Encrypt
    {
        private static string CONSTKEY = "abhf@311";

        /// <summary>
        /// 
        /// </summary>
        public static string Decrypt(string textToDecrypt)
        {
#pragma warning disable SYSLIB0022 // Type or member is obsolete
            RijndaelManaged rijndaelCipher = new();
#pragma warning restore SYSLIB0022 // Type or member is obsolete
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
            byte[] pwdBytes = Encoding.UTF8.GetBytes(CONSTKEY);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            len = len > keyBytes.Length ? keyBytes.Length : pwdBytes.Length;
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Encrypt(string textToEncrypt)
        {
#pragma warning disable SYSLIB0022 // Type or member is obsolete
            RijndaelManaged rijndaelCipher = new();
#pragma warning restore SYSLIB0022 // Type or member is obsolete
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = Encoding.UTF8.GetBytes(CONSTKEY);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            len = len > keyBytes.Length ? keyBytes.Length : pwdBytes.Length;
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;

            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);

            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        public static string MD5Encrypt(string pwd)
        {
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateRandomString()
        {
#pragma warning disable SYSLIB0023 // Type or member is obsolete
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
#pragma warning restore SYSLIB0023 // Type or member is obsolete
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch
            {
                return null;
            }
        }
    }
}