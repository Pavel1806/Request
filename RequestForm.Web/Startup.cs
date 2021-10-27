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
using RequestForm.BLL.Interfaces;
using RequestForm.BLL.Services;
using RequestForm.DAL.Context;
using RequestForm.DAL.Interfaces;
using RequestForm.DAL.Repositories;
using RequestForm.Web.ErrorHandling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RequestForm.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
                options.Filters.Add<HttpResponseExceptionFilter>());

            services.AddDbContext<AppDbContext>(x =>
             x.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")
             ));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Request API", 
                    Version = "v1",
                    Description = "API для формы обработки заявок",
                    Contact= new OpenApiContact
                    {
                        Name = "Павел",
                        Email ="pavel.akatev@gmail.com"

                    }
                    
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddCors();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IRequestServices, RequestServices>();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RequestForm v1"));
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpMethodOverride();
            app.UseAuthorization();

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
