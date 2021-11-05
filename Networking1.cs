using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace Networking1
{
    public class Program
    {
        static void Mainx()
        {
            // 1. Uri class
            string url = "https://github.com/huynhdieutuong/learn-csharp?id=123&type=great#section";
            // Can get some info: uri.Scheme (https), uri.Host, uri.Port, uri.LocalPath, uri.Query, uri.Fragment,...
            var uri = new Uri(url);

            // Get all info from Property
            var uritype = typeof(Uri);
            // uritype.GetProperties().ToList().ForEach(property =>
            // {

            //     System.Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            // });

            // 2. Dns static class
            string url2 = "https://www.bootstrapcdn.com/";
            var uri2 = new Uri(url2);
            var ipHostEntry = Dns.GetHostEntry(uri2.Host);
            // System.Console.WriteLine(ipHostEntry.HostName); // Get host name
            // ipHostEntry.AddressList.ToList().ForEach(ip => System.Console.WriteLine(ip)); // Get all ip

            // 3. Ping class
            var ping = new Ping();
            var pingReply = ping.Send("github.com");
            // System.Console.WriteLine(pingReply.Status);
            // if (pingReply.Status == IPStatus.Success)
            // {
            //     System.Console.WriteLine(pingReply.RoundtripTime);
            //     System.Console.WriteLine(pingReply.Address);
            // }
        }
    }
}