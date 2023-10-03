using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Server.DatabaseManager
{
    public class BaseDatabaseManager
    {
        protected BaseDatabaseManager() { }

        public static MySqlConnection connection
        {
            get
            {
                MySqlConnection connection = new MySqlConnection();
                string connctionString = "SERVER=localhost;"+"DATABASE=webshop;"+"UID=root;"+"PASSWORD=;"+"SSL MODE=none;";
                connection.ConnectionString = connctionString;
                return connection;
            }
        }
    }
}