using System.Threading.Channels;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRHubClientSample
{
    public class UploadClient
    {
        public async Task ExecuteAsync()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/upload")
                .Build();

            await connection.StartAsync();

            var word = "hello";
            foreach (var i in Enumerable.Range(1, 10000))
            {
                await UploadWord(connection, word);
                await Task.Delay(100);
            }
        }

        public static async Task UploadWord(HubConnection connection, string word)
        {
            var channel = Channel.CreateUnbounded<string>();
            await connection.SendAsync("UploadWord", channel.Reader);

            foreach (var c in word)
            {
                await channel.Writer.WriteAsync(c.ToString());
            }

            channel.Writer.Complete();
        }
    }
}
