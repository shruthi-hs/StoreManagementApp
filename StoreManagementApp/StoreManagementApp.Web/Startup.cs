using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoreManagementApp.BLL;
using StoreManagementApp.BLL.Interface;
using StoreManagementApp.DAL;
using StoreManagementApp.DAL.Interface;
using StoreManagementApp.Models;
using StoreManagementApp.Web.Models.DBContext;
using StoreManagementSystem.DAL;

namespace StoreManagementApp.Web
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
            services.AddControllers();
            services.AddSingleton<IItemRepository, ItemRepository>();

            services.AddCors(o => o.AddPolicy("corspolicy", builder =>
               {
                   builder.AllowAnyMethod()
                   .AllowAnyHeader()
                   .WithOrigins("http://localhost:5000");
               }));

            services.AddDbContext<InventoryDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("InventoryDBConnection"));
            });


            services.AddTransient<IProductDAL, ProductDAL>();
            services.AddTransient<IProductBLL, ProductBLL>();
            services.AddTransient<IStaffDAL, StaffDAL>();
            services.AddTransient<IStaffBLL, StaffBLL>();
            services.AddTransient<IStockDAL, StockDAL>();
            services.AddTransient<IStockBLL, StockBLL>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}