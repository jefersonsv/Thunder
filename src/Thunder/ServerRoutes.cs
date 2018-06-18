using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Thunder
{
    public static partial class Server
    {
        internal static readonly Dictionary<string, KeyValuePairList<Predicate<string>, Func<HttpContext, Task>>> Routes = new Dictionary<string, KeyValuePairList<Predicate<string>, Func<HttpContext, Task>>>();

        static void SetupMethods()
        {
            new string[] { "GET", "HEAD", "POST", "PUT", "DELETE", "CONNECT", "OPTIONS", "TRACE", "PATCH" }.ToList().ForEach(e =>
                    Routes.TryAdd(e, new KeyValuePairList<Predicate<string>, Func<HttpContext, Task>>())
            );
        }

        public static void Verb(string verb, string pathRoute, Func<HttpContext, Task> action)
        {
            pathRoute = pathRoute.StartsWith("/") ? pathRoute : "/" + pathRoute;
            SetupMethods();
            Routes[verb].Add(s => s.Equals(pathRoute, StringComparison.InvariantCultureIgnoreCase), action);
        }

        static public void Get(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("GET", pathRoute, func);
        }

        static public void Post(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("POST", pathRoute, func);
        }

        static public void Head(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("HEAD", pathRoute, func);
        }

        static public void Put(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("PUT", pathRoute, func);
        }

        static public void Delete(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("DELETE", pathRoute, func);
        }

        static public void Connect(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("CONNECT", pathRoute, func);
        }

        static public void Options(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("OPTIONS", pathRoute, func);
        }

        static public void Trace(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("TRACE", pathRoute, func);
        }

        static public void Patch(string pathRoute, Func<HttpContext, Task> func)
        {
            Verb("PATCH", pathRoute, func);
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
    }
}
