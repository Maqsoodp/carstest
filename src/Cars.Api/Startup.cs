using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cars.Domain;
using Cars.Domain.Contracts;
using Cars.Domain.Repositories;
using Cars.Kloud.Api;
using Cars.Kloud.Api.HttpHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Cars.Api
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
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddDbContext<CarsDbContext>(options => options.UseInMemoryDatabase("CarsDb"));

            services.AddScoped<CarsDbContext>();
            services.AddTransient<DbInit>();



            var config = new ApiConfiguration();
            Configuration.Bind("ApiConfig", config);
            services.AddSingleton(config);


            services.AddSingleton<IHttpClientHandler, HttpClientHandler>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerCarsRepository, OwnerCarsRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("cars", new Info { Title = "owner cars Rest API", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInit dbInit, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/cars/swagger.json", "owner cars Rest API");
            });

            app.UseMvc();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            dbInit.Load();
        }

    }
}
