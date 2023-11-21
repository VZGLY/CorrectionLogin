using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Database
{
    public static class DbCommands
    {
        public static object ExecuteScalar(string cs, SqlCommand cmd)
        {
            using(SqlConnection conn = new SqlConnection(cs))
            {
                
                cmd.Connection = conn;
                
                conn.Open();

                object data = cmd.ExecuteScalar();

                conn.Close();

                return data;
                

            }
        }

        public static int ExecuteNonQuery(string cs, SqlCommand cmd)
        {
            using( SqlConnection conn = new SqlConnection(cs))
            {
                cmd.Connection = conn;

                conn.Open();

                int data = cmd.ExecuteNonQuery();

                conn.Close();

                return data;
            }
        }

        public static IEnumerable<T> ExecuteReader<T>(string cs, SqlCommand cmd, Func<SqlDataReader, T> mapper)
        {

            using(SqlConnection connection = new SqlConnection(cs))
            {

                cmd.Connection = connection;

                

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return mapper(reader);
                }

                connection.Close();
            }

        }
    }
}
