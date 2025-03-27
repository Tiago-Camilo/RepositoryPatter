using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces.DBConfiguration;

namespace Infrastructure.DBConfiguration.Dapper
{
    public class DataSettings : IDataSettings
    {
        public string DefaultConnection { get ; set ; }
    }

}
