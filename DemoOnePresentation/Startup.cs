using BLLayer.interFaces;
using BLLayer.reposatries;
using DAL.Contexts;
using DAL.Models;
using DemoOnePresentation.Profiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoOnePresentation
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
            services.AddControllersWithViews();
            // dependency injection 
            #region generic reposatory
            //services.AddScoped<IEmployeeReposatory, employeeReposatory>(); 
            services.AddScoped<IDepartmentReposatory, departmentReposatory>(); // object at employee at create i think
            #endregion
            services.AddScoped<IUnitOFWork, unitOFWork>();
            //services.AddScoped<UserManager<applicationUser>>();
            services.AddIdentity<applicationUser, IdentityRole>(
                Options =>
                {
                    Options.Password.RequireNonAlphanumeric = true;
                    Options.Password.RequireDigit = true;
                    Options.Password.RequireLowercase = true;
                    Options.Password.RequireUppercase = true;

                }).AddEntityFrameworkStores<MVC_Dbcontext>().AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Options =>
            {
                Options.LoginPath = "Account/login";
                Options.AccessDeniedPath = "Home/error";
            });

            services.AddAutoMapper(M => M.AddProfile(new employeeProfile()));

            services.AddDbContext<MVC_Dbcontext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=login}/{id?}");
            });
        }
    }
}
