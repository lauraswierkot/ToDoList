using System;
using System.Data.SqlClient;

namespace ToDoList
{
    public static class SQLConnector
    {
        public static SqlConnection Connect()
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"DESKTOP-TLDELPN";//server
            var database = "ToDoItems"; //database name
            var username = "LauraSwierkot"; //username of server to connect
            var password = "Misie1234"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
            return conn;

        }

    }
}

