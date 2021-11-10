using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Models;
using Test.Models.Repository;

namespace Test
{
    public class Startup
    {
        public IConfigurationRoot _confString;

        [Obsolete]
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _confString = new ConfigurationBuilder().
                SetBasePath(hostingEnvironment.ContentRootPath).
                AddJsonFile("dbsettings.json").
                Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(_confString.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddControllersWithViews();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                DBObjects.Initial(context);
            }
        }
    }
}
