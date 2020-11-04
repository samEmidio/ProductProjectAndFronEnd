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
using ProductProject.Data;
using Microsoft.EntityFrameworkCore;
using ProductProject.UnitOfWork.Interface;
using AutoMapper;
using ProductProject.Services;
using ProductProject.Services.Interface;

namespace ProductProject
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
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsPolicy", // I introduced a string constant just as a label "AllowAllOriginsPolicy"
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });

            services.AddDbContext<DataContext>(options => 
            options.UseMySql(Configuration.GetConnectionString("DataConnection")));

            services.AddScoped<IUnitOfWork,UnitOfWork.UnitOfWork>();
            services.AddScoped<IImage,ImageService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Producs Api V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAllOriginsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
