using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System;

namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class IFormFileExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<string> ReadAsStringAsync(this IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            return result.ToString();
        }
/// <summary>
/// 
/// </summary>
/// <param name="file"></param>
/// <returns></returns>
        public static async Task<string> ConvertToBase64(this IFormFile file) {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                await Task.CompletedTask;
                return s;
            }
        }
/// <summary>
/// 
/// </summary>
/// <param name="file"></param>
/// <returns></returns>
        public static string GetExtension(this IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }
/// <summary>
/// 
/// </summary>
/// <param name="fileName"></param>
/// <returns></returns>
        public static string GetExtension(this string fileName)
        {
            return Path.GetExtension(fileName);
        }
        
    }
}

