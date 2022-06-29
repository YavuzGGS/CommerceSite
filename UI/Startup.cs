using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Helpers;

namespace UI
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
            services.AddSingleton<IUserDal, EfUserDal>(); //Dependency Injection
            services.AddSingleton<IUserService, UserManager>(); //Dependency Injection
            services.AddSingleton<IProductDal, EfProductDal>(); //Dependency Injection
            services.AddSingleton<IProductService, ProductManager>(); //Dependency Injection
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartSessionHelper, CartSessionHelper>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => //Enabling Cookie Auth
            {
                options.AccessDeniedPath = "/Home/AccessDenied";
            });
            services.AddDistributedMemoryCache(); //This way ASP.NET Core will use a Memory Cache to store session variables
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
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

            app.UseSession(); // Enabling middleware for sessions
            app.UseRouting();
            app.UseAuthentication(); //Need for cookie auth
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{Id?}");
            });
        }
    }
}
