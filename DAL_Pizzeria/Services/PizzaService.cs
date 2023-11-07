using DAL_Pizzeria.Interface;
using Domain_Pizzeria.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Pizzeria.Services
{
    public class PizzaService : IPizzaService
    {
        private SqlConnection _connection;

        public PizzaService(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Pizza> GetAll()
        {
            string sql = "SELECT * FROM Pizza";
            return _connection.Query<Pizza>(sql);
        }

        public void Create(Pizza pizza)
        {
            string sql = "INSERT INTO Pizza (Name, Price) VALUES (@Name, @Price)";
            _connection.Execute(sql, pizza);
        }

        public Pizza GetById(int id)
        {
            string sql = "SELECT * FROM Pizza WHERE Id = @id";
            return _connection.QueryFirst<Pizza>(sql, new {id});
        }
    }
}
