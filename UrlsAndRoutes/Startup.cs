﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing.Constraints;
using UrlsAndRoutes.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{

            //    //routes.MapRoute(
            //    //    name: "MyRoute",
            //    //    template: "{controller=Home}/{action=Index}/{id:int?}");

            //    routes.MapRoute(
            //        name: "MyRoute",
            //        template: "{controller=Home}/{action=Index}/{id:weekday?}");


            //    ////variable-length route
            //    //routes.MapRoute(
            //    //    name: "MyRoute",
            //    //    template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");


            //    ////an alias for a specific URL
            //    //routes.MapRoute(
            //    //    name: "ShopSchema2",
            //    //    template: "Shop/OldAction",
            //    //    defaults: new { controller = "Home", action = "Index" });


            //    //routes.MapRoute("", "X{controller}/{action}");

            //    //routes.MapRoute(
            //    //    name: "default",
            //    //    template: "{controller=Home}/{action=Index}");

            //    //routes.MapRoute(
            //    //    name: "",
            //    //    template: "Public/{controller=Home}/{action=Index}");
            //});
        }
    }
}
