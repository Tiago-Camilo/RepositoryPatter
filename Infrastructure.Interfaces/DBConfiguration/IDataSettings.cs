using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DBConfiguration
{
    public interface IDataSettings
    {
        string DefaultConnection { get; set; }
    }
}
