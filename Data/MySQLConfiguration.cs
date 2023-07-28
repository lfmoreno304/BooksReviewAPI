using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MySQLConfiguration
    {
        public string ConnectionString { get; set; }

        public MySQLConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

    }
}
