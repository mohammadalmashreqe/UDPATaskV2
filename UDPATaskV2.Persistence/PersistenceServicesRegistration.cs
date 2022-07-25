using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Persistence;
using UDPATaskV2.Persistence.Repositories;

namespace UDPATaskV2.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UDPATaskV2DbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("UDPATaskV2ConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDepartmentsRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
