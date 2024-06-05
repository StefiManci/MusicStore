using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicStore.Models;
using MusicStore.Models.Database;
using MusicStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore
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
            services.AddMvc(options => options.EnableEndpointRouting=false);
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["Data:MusicStoreMusics:ConnectionString"]));
            services.AddTransient<IAlbumRepository, EFAlbumRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddMemoryCache();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(
               routes=>
               {
                   routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
                   routes.MapRoute(name: "", template: "{controller}/{action}");
                   routes.MapRoute(name: "", template: "{category?}", defaults: "{controller=Home}/{action=Index}");
                   routes.MapRoute(name: "", template: "{detail?}", defaults: "{controller=Home}/{action=Details}");
                   routes.MapRoute(name: "", template: "{controller=Cart}");
                   routes.MapRoute(name: "", template: "{Checkout}", defaults: "{controller=Order}/{action=Checkout}");

               }
                );
            SeedData.EnsurePopulated(app);
        }
       
    }
}
