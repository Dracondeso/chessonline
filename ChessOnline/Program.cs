using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ChessOnline.Networking;
using System.Net;
namespace ChessOnline.Networking
{
    class Program
    {
        private static ClientSocket ClientSocket = new ClientSocket();

        static void Main(string[] args)
        {
            ClientSocket.Connect("192.168.28.10", 6556);
                while (true)
            {
                Console.ReadLine();
                CreateWebHostBuilder(args).Build().Run();
            }
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
