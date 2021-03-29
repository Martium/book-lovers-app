using System;
using Martium.BookLovers.Api.Host.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Martium.BookLovers.Api.Host
{
    public class Startup
    {
        private static readonly DatabaseInitializerRepository DatabaseInitializerRepository = new DatabaseInitializerRepository();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Book Lovers API",
                    Description = "A simple CRUD API for favorite authors and books management",
                    Contact = new OpenApiContact
                    {
                        Name = "Martynas Gedutis",
                        Email = null,
                        Url = new Uri("https://github.com/Martium"),
                    },
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DatabaseInitializerRepository.InitializeDatabaseIfNotExist();
        }
    }
}
