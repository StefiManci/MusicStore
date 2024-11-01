using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Models;
using MusicStore.Models.Database;
using MusicStore.Models.Repository;
namespace MusicStore
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["Data:MusicStoreMusics:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration["Data:MusicStoreIdentity:ConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(
               routes =>
               {
                   routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
                   routes.MapRoute(name: "", template: "{controller}/{action}");
                   routes.MapRoute(name: "", template: "{category?}", defaults: "{controller=Home}/{action=Index}");
                   routes.MapRoute(name: "", template: "{detail?}", defaults: "{controller=Home}/{action=Details}");
                   routes.MapRoute(name: "", template: "{controller=Cart}");
                   routes.MapRoute(name: "", template: "{Checkout}", defaults: "{controller=Order}/{action=Checkout}");
                   routes.MapRoute(name: "", template: "{Index}", defaults: "{controller=Store}/{action=Index}");
                   routes.MapRoute(name: "", template: "{Create}", defaults: "{controller=Home}/{action=Index}");
               }
                );
            SeedData.EnsurePopulated(app);
        }
    }
}
