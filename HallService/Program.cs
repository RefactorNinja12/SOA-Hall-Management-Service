
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace HallService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var scalarSettings = builder.Configuration.GetSection("ScalarAPI");
            

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddCors(options =>
            {
            options.AddPolicy("AllowAll",
               builder => builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader());

            });
            

            builder.Services.AddControllers();
          
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<HallManagementDbContext>(options =>
            options.UseSqlServer(connectionString));
            var app = builder.Build();

           
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
