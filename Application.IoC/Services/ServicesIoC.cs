using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services.Domain;
using Application.Interfaces.Services.Standard;
using Application.Services.Domain;
using Application.Services.Standard;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC.Services
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IUserService, UserService> ();
            services.AddScoped<ITaskToDoService, TaskToDoService> ();

        }
    }
}
