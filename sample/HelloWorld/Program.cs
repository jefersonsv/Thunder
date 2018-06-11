using System;
using Microsoft.AspNetCore.Http;
using Thunder;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server.AddRoutesGet.Add("", context => context.Response.WriteAsync(context.Connection.RemoteIpAddress?.ToString()));
            Server.AddRoutesGet.Add("/hello", async context => await context.Response.WriteAsync("Hello from /hello"));

            ServerBuilder.Run();
        }
    }
}
