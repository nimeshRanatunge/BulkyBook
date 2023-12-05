using BlukyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace BlukyBookWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //:add Razor Pages support
            builder.Services.AddRazorPages();
            //configure DbContext with connection string
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // :shows user friendly exceptions 
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //:1
                app.UseHsts();
            }
            //middleware used to automatically redirect HTTP requests to their corresponding HTTPS
            app.UseHttpsRedirection();
            //middleware to use static files defined the root folder
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //action representing the method or action within the specified controller
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}