using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RetroVideoData.Models;
using RetroVideoData.Repositories;
using RetroVideoServices;
using Microsoft.AspNetCore.Http;

namespace Retrovideo
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
            
            services.AddDbContext<RetrovideoDBContext>(options =>
           options.UseSqlServer(
            Configuration.GetConnectionString("RetroVideoConnection"),
            x => x.MigrationsAssembly("RetroVideoData")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddTransient<ReservatieService>();
            
            services.AddTransient<KlantServices>();
            services.AddTransient<FilmServices>();
            services.AddTransient<GenresServices>();
            services.AddTransient<IReservatieRepository, SQLReservatieRepository>();
            services.AddTransient<IKlantRepository, SQLKlantRepository>();
            services.AddTransient<IFilmRepository, SQLFilmRepository>();
            services.AddTransient<IGenreRepository, SQLGenresRepository>();
             services.AddControllersWithViews();
            
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
