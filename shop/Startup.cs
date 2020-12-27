using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shop.DAL.Connect;
using shop.BLL.Repositories;
using shop.BLL.BusinessModel;
using shop.DAL;
using shop.BLL;
using shop.DAL.Interfaces;
using shop.Web.Infrastructure;

namespace shop.Web
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
            services.AddDbContext<ProductContext>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            services.AddTransient<IColorRepository, EFColorRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{category}/CurrentPage{page:int}",
                    defaults: new { Controller = "Product", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "CurrentPage{page:int}",
                    defaults: new { Controller = "Product", action = "Index", page = 1 }
                    );
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{category}",
                    defaults: new { Controller = "Product", action = "Index", page = 1 }
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
