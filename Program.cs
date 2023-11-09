using System.Net;
using System.Text;

namespace WebProject
{
    class Program
    {
        private static async Task Main()
        {
            var server = new HttpServer();
            await server.StartAsync();
        }
    }
}