using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core_App.Models;
using Microsoft.Extensions.Configuration;

namespace Core_App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        
        
        //Connnection String Using Json
        public IConfiguration configuration;

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Use dbcontext + New Connection String
            // services.AddDbContext<CompanyContext>(o=>o.UseSqlServer("Server=.; Database=CoreApp;Trusted_Connection=true"));


            //Connnection String Using Json
            services.AddDbContext<CompanyContext>(o => o.UseSqlServer(configuration.GetConnectionString("CompanyDb")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default","{Controller=Home}/{Action=Index}/{id?}");
            });
        }
    }
}
