using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Persistence;
using TaskManagerPro.Persistence.DatabaseContext;
using TaskManagerPro.Persistence.Repositories;

namespace TaskManagerPro.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration) 
    {
        services.AddDbContext<TMPDatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("TMPDatabaseConnectingString"));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();



        });
        return services;
    }
}
