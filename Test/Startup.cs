using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Test.Models;
using Test.Repository;

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
            services.AddControllersWithViews();

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(_confString.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<CarRepository>();
            services.AddTransient<CategoryRepository>();
            services.AddTransient<OrdersRepository>();
            services.AddTransient<ShopCartRepository>();
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
