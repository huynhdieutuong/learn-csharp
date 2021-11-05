using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Networking2
{
    public class Program
    {
        static void ShowHeaders(HttpResponseHeaders headers)
        {
            System.Console.WriteLine("HEADERS: ");
            foreach (var header in headers)
            {
                System.Console.WriteLine($"{header.Key} : {header.Value}");
            }
        }
        public static async Task<string> GetWebContent(string url)
        {
            using var httpClient = new HttpClient(); // use "using" to automaticly remove HttpClient when run out GetWebContent

            try
            {
                // Add request headers
                // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // Get response
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                // Show response headers
                ShowHeaders(httpResponseMessage.Headers);

                // Get content
                string html = await httpResponseMessage.Content.ReadAsStringAsync();
                return html;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return "Error";
            }
        }
        public static async Task<byte[]> DownloadDataBytes(string url)
        {
            using HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                byte[] bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                return bytes;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;
            }
        }
        public static async Task DownloadStream(string url, string filename)
        {
            using HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();

                // Create a temp with 500 bytes
                int SIZEBUFFER = 500;
                var buffer = new byte[SIZEBUFFER];

                // Create a stream (streamwrite) to save read bytes (stream)
                using var streamwrite = File.OpenWrite(filename);

                // read bytes (stream) and save to temp buffer
                bool endread = false;
                do
                {
                    int numberBytes = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                    if (numberBytes == 0) // numberBytes == 0, at the end of stream
                    {
                        endread = true;
                    }
                    else
                    {
                        await streamwrite.WriteAsync(buffer, 0, numberBytes);
                    }
                } while (!endread);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        static async Task Main()
        {
            // 1. Get html
            // var url = "https://github.com/huynhdieutuong";
            // var html = await GetWebContent(url);
            // System.Console.WriteLine(html);

            // 2. Download file
            // string url = "https://raw.githubusercontent.com/xuanthulabnet/learn-cs-netcore/master/imgs/di-02.png";
            // var bytes = await DownloadDataBytes(url);
            // string filename = "1.png";
            // using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            // stream.Write(bytes, 0, bytes.Length);

            // 3. Download file sync
            string url = "https://raw.githubusercontent.com/xuanthulabnet/learn-cs-netcore/master/imgs/di-02.png";
            await DownloadStream(url, "2.png");
        }
    }
}