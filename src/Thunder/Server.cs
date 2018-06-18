using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Thunder
{
    

    public  static partial class Server
    {
        static public void SetViews(string relativePath)
        {
            var folder = Path.Combine(Environment.CurrentDirectory, relativePath);
            DirectoryInfo dir = new DirectoryInfo(folder);

            foreach (var item in Directory.GetFiles(folder, "*.html", SearchOption.AllDirectories))
            {
                FileInfo fi = new FileInfo(item);
                Func<HttpContext, Task> func = async delegate (HttpContext context)
                {
                    await context.Response.WriteAsync(await File.ReadAllTextAsync(item));
                };

                var relativeRoute = fi.FullName.Remove(fi.FullName.Length - fi.Extension.Length, fi.Extension.Length) // remove extension
                                .Remove(0, dir.FullName.Length) // remove fixed path
                                .Replace(Path.DirectorySeparatorChar, '/'); // change path separator

                Get(relativeRoute, func);
            }
        }

        public static void Run()
        {
            var builder = WebHost.CreateDefaultBuilder(null)
                .UseStartup<Runner>();

            builder
                .Build()
                .Run();
        }
    }
}
