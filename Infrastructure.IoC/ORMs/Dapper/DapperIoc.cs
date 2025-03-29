using Infrastructure.DBConfiguration.Dapper;
using Infrastructure.Interfaces.DBConfiguration;
using Infrastructure.Interfaces.Repository.Domain;
using Infrastructure.IoC.ORMs;
using Infrastructure.Repositories.Domain.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public class DapperIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfigurationSection dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration)
                                                                             .GetSection("ConnectionStrings");

            services.Configure<DataSettings>(dbConnectionSettings.Bind);
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskToDoRepository, TaskToDoRepository>();

            return services;
        }
    }
}