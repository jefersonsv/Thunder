using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Thunder
{
    internal class Runner
    {
        //private static void HandleMapTest1(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Map Test 1");
        //    });
        //}


        // https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.1&tabs=aspnetcore2x
        public void Configure(IApplicationBuilder app)
        {
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd delegate.3");

            //    // Do work that doesn't write to the Response.
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});


            //app.Map("/map1", HandleMapTest1);

            //app.MapWhen(context => context.Request.Query.ContainsKey("branch"),
            //                   HandleBranch);



            app.Run(async (context) =>
            {
                var found = false;
                // routes
                foreach (var item in Server.Routes[context.Request.Method])
                {
                    if (item.Key(context.Request.Path))
                    {
                        found = true;
                        await item.Value(context);
                        break;
                    }
                }

                // Notfound
                if (!found)
                    context.Response.StatusCode = 404;
            });

            /*
            app.Run(async context =>
            {
                if (context.Request.Path.Value == "/hello")
                    await context.Response.WriteAsync("Hello from /hello");
            });*/
        }

    }
}
