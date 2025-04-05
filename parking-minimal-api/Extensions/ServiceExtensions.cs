
using System.Reflection;
using ParkingMinimalApi.AppContext;
using ParkingMinimalApi.Exceptions;
using ParkingMinimalApi.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParkingMinimalApi.Services;

namespace ParkingMinimalApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
        
            // Adding the database context
            builder.Services.AddDbContext<ParkingDBContext>(configure =>
            {
                configure.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //Commenting out the SQL Server configuration for now
            // builder.Services.AddDbContext<ParkingDBContext>(configure =>
            // {
            //     configure.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            // });

             builder.Services.AddScoped<IVehicleService, VehicleService>();

          
             builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
             builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
        }
    }
}