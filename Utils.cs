using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InternetBanking
{
    public class Utils
    {
        //Hacer requests 
        private static readonly HttpClient httpClient = new HttpClient();
        public static readonly Uri integracionUri = new Uri("http://localhost:8081");
        public static readonly int timeOut = 1000;
        public static string makeRequest(string path, string content)
        {
            UriBuilder builder = new UriBuilder(integracionUri);
            builder.Path = path;
            StringContent httpContent = new StringContent(content);
            Task<HttpResponseMessage> TResponseMessage = httpClient.PostAsync(builder.Uri, httpContent);
            if (!TResponseMessage.Wait(timeOut))
            {
                throw new Exception("No se pudo lograr la conexion...");
            }
            Task<string> TResultString = TResponseMessage.Result.Content.ReadAsStringAsync();
            if (!TResultString.Wait(timeOut))
            {
                throw new Exception("No se pudo procesar el resultado...");
            }

            return TResultString.Result;
        }

        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}