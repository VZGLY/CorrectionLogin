using DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class DatabaseMapper
    {

        public static User ToUser(this SqlDataReader reader)
        {
            return new User
            {
                Id = Convert.ToInt32(reader["id"]),
                Email = reader["Email"].ToString(),
                Password = reader["Pwd"].ToString(),
                Firstname = reader["Firstname"] == DBNull.Value ? null : reader["Firstname"].ToString(),
                Lastname = reader["Lastname"] == DBNull.Value ? null : reader["Lastname"].ToString(),
                LoginFailCount = Convert.ToInt32(reader["LoginFailCount"]),
                Suspended = Convert.ToBoolean(reader["Suspended"])
            };
        }

    }
}
