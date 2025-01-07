using Kursach.Domain.Abstractions;
using Kursach.Infrastructure;
using Kursach.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab6.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("DbConnection"), b =>
                    b.MigrationsAssembly("Kursach.Infrastructure")));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITariffRepository, TariffRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IParkingSpaceRepository, ParkingSpaceRepository>();
            services.AddScoped<IWorkShiftRepository, WorkShiftRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IWorkShiftPaymentRepository, WorkShiftPaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
