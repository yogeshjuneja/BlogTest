using DataLayer;
using JWTImplementation.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTImplementation
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
           
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtoptions =>
                 {
                     jwtoptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thiismysecretkey")),
                         ValidateIssuerSigningKey = true,
                         ValidateLifetime = false,
                         ClockSkew = TimeSpan.FromMinutes(5),
                     };

                 });

            services.AddControllers();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ISqlDBHelper, SqlDBHelper>();
            services.AddTransient<IAuthenticationManager, AuthenticationManager>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
