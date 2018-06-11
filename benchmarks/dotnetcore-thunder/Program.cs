using System;
using Microsoft.AspNetCore.Http;
using Thunder;

namespace Dotnetcore.Thunder
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Server.AddRoutesGet.Add("/hello", async context => await context.Response.WriteAsync("Hello from /hello"));
            ServerBuilder.Run();
        }
    }
}
