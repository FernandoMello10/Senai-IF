using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SenaiChamados.Application;
using SenaiChamados.Hubs;
using SenaiChamados.Interfaces;
using SenaiChamados.Interfaces.Application;
using SenaiChamados.Domain;
using SenaiChamados.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SenaiChamados.Models;

namespace SenaiChamados
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SenaiChamados", Version = "v1" });
            });
            services.AddSignalR();

            SetupDbContext(services);
            SetupDependencyInjection(services);
            SetupJwtToken(services);
        }

        private static void SetupDbContext(IServiceCollection services)
        {
            var connectionString = "server=localhost;user=root;senha=Senai@132;database=SenaiChamados";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            
            services.AddDbContext<SenaiChamadosContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    // The following three options help with debugging, but should
                    // be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );
        }

        private static void SetupJwtToken(IServiceCollection services)
        {
            services
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })
               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-senaichamados")),
                       ClockSkew = TimeSpan.FromMinutes(30),
                       ValidIssuer = "SenaiChamados",
                       ValidAudience = "SenaiChamados"
                   };
               });
        }

        private static void SetupDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IUsuarioApplication, UsuarioApplication>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IGenericApplication<UsuarioModel>, GenericApplication<UsuarioModel, UsuarioDTO>>();
            services.AddTransient<IGenericApplication<SetorModel>, GenericApplication<SetorModel, SetorDTO>>();

            services.AddTransient<IGenericRepository<UsuarioDTO>, GenericRepository<UsuarioDTO>>();
            services.AddTransient<IGenericRepository<SetorDTO>, GenericRepository<SetorDTO>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SenaiChamados v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChamadoHub>("/chamadohub");
            });
        }
    }
}
