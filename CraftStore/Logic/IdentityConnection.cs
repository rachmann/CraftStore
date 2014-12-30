using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CraftStore.Logic
{

    public static class IdentityConnectionExtensions
    {
        public static SqlConnection IdentityConnection(this ConnectionStringSettings settings)
        {
            var dbConnection = new SqlConnection(settings.ConnectionString);
            dbConnection.Open();
            return dbConnection;
        }
    }
}