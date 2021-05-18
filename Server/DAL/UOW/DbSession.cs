using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
	public class DbSession
	{
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration, string connectionName)
        {
            Connection = new SqlConnection(configuration.GetConnectionString(connectionName));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
