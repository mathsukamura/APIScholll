using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Scholl.Data;
using Scholl.Services;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Scholl.Infra;

namespace Scholl
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerConfiguration();

            services.AddSwaggerGen(options =>
             {
                 var jwtKey = Configuration.GetValue<string>("Jwt:Key");
                 if (string.IsNullOrEmpty(jwtKey))
                 {
                     throw new InvalidOperationException("Jwt:Key not found in configuration.");
                 }
                 services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = "Jwt:Issuer", 
                        ValidAudience = "Jwt:audience", 
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                 });
                 //options.SwaggerDoc("v1", new OpenApiInfo { Title = "Scholl", Version = "v1" });
                 options.AddSecurityDefinition(
                     "Bearer",
                     new OpenApiSecurityScheme
                     {
                         Description =
                             "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n"
                             + "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n"
                             + "Exemplo (informar sem as aspas): Bearer 12345abcdef",
                         Name = "Authorization",
                         In = ParameterLocation.Header,
                         Type = SecuritySchemeType.ApiKey,
                         Scheme = "Bearer",
                         BearerFormat = "JWT",
                     }
                 );
                 options.AddSecurityRequirement(
                     new OpenApiSecurityRequirement
                     {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
                     }
                 );
             });

            DependencyInjection.ConfigureInterfaces(services);

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Jwt:Key"));


            services.AddDbContext<AppDbcontext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default"));
                


            },ServiceLifetime.Scoped);
            services.AddControllers()
                .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 64;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CustomPolicy", policy =>
                {
                    policy.Requirements.Add(new CustomAuthorizationRequirement("/minha-url"));
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerConfiguration();

            app.UseRouting();

            app.UseMiddleware<MiddlewareAuthentication>();

            app.UseMiddleware<MyAuthorizeMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=index}/{id?}");

            });
        }
    }
}
