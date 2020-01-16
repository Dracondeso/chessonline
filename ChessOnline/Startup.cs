using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChessOnline
{
    public class Startup
    {
        public IConfiguration Configuration { get; } // This method gets called by the runtime. Use this method to add services to the container.

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } //     Represents a set of key/value application configuration properties.


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });// Configure Policy for cookies 

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);//add and set model view control (mvc) version
            //services.AddScoped<ConnectionStart>();
            services.AddTransient<LogInMiddleware>();//add LogInMiddleware
            services.AddTransient<WaitingMiddleware>();//add WaitingMiddleware
        } // add services at startup

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseHttpsRedirection();//Adds middleware fore redirect http request to https
            app.UseStaticFiles();//Enables static file serving for the current request path
            app.UseCookiePolicy();
            //app.UseMiddleware<ConnectionStart>();
            app.UseMiddleware<LogInMiddleware>();
            app.UseMiddleware<WaitingMiddleware>();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });//enable model view control (mvc)
        }
    }
}

