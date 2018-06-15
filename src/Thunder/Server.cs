using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Thunder
{
    public class KeyValuePairList<Tkey, TValue> : List<KeyValuePair<Tkey, TValue>>
    {
        public void Add(Tkey key, TValue value)
        {
            base.Add(new KeyValuePair<Tkey, TValue>(key, value));
        }
    }

    public static class Server
    {
        internal static readonly Dictionary<string, KeyValuePairList<Predicate<string>, Func<HttpContext, Task>>> Routes = new Dictionary<string, KeyValuePairList<Predicate<string>, Func<HttpContext, Task>>>();

        static void SetupMethods()
        {
            new string[] { "GET", "HEAD", "POST", "PUT", "DELETE", "CONNECT", "OPTIONS", "TRACE", "PATCH" }.ToList().ForEach(e =>
                    Routes.TryAdd(e, new KeyValuePairList<Predicate<string>, Func<HttpContext, Task>>())
            );
        }

        static public void Get(string pathRoute, Func<HttpContext, Task> action)
        {
            pathRoute = pathRoute.StartsWith("/") ? pathRoute : "/" + pathRoute;
            SetupMethods();
            Routes["GET"].Add(s => s.Equals(pathRoute, StringComparison.InvariantCultureIgnoreCase), action);
        }

        static public void Post(string pathRoute, Func<HttpContext, Task> action)
        {
            pathRoute = pathRoute.StartsWith("/") ? pathRoute : "/" + pathRoute;
            SetupMethods();
            Routes["POST"].Add(s => s.Equals(pathRoute, StringComparison.InvariantCultureIgnoreCase), action);
        }

        static public void GetRegex(string regex, Func<HttpContext, Task> func)
        {
            regex = regex.StartsWith("/") ? regex : "/" + regex;
            SetupMethods();
            Routes["GET"].Add(s => new Regex(regex, RegexOptions.Compiled).IsMatch(s), func);
        }

        static public void PostRegex(string regex, Func<HttpContext, Task> func)
        {
            regex = regex.StartsWith("/") ? regex : "/" + regex;
            SetupMethods();
            Routes["POST"].Add(s => new Regex(regex, RegexOptions.Compiled).IsMatch(s), func);
        }

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

        static public void Run()
        {
            WebHost.CreateDefaultBuilder(null)
                .UseStartup<Runner>()
                .Build()
                .Run();
        }
    }
}
