using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;
using AutoMapper;// objektu transformācijai no viena objekta tipa uz otru
using VDB.Models;
using VDB.Data;

namespace VDB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));// klašu (objektu) pārveidei

            services
                //.AddControllersWithViews()
                .AddControllers()// Kontrolieri BEZ view
                .AddNewtonsoftJson();
               



            services.AddDbContext<DataContextAR>(options => options.UseSqlServer(Configuration.GetConnectionString("JobConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            /*UseEndpoints adds endpoint execution to the middleware pipeline.
            It runs the request delegate that serves the endpoint's response.
            UseEndpoints is also where route endpoints are configured that can be matched and executed by the app.*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//no REST API

                endpoints.MapControllerRoute(// no MVC Views
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
