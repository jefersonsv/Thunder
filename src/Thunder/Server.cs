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
    public class Server
    {
        public static Assembly CallingAssembly { get; set; }

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters() // https://offering.solutions/blog/articles/2017/02/07/difference-between-addmvc-addmvcore/
                .AddApplicationPart(CallingAssembly) // https://stackoverflow.com/questions/37725934/asp-net-core-mvc-controllers-in-separate-assembly
                .AddControllersAsServices();
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);            
        }


        /// <summary>
        /// https://docs.microsoft.com/pt-br/aspnet/core/mvc/controllers/routing?view=aspnetcore-2.1
        /// https://radu-matei.com/blog/aspnet-core-routing/
        /// https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-2.1
        /// </summary>
        public readonly static Dictionary<string, RequestDelegate> AddRoutesGet = new Dictionary<string, RequestDelegate>();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //app.UseHttpsRedirection();

            //loggerFactory.m

            // Serve my app-specific default file, if present.
            /*
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("mydefault.html");
            app.UseDefaultFiles(options);
            */


            RouteBuilder routes = new RouteBuilder(app);
            foreach (var item in AddRoutesGet)
                routes.MapGet(item.Key, item.Value);

            app.UseRouter(routes.Build());
            app.UseMvc();
        }
    }
}
