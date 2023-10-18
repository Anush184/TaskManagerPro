using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerPro.Application.Contracts.Email;
using TaskManagerPro.Application.Contracts.Logging;
using TaskManagerPro.Application.Models.Email;
using TaskManagerPro.Infrastructure.EmailService;
using TaskManagerPro.Infrastructure.Logging;

namespace TaskManagerPro.Infrastructure
{
    public static class InfrustructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}