using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SB.Ball3DTournamentSys.Business.Concrete;
using SB.Ball3DTournamentSys.Business.Containers;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.Business.Mappers.AutoMapper;
using SB.Ball3DTournamentSys.DataAccess.Concrete.Contexts;
using SB.Ball3DTournamentSys.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SB.Ball3DTournamentSys.DataAccess.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Entities.Interfaces;
using SB.Ball3DTournamentSys.Web.Initilaizers;

namespace SB.Ball3DTournamentSys.Web
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
            services.AddControllersWithViews().AddFluentValidation();

            services.AddDbContext<B3DTContext>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<B3DTContext>();

            services.AddScopes();

            services.AddFluentValidationTransients();

            services.AddAutoMapper(typeof(Startup));

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "B3DTSCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Login";
                opt.AccessDeniedPath = "/Home";
            });

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;

            });

         

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IGameServerService gameServerService, IStadiumService stadiumService, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager)
        {

            DBDefaultDataInitiliazer.SeedData(gameServerService, stadiumService, _userManager,_roleManager );


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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
