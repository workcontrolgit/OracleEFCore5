using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Domain.Settings;
using OracleEFCore5.Infrastructure.Shared.Services;

namespace OracleEFCore5.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IMockService, MockService>();

        }
    }
}
