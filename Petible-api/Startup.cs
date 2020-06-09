using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Petible_api.NHibernate;
using Petible_api.Interfaces;
using Petible_api.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AspNetCore.Firebase.Authentication;
using Microsoft.Net.Http.Headers;
using Google.Protobuf.WellKnownTypes;
using System.Text.RegularExpressions;

namespace Petible_api
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
            services.AddCors();
            services.AddControllers(options =>
            {
                //Respecting Accept Header of browser for type of content to return
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Petible API", Version = "v1" });
            });

            //services.AddNHibernate(connectionString);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/petible-4ec74";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/petible-4ec74",
                        ValidateAudience = true,
                        ValidAudience = "petible-4ec74",
                        ValidateLifetime = true
                    };
                });
            //Setup Unit of Work 
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var sessionFactory = SessionFactory.Init(connectionString);
            services.AddSingleton(factory => sessionFactory);
            services.AddScoped<IUnitOfWork, NHUnitOfWork>();
            services.AddTransient<IUserInfoRepository, UserInfoRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPetRepository, PetRepository>();
            services.AddTransient<IAnimalShelterRepository, AnimalShelterRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IMatchesRepository, MatchesRepository>();
            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Petible API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
