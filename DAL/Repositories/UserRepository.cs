using DAL.Entities;
using DAL.Interfaces;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public User? Create(User entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Users OUTPUT inserted.id VALUES(@Email, @Password, @Lastname, @Firstname, DEFAULT, DEFAULT)";
                cmd.Parameters.AddWithValue("Email", entity.Email);
                cmd.Parameters.AddWithValue("Password", entity.Password);
                cmd.Parameters.AddWithValue("Lastname", entity.Lastname);
                cmd.Parameters.AddWithValue("Firstname", entity.Firstname);


                entity.Id = (int)DbCommands.ExecuteScalar(_connectionString, cmd);
                    
                return entity;
            }
        }

        public bool Delete(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE id = @id";

                cmd.Parameters.AddWithValue("id", id);

                return DbCommands.ExecuteNonQuery(_connectionString, cmd) == 1;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * FROM Users";

                return DbCommands.ExecuteReader(_connectionString, cmd, x => DatabaseMapper.ToUser(x));
            }
        }

        public User? GetByEmail(string email)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Email = @Email";
                cmd.Parameters.AddWithValue("Email", email);

                return DbCommands.ExecuteReader(_connectionString, cmd, x => DatabaseMapper.ToUser(x)).SingleOrDefault();

                
            }
        }

        public User? GetById(int id)
        {
            using(SqlCommand cmd =new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE id = @id";
                cmd.Parameters.AddWithValue("id", id);

                return DbCommands.ExecuteReader(_connectionString, cmd, x => DatabaseMapper.ToUser(x)).SingleOrDefault();

            }
        }

        public bool Update(User entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Users SET Email = @Email, Pwd = @Password, Firstname = @Firstname, Lastname = @Lastname, Suspended = @Suspended, LoginFailCount = @LoginFailCount";

                cmd.Parameters.AddWithValue("Email", entity.Email);
                cmd.Parameters.AddWithValue("Password", entity.Password);
                cmd.Parameters.AddWithValue("Firstname", entity.Firstname);
                cmd.Parameters.AddWithValue("Lastname", entity.Lastname);
                cmd.Parameters.AddWithValue("Suspended", entity.Suspended);
                cmd.Parameters.AddWithValue("LoginFailCount", entity.LoginFailCount);

                return DbCommands.ExecuteNonQuery(_connectionString, cmd) == 1;
            }
        }
    }
}
