using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Interface;
using Ecommerce.Models;
using Ecommerce.Services;
using Ecommerce.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ecommerce
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
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
            });
            //Ajouter un service
            //services.AddTransient<IUpload, UploadService>();
            services.AddScoped<IUpload, UploadService>();
            services.AddScoped<IDisplayer, DisplayService>();
            services.AddScoped<ITranslate, TranslateService>();
            services.AddScoped<IHash, HashService>();
            services.AddSingleton<ILog, LogService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("customer", policy =>
                {
                    //policy.RequireClaim(ClaimTypes.Email);
                    policy.Requirements.Add(new RoleRequirement());
                });
                options.AddPolicy("admin", policy =>
                {
                    //policy.RequireClaim(ClaimTypes.Email);
                    policy.Requirements.Add(new RoleRequirement(new Erole() { Role = "admin"}));
                });
            });
            services.AddScoped<IAuthorizationHandler, RoleHandler>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new PathString("/User/Form");
                options.ReturnUrlParameter = "route";
                options.AccessDeniedPath = new PathString("/User/Denied");
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            });
            //services.AddSingleton<IUpload, UploadService>();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
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
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}/{qty?}");
            });
        }
    }
}
