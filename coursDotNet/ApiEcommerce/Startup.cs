using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Interface;
using Ecommerce.Models;
using Ecommerce.Services;
using Ecommerce.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ApiEcommerce
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
            services.AddScoped<IHash, HashService>();
            services.AddScoped<IUpload, UploadService>();
            
            services.AddScoped<IAuthorizationHandler, RoleHandler>();
            services.AddScoped<IDisplayer, DisplayService>();
            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy("AcceptAll", (builder) =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                });
            });

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
                    policy.Requirements.Add(new RoleRequirement(new Erole() { Role = "admin" }));
                });
            });
            services.AddScoped<IAuthorizationHandler, RoleHandler>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer((options) =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = "m2i",
                    ValidateAudience = true,
                    ValidAudience = "m2i",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bonjour tout le monde"))
                };
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
