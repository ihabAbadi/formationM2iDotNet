using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnnoncesAspNet.Interface;
using AnnoncesAspNet.Services;
using AnnoncesAspNet.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnnoncesAspNet
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
            services.AddSession((options) =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
            });
            services.AddHttpContextAccessor();
            services.AddSingleton<IUpload, UploadService>();
            services.AddScoped<IFavoris, FavorisService>();
            services.AddScoped<IHash, HashService>();
            services.AddScoped<ILogin, LoginService>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Utilisateur/FormLogin");
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("connectOk", policy =>
                {
                    //policy.RequireClaim(ClaimTypes.Email);
                    policy.Requirements.Add(new ConnectRequirement());
                });
            });
            services.AddSingleton<IAuthorizationHandler, ConnectHandler>();
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
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            //app.UseCookiePolicy(new CookiePolicyOptions() { MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict });
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Annonce}/{action=Index}/{id?}");
            });
        }
    }
}
