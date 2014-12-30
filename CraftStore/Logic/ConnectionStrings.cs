using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CraftStore.Logic
{
    public static class ConnectionStrings
    {
        public static readonly ConnectionStringSettings LocalSqlServer = ConfigurationManager.ConnectionStrings["LocalSqlServer"];
        public static readonly ConnectionStringSettings DefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"];
    }
}