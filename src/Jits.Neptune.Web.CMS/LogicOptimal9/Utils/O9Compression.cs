using Apache.NMS.Util;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.IO;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class O9Compression
    {
        /// <summary>
        /// 
        /// </summary>
        public static string GetTextFromCompressBytes(byte[] _content)
        {
            string str = string.Empty;
            try
            {
                if (_content != null)
                    str = new EndianBinaryReader(new InflaterInputStream(new MemoryStream(_content))).ReadString32();
                return str;
            }
            catch (Exception)
            {
                return str;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] SetCompressText(string txt)
        {
            byte[] numArray = null;
            if (txt != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream(ms);
                    new EndianBinaryWriter(deflaterOutputStream).WriteString32(txt);
                    deflaterOutputStream.Close();
                    numArray = ms.ToArray();
                }
            }
            return numArray;
        }
    }
}
