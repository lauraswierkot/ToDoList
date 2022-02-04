using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ToDoList
{
    public static class DataBase 
    {  public static void AddToDatabase(string title, string descripton, DateTime date)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("INSERT INTO Tasks (title, description, date) VALUES (");
            strBuilder.Append("'" + title + "'" + "," + "'" + descripton + "'" + "," + "'" + date.ToString("yyyy-MM-dd") + "'" + 
                ')');

            SqlConnection connection = SQLConnector.Connect();

            string sqlQuery = strBuilder.ToString();
            using (SqlCommand command = new SqlCommand(sqlQuery, connection)) //pass SQL query created above and connection
            {
                command.ExecuteNonQuery(); //execute the Query
                Console.WriteLine("Query Executed.");
            }


        }

        public static void DeleteFromDatabase(string title, string description, DateTime date)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("DELETE FROM Tasks WHERE title = " + "'%" + title + "'" + "AND description = " + "'%" + description + "'" + " AND date = " + "'" + date.ToString("yyyy-MM-dd") + "'");

            SqlConnection connection = SQLConnector.Connect();

            string sqlQuery = strBuilder.ToString();
            using (SqlCommand command = new SqlCommand(sqlQuery, connection)) //pass SQL query created above and connection
            {
                command.ExecuteNonQuery(); //execute the Query
                Console.WriteLine("Query Executed.");
            }
        }

    }
}
