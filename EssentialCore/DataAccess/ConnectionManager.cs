using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;

namespace EssentialCore.DataAccess
{
    public class ConnectionManager
    {

        private static IConfiguration Configuration { get; set; }

        static ConnectionManager()
        {
            
        }

        public static void Init(IConfiguration configuration)
        {
            Configuration = configuration;

            var connection = Configuration["ConnectionString"]!.ToString();//.GetSection("Connection").Get<Connection>(); // ""; //Tools.Configuartion.ConfigurationService.ReadSection<Connection>("Connection");

            ConnectionManager.ConnectionString = connection;  //$"Server={connection.Server};DataBase={connection.DataBase};UID={connection.UID};PWD={connection.Password};Encrypt=False;TrustServerCertificate=True;";
        }



        public static string ConnectionString { get; private set; }

        public static SqlConnection GetNewConnectionString()
        {
            return new SqlConnection(ConnectionString);
        }


    }
}
