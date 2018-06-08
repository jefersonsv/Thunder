using System;
using System.Collections.Generic;
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
    public class Startup
    {
        public static Assembly CallingAssembly { get; set; }

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // https://stackoverflow.com/questions/37725934/asp-net-core-mvc-controllers-in-separate-assembly
            services.AddMvc();
            

                //.AddMvc()
                //.AddApplicationPart(CallingAssembly)
                //.AddControllersAsServices()
                //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        //Startup.GetRoutes = new Dictionary<string, RequestDelegate>();
        //public static IDictionary<string, RequestDelegate> GetRoutes { get; set; }
        public static IDictionary<string, RequestDelegate> GetRoutes = new Dictionary<string, RequestDelegate>();

        public static Action<IRouteBuilder> ConfigureRoutes { get; set; }

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
            foreach (var item in GetRoutes)
                routes.MapGet(item.Key, item.Value);

            app.UseRouter(routes.Build());

            app.UseMvc();
        }
    }
}
