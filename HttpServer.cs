using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WebProject.Configuration;
using WebProject.Handler;

namespace WebProject
{
    public class HttpServer
    {
        private HttpListener _listener = new();
        private CancellationTokenSource cts = new();
        private AppSettingsConfig _config = Configuration.ServerConfiguration.Config;
        private Handler.Handler _staticFileHandler = new StaticFileHandlers();
       // private Handler.Handler _controllerHandler = new ControllerHandler();

        public HttpServer()
        {
            _listener.Prefixes.Add($"{_config.Address}:{_config.Port}/");
            Console.WriteLine($"Server has been started: {_config.Address}:{_config.Port}/");
        }

        public async Task StartAsync()
        {
            var token = cts.Token;
            await Task.Run(() => Run(token), token);
        }

        private async Task Run(CancellationToken token)
        {
            _listener.Start();
            Task.Run(ProcessCallback);

            try
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();

                    var context = await _listener.GetContextAsync();
                //    _staticFileHandler.Successor = _controllerHandler;
                    _staticFileHandler.HandleRequest(context);
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _listener.Close();
                ((IDisposable)_listener).Dispose();
                Console.WriteLine("Server has been stopped.");
            }
        }

        private void ProcessCallback()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input != "stop") continue;
                cts.Cancel();
                break;
            }
        }
    }
}
