using DAL_Pizzeria.Interface;
using Domain_Pizzeria.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Pizzeria.Services
{
    public class UserService : IUserService
    {
        private SqlConnection _connection;

        public UserService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Register(string nickname, string email, string pwd)
        {
            string sql = "INSERT INTO Users (Nickname, Email, Pwd) " +
                "VALUES (@nickname, @email, @pwd)";
            var param = new { nickname, email, pwd };

            _connection.Execute(sql, param);
        }

        public void RegisterADO(string nickname, string email, string pwd)
        {
            string sql = "INSERT INTO Users (Nickname, Email, Pwd) " +
                "VALUES (@nickname, @email, @pwd)";
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("nickname", nickname);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("pwd", pwd);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public IEnumerable<User> GetAllAdo()
        {
            string sql = "SELECT * FROM Users";

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = sql;
                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    yield return new User
                    {
                        Id = (int)reader["Id"],
                        Nickname = reader["Nickname"].ToString(),
                        Email = reader["Email"].ToString(),
                        IsAdmin = (bool)reader["IsAdmin"]
                    };
                }
            }


        }

        public IEnumerable<User> GetAll()
        {
            string sql = "SELECT * FROM Users";

            return _connection.Query<User>(sql);
        }

        public User Login(string email)
        {
            string sql = "SELECT * FROM Users WHERE Email = @email";

            var param = new { email };

            return _connection.QueryFirst<User>(sql, param);
        }

        public string CheckPassword(string email)
        {
            string sql = "SELECT Pwd FROM Users WHERE Email = @email";
            return _connection.QueryFirst<string>(sql, new { email });
        }

        public User GetById(int id)
        {
            return _connection.QueryFirst<User>("SELECT * FROM Users WHERE Id = @id", new { id });
        }
    }
}
