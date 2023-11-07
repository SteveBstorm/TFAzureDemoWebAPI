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
    public class OrderService : IOrderService
    {
        private SqlConnection _connection;
        public OrderService(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Order> GetByUser(int userId)
        {
            string sql = "SELECT * FROM [Order] WHERE UserId = @userId";
            return _connection.Query<Order>(sql, new { userId });
        }

        public void RegisterOrder(Order order)
        {
            string sql = "INSERT INTO [Order] (UserId, PizzaId, Quantity, DateOrder) " +
                "VALUES (@UserId, @PizzaId, @Quantity, @DateOrder)";

            _connection.Execute(sql, order);
        }

    }
}