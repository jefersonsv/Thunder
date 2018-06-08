using System;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Thunder
{
    public class Server
    {
        public class GetHandler
        {
            //Startup.GetRoutes.Add("hello", context => context.Response.WriteAsync("Hello from /hello"));
        }

        public static GetHandler Get { get; set; }

        public static void Run()
        {
            Startup.CallingAssembly = Assembly.GetCallingAssembly();


            WebHost.CreateDefaultBuilder(null)
                .UseStartup<Startup>()
                //.UseKestrel(options =>
                //{
                //    options.Listen(IPAddress.Loopback, 5002);
                //    //options.ListenAnyIP(5002);
                //    //options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                //    //{
                //    //    listenOptions.UseHttps("testCert.pfx", "testPassword");
                //    //});
                //})
                // .ConfigureLogging(a =>
                // {
                //     a.Services.Clear();
                // })
                .Build()
                .Run();
        }
    }
}
