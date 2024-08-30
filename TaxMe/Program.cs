using Microsoft.EntityFrameworkCore;
using TaxMeData.Context;
using TaxMeRepository.Interfaces;
using TaxMeRepository.Repositories;

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
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();  // whene you work in on stait
            //builder.Services.AddSingleton<ILocationRepository, LocationRepository>();


            builder.Services.AddScoped<IRideRequestRepository, RideRequestRepository>();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
