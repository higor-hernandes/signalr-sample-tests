using System.Net;
using Microsoft.AspNetCore;

namespace SignalRHubSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder()
                .UseKestrel((_, options) =>
                {
                    options.Listen(IPAddress.Any, 5000);
                })
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}