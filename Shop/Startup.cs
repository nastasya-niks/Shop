using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repository;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {

        private IConfigurationRoot _confstring;

        public Startup(IHostingEnvironment hostEnv) {

            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepozitory>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCar.GetShopCar(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

           
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            

            app.UseHttpsRedirection();

            //для отображения статических файлов(css, картинок и пр.)
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("categoryFilter", "{controller=Cars}/{action}/{category?}", defaults: new { controller = "Cars", action = "List"});
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
               AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
            
        }
    }
}
