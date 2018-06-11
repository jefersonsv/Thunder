using System;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Thunder
{
    public class ServerBuilder
    {
        public static void Run()
        {
            // used to grab controller for routes
            Server.CallingAssembly = Assembly.GetCallingAssembly();

            WebHost.CreateDefaultBuilder(null)
                .UseStartup<Server>()
                .Build()
                .Run();
        }
    }
}
