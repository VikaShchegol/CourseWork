using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace course
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "coursework";
            string username = "monty";
            string password = "some_pass";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
