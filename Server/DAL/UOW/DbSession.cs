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

    /// <summary>
    /// Permet d'ouvrir une connection à la base de donnes ainsi que de faire une transaction
    /// </summary>
	public class DbSession
	{
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration, string connectionName)
        {
	        var connectionString = configuration.GetConnectionString(connectionName);
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
