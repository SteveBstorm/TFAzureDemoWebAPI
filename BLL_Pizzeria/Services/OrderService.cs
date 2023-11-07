using BLL_Pizzeria.Interface;
using DAL_Pizzeria.Interface;
using Domain_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Pizzeria.Services
{
    public class OrderService : IOrderBLLService
    {
        private readonly IOrderService _orderService;
        public OrderService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void AddOrder(Order order)
        {
            _orderService.RegisterOrder(order);

        }
    }
}
