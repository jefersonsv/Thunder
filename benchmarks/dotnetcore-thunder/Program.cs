using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Thunder;

namespace Dotnetcore.Thunder
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Server.Get("/hello", context => context.Response.WriteAsync("Hello from /hello"));
            Server.Run();
        }
    }
}
