using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Networking2
{
    public class MyHttpClientHandler : HttpClientHandler
    {
        public MyHttpClientHandler(CookieContainer cookie_container)
        {
            CookieContainer = cookie_container;
            AllowAutoRedirect = false;
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            UseCookies = true;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("Start connect " + request.RequestUri.ToString());
            // Access server
            var response = await base.SendAsync(request, cancellationToken);
            System.Console.WriteLine("Complete load data");
            return response;
        }
    }
    public class ChangeUri : DelegatingHandler
    {
        public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var host = request.RequestUri.Host.ToLower();
            System.Console.WriteLine($"Check in ChangeUri - {host}");
            if (host.Contains("google.com"))
            {
                request.RequestUri = new Uri("https://github.com/"); // Change request url to github.com
            }
            return base.SendAsync(request, cancellationToken); // Transfer to base (innerHandler)
        }
    }
    public class DenyAccessFacebook : DelegatingHandler
    {
        public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var host = request.RequestUri.Host.ToLower();
            System.Console.WriteLine($"Check in DenyAccessFacebook - {host}");
            if (host.Contains("facebook.com"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Can not access"));
                return await Task.FromResult<HttpResponseMessage>(response);
            }
            return await base.SendAsync(request, cancellationToken); // Transfer to base (innerHandler)
        }
    }
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
        static async Task Mainx()
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
            // string url = "https://raw.githubusercontent.com/xuanthulabnet/learn-cs-netcore/master/imgs/di-02.png";
            // await DownloadStream(url, "2.png");

            // ======================= SendAsync ===================
            string url = "https://facebook.com";
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

            // 1. Payload List to Json = { key1: value1, key2: [value2-1, value2-2] }
            // var parameters = new List<KeyValuePair<string, string>>();
            // parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
            // parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            // parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));
            // var content = new FormUrlEncodedContent(parameters);

            // 2. Payload in Json
            // string data = @"{
            //     ""key1"": ""value1"",
            //     ""key2"": [""value2-1"", ""value-2-2""]
            // }";
            // System.Console.WriteLine(data);
            // var content = new StringContent(data, Encoding.UTF8, "application/json");

            // 3. Payload: Upload file + Json
            var content = new MultipartFormDataContent();
            Stream fileStream = File.OpenRead("1.txt");
            var fileUpload = new StreamContent(fileStream);
            content.Add(fileUpload, "fileupload", "abc.xyz");
            content.Add(new StringContent("value1"), "key1");

            // Add payload
            httpRequestMessage.Content = content;

            // Setup SocketsHttpHandler. If not setup, HttpClient get default handler.
            // var cookies = new CookieContainer();
            // using var handler = new SocketsHttpHandler();
            // handler.AllowAutoRedirect = true;
            // handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            // handler.UseCookies = true;
            // handler.CookieContainer = cookies;

            // Create handler chain
            var cookies = new CookieContainer();
            var bottomHandler = new MyHttpClientHandler(cookies);
            var changeUriHandler = new ChangeUri(bottomHandler);
            var denyAccessFacebookHandler = new DenyAccessFacebook(changeUriHandler);

            using var httpClient = new HttpClient(denyAccessFacebookHandler);
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            // cookies.GetCookies(new Uri(url)).ToList().ForEach(c => System.Console.WriteLine($"{c.Name} : {c.Value}"));

            ShowHeaders(httpResponseMessage.Headers);
            var html = await httpResponseMessage.Content.ReadAsStringAsync();
            System.Console.WriteLine(html);
        }
    }
}