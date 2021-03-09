using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRG.Core.Services;
using HRM.Core.Interfaces.Services;
using HRM.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using HRM.Core.Entities;
using HRM.Core.Interfaces.Repositories;
using HRM.Core.Services;
using HRM.Infrastructure.Repositories;


namespace HRM.UI
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
            //use sql server
            services.AddDbContext<HRMDbContext>(
                options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"),
                        m => m.MigrationsAssembly("HRM.Infrastructure")));

            // use sqlite
            // services.AddDbContext<HRMDbContext>(
            //     options => options.UseSqlite("Data Source=HRM-dev.db")
            // );
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();

            #region Inject services

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IHumanResourceService, HumanResourceService>();
            services.AddAutoMapper(typeof(Startup));

            #endregion
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}