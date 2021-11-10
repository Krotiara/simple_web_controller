using controller.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace controller
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection)); //or protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) в контексте.
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();// Подключение EndpointRoutingMiddleware (определяет конечную точку, которая будет обрабатывать текущий запрос). В частности, в рамках MVC мы также можем использовать два подхода к определению системы маршрутизации.
                             // Первый представляет определение и использование конечных точек с помощью компонентов EndpointRoutingMiddleware и EndpointMiddleware и встраивающих их методов UseRouting и UseEndpoints. 

            app.UseAuthorization();
            //// Подключение EndpointMiddleware
            /////А метод app.UseEndpoints встраивает компонент EndpointMiddleware, который определяет набор конечных точек, которые будут сопоставляться с определенными маршрутами и будут обрабатывать соответствующие маршрутам входящие запросы.
            app.UseEndpoints(endpoints =>
            {
                // определение маршрутов
                //Для добавления маршрута, который будет сопоставляться с конечными точками, применяется метод MapControllerRoute()
                endpoints.MapControllerRoute( //Настройки маршрутизации приложения.
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); //~ запрос к приложению должен иметь двух-трехсегментную структуру.
            });
        }
    }
}
