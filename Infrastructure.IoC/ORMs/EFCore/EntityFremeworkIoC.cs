
using Infrastructure.Interfaces.Repository.Domain;
using Infrastructure.Interfaces.Repository.Standard;
using Infrastrucuture.DBConfiguration.EFCore;
using Infrastrucuture.Repositories.Domain.EFCore;
using Infrastrucuture.Repositories.Standard.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC.ORMs.EFCore
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskToDoRepository, TaskToDoRepository>();

            return services;
        }
    }
}
