using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DBConfiguration;
using Infrastructure.DBConfiguration.Infrastructure.DBConfiguration;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.IoC
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
