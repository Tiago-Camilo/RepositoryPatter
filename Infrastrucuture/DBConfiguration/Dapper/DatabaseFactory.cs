using System.Data;
using Infrastructure.DBConfiguration.Infrastructure.DBConfiguration;
using Infrastructure.Interfaces.DBConfiguration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.DBConfiguration.Dapper
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private IOptions<DataSettings> dataSettings;
        protected string ConnectString => !string.IsNullOrEmpty(dataSettings.Value.DefaultConnection) ? 
                                            dataSettings.Value.DefaultConnection :
                                            DatabaseConnection.ConnectionConfiguration
                                                                               .GetConnectionString("DefaultConnection");
        public IDbConnection GetDbConnection => new SqlConnection(ConnectString);

        public DatabaseFactory(IOptions<DataSettings> dataSettings)
        {
            this.dataSettings = dataSettings;
        }
    }
}
