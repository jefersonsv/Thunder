using System;
using Microsoft.AspNetCore.Http;
using Thunder;

namespace Startup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server.Get("/hello", context => context.Response.WriteAsync("Hello from /hello"));
            Server.Run();
        }
    }
}
