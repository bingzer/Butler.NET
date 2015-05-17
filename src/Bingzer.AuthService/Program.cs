using System;
using Microsoft.Owin.Hosting;

namespace Bingzer.StickDraw.AuthService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:9998"))
            {
                Console.Title = "OAuth Server";
                Console.WriteLine("Starting OAuth Server...");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }
}
