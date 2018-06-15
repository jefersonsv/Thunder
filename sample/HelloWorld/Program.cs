using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Thunder;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server.Get("/hello", context => context.Response.WriteAsync("Hello from /hello"));
            Server.SetViews(".\\wwwroot");
            Server.Run();
        }
    }
}
