using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Infrastructure.Persistence.Contexts;
using OracleEFCore5.Infrastructure.Persistence.Repositories;
using OracleEFCore5.Infrastructure.Persistence.Repository;

namespace OracleEFCore5.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                //services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(
                //    configuration.GetConnectionString("DefaultConnection"),
                //    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseOracle(
                    configuration.GetConnectionString("OracleConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                    .Assembly.FullName)
                    //.UseOracleSQLCompatibility("12")
                    ));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IPositionRepositoryAsync, PositionRepositoryAsync>();
            services.AddTransient<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
            #endregion

        }
    }
}
