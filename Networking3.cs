using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Networking3
{
    public class Program
    {
        class MyHttpServer
        {
            private HttpListener listener;
            public MyHttpServer(string[] prefixes)
            {
                if (!HttpListener.IsSupported)
                {
                    throw new System.Exception("HttpListener is not supported");
                }

                listener = new HttpListener();

                foreach (string prefix in prefixes)
                {
                    listener.Prefixes.Add(prefix);
                }
            }
            public async Task Start()
            {
                listener.Start();
                System.Console.WriteLine("Http Server Started");

                do
                {
                    System.Console.WriteLine(DateTime.Now.ToLongTimeString() + " waiting a client connect");
                    var context = await listener.GetContextAsync();

                    await ProcessRequest(context);

                    System.Console.WriteLine(DateTime.Now.ToLongTimeString() + " client connected");
                } while (listener.IsListening);
            }
            async Task ProcessRequest(HttpListenerContext context)
            {
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                System.Console.WriteLine($"{request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");

                var outputStream = response.OutputStream;

                switch (request.Url.AbsolutePath)
                {
                    case "/":
                        {
                            var buffer = Encoding.UTF8.GetBytes("Hello");
                            response.ContentLength64 = buffer.Length;
                            await outputStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        break;
                    case "/json":
                        {
                            response.Headers.Add("Content-Type", "application/json");

                            var product = new
                            {
                                Name = "Macbook Pro",
                                Price = 2000
                            };
                            var json = JsonConvert.SerializeObject(product);

                            var buffer = Encoding.UTF8.GetBytes(json);
                            response.ContentLength64 = buffer.Length;
                            await outputStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        break;
                    case "/image2":
                        {
                            response.Headers.Add("Content-Type", "image/png");
                            var buffer = await File.ReadAllBytesAsync("2.png");
                            response.ContentLength64 = buffer.Length;
                            await outputStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        break;
                    default:
                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            var buffer = Encoding.UTF8.GetBytes("Not found");
                            response.ContentLength64 = buffer.Length;
                            await outputStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        break;
                }

                outputStream.Close();
            }
        }
        static async Task Main()
        {
            var server = new MyHttpServer(new string[] { "http://127.0.0.1:8080/" });
            await server.Start();
        }
    }
}