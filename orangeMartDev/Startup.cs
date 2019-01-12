using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using orangeMartDev.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace orangeMartDev
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
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(@"Data Source=PROGRAMMING\SQLEXPRESS;Initial Catalog=orangeMart;Integrated Security=True", b=> b.UseRowNumberForPaging()));
            services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=orangeMart;Integrated Security=True", b => b.UseRowNumberForPaging()));
            //options.UseSqlServer(Configuration.GetConnectionString("HomeConnection")));
            options.UseSqlServer(Configuration.GetConnectionString("WorkConnection")));



            services.AddMvc();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Orange Mart API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Cors");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orange Mart API");
            });

            app.UseMvc();
        }
    }
}
