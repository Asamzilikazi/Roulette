using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Data.SqlClient;
using Roulette.Data;
using Microsoft.EntityFrameworkCore;

namespace Roulette
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
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Roulette", Version = "v1" });
            });
            services.AddDbContext<RouletteDbContext>(options =>
        options.UseSqlite(Configuration.GetConnectionString("SQLiteConnection")));
        
        services.AddTransient<BetRepository>();
            services.AddTransient<BetValidator>();
            services.AddTransient<GameService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Use global exception handling middleware for production
                app.UseMiddleware<ExceptionMiddleware>();
                app.UseExceptionHandler("/Home/Error");
      
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "apiRoute",
               pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roulette V1");
                c.RoutePrefix = "api/roulette/swagger"; // Set the base URL for Swagger UI
            });

        }
    }
}
