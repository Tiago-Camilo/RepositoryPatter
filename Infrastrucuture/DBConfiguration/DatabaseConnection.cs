using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


namespace Infrastructure.DBConfiguration
{
    namespace Infrastructure.DBConfiguration
    {
        public class DatabaseConnection
        {
            public static IConfiguration ConnectionConfiguration
            {
                get
                {
                    var path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).ToString()}\\Infrastrucuture";
                    IConfigurationRoot Configuration = new ConfigurationBuilder()
                        .SetBasePath(path)
                        .AddJsonFile("appsettings.json")
                        .Build();

                    return Configuration;
                }
            }
        }
    }
}

