using PaginationApp.Data.Repositories;
using PaginationApp.Services;

namespace PaginationApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
