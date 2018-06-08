using System;
using Microsoft.AspNetCore.Http;
using Thunder;

namespace HelloWorld
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Startup.GetRoutes.Add("/hello", async context => await context.Response.WriteAsync("Hello from /hello"));
            Server.Run();
        }
    }
}
