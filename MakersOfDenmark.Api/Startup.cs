using System;
using System.IO;
using System.Reflection;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MakersOfDenmark.Services;
using AutoMapper;
using MakersOfDenmark.Api.Extensions;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Services;
using MakersOfDenmark.Services.Settings;

namespace MakersOfDenmark.Api
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
            services.AddControllers();
            services.AddDbContext<MakersOfDenmarkDbContext>(options => options.UseNpgsql(
                Configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly("MakersOfDenmark.Data")));

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<MakersOfDenmarkDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            services.AddAuth(Configuration.GetSection("Jwt").Get<JwtSettings>());
            
            //Add dependency injections
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IMakerspaceService, MakerspaceService>();
            services.AddTransient<IBadgeService, BadgeService>();
            services.AddTransient<IEventService, EventService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Document for Makers of Denmark API", Description = "Shows REST endpoints for interacting with the API", Version = "v1" });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                c.IncludeXmlComments(filePath, true);
            });

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MakersOfDenmarkApi v1"));  

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}