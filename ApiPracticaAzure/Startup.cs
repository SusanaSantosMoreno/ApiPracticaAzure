using ApiPracticaAzure.Data;
using ApiPracticaAzure.Helpers;
using ApiPracticaAzure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticaAzure {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {

            String cadena = this.Configuration.GetConnectionString("SeriesSQL");
            services.AddTransient<RepositorySeries>();
            services.AddTransient<HelperToken>();
            services.AddDbContext<SeriesContext>(options => options.UseSqlServer(cadena));

            services.AddSwaggerGen(options => {
                options.SwaggerDoc(name: "v1", new OpenApiInfo {
                    Title = "Api Series",
                    Version = "v1",
                    Description = "Api Series Pr?ctica Azure 2021"
                });
            });
            HelperToken helpers = new HelperToken(Configuration);
            services.AddAuthentication(helpers.GetAuthOptions()).
                AddJwtBearer(helpers.GetJwtBearerOptions());
            services.AddControllers();
        }


        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api v1");
                options.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
