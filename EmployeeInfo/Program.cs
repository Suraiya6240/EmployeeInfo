using EmployeeInfo.Data;
using EmployeeInfo.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //database connection/inject dependency
            builder.Services.AddDbContext<EmployeeDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbConnectionString")));

            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IImgRepo,ImageRepo>();
            builder.Services.AddScoped<IDeptRepo, DeptRepo>();

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
