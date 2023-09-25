using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.Net;

namespace SignalRHubClientSample
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var uploadClient = new UploadClient();
            await uploadClient.ExecuteAsync();
        }
    }
}