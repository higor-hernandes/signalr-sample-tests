using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
using Microsoft.AspNetCore.SignalR;

namespace SignalRHubSample
{
    public class UploadHub : Hub
    {
        public async Task UploadWord(ChannelReader<string> source)
        {
            var sb = new StringBuilder();

            while (await source.WaitToReadAsync())
            {
                while (source.TryRead(out var item))
                {
                    Debug.WriteLine($"received: {item}");
                    Console.WriteLine($"received: {item}");
                    sb.Append(item);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
