using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APBD_05._03
{
    class Program
    {
        public static async Task Main(string[] args)
        {


            string url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";

            HttpClient client = new HttpClient();
            var result = await client.GetAsync(url); //Task<HttpResponseMassage>

            if (!result.IsSuccessStatusCode) return;

            string html = await result.Content.ReadAsStringAsync();
            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+", RegexOptions.IgnoreCase);
            var matcher = regex.Matches(html);
            foreach(var m in matcher)
            {
                Console.WriteLine(m);
            }
        }
    }
}
