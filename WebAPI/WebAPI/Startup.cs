using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Database;

namespace WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();




            // ===================================== MAPEAMENTO DE BANCO DE DADOS =====================================
            /*
             * Para Obter essa string de conexão, é só ir em Exibir > SQL Object Explorer > Clicar no (localdb) > Propriedades.
             *  Data Source = Nome do servidor do banco de dados.
             *  Catalog = Nome do banco propriamente dito. (Por padrão vem master)
             */

            // Pegando a string de conexão que está em appsettings.json e utilizando aqui.
            // var connectionSqlServer = Configuration.GetSection("ConnectionStrings").GetValue<string>("SQL_SERVER");
            var connectionPgSql = Configuration.GetSection("ConnectionStrings").GetValue<string>("PGSQL");

            /* 
             * PARA SQL SERVER => services.AddDbContext<Contexto>(options => options.UseSqlServer(connection));
             * 
             * PARA POSTGRES => {
             * services.AddEntityFrameworkNpgsql();
             * services.AddDbContext<Contexto>(options => options.UseNpgsql(connection));
             * }
             * 
             */

            // Conectando com banco de dados propriamente dito.
            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<Contexto>(options => options.UseNpgsql(connectionPgSql));


            // A cada nova requisição, cria-se um novo contexto.
            services.AddScoped<Contexto>();

            // ================================ FIM MAPEAMENTO DE BANCO DE DADOS =====================================


            // ===================================== JWT =====================================
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Gabriel",
                        ValidAudience = "Gabriel",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("Token invalido!!");
                            return Task.CompletedTask;
                        },

                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("TOKEN VALIDO");
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
