using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TaxMeData.Context;
using TaxMeData.Models;
using TaxMeRepository.Interfaces;
using TaxMeRepository.Repositories;
using TaxMeService.interfaces;
using TaxMeService.Mapping;
using TaxMeService.Services.Locations;
using TaxMeService.Services.Servic;

namespace TaxMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TaxMeDbContext>(options => {

               options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection"));
            
            });

            //builder.Services.AddTransient<ILocationRepository,LocationRepository>();

            //builder.Services.AddSingleton<ILocationRepository, LocationRepository>();

            //builder.Services.AddScoped<ILocationRepository, LocationRepository>();  // whene you work in on stait

            builder.Services.AddScoped<IUnitOfwork, UnitOfwork>();

            builder.Services.AddScoped<ILocationService, LocationtService>();
            builder.Services.AddScoped<IRideRequestService, RideRequestService>();

            builder.Services.AddAutoMapper(X => X.AddProfile(new RideRequestProfile()));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.Password.RequiredUniqueChars = 2;
                config.Password.RequireDigit = true;
                config.Password.RequireLowercase = true;
                config.Password.RequireUppercase = true;
                config.Password.RequireNonAlphanumeric = true;
                config.Password.RequiredLength = 6;
                config.User.RequireUniqueEmail = true;
                config.Lockout.AllowedForNewUsers = true;
                config.Lockout.MaxFailedAccessAttempts = 3;
                config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
            }).AddEntityFrameworkStores<TaxMeDbContext>()
              .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
                options.LoginPath = "/Account/login";
                options.LogoutPath = "/Account/login";
                options.AccessDeniedPath = "/Account/AccessDenide";
            
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=SignUp}");

            app.Run();

          
        }
    }
}
