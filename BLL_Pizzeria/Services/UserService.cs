using BLL_Pizzeria.Interface;
using BLL_Pizzeria.Models;
using DAL_Pizzeria.Interface;
using Domain_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Pizzeria.Services
{
    public class UserService : IUserBLLService
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IPizzaService _pizzaService;

        public UserService(IUserService userService, IOrderService orderService, IPizzaService pizzaService)
        {
            _userService = userService;
            _orderService = orderService;
            _pizzaService = pizzaService;
        }

        public void Register(string email, string pwd, string nickname)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(pwd);
            _userService.Register(nickname, email, hash);
        }

        private bool CheckPassword(string pwd, string email)
        {
            string hash = _userService.CheckPassword(email);
            return BCrypt.Net.BCrypt.Verify(pwd, hash);
        }

        public User Login(string email, string pwd)
        {
            if (CheckPassword(pwd, email))
            {
                
                return _userService.Login(email);
            }
            throw new InvalidOperationException("Mot de passe incorrect");
        }

        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        public CompleteUser GetById(int id)
        {
            User u = _userService.GetById(id);
            IEnumerable<Order> orders = _orderService.GetByUser(id);
            CompleteUser cu = new CompleteUser(u);

            var tmp = orders.GroupBy(x => x.PizzaId);

            foreach (IGrouping<int, Order> item in tmp)
            {
                Pizza p = _pizzaService.GetById(item.Key);
                int tmpTotal = 0;
                foreach (var order in item)
                {
                    tmpTotal += order.Quantity;
                }
                cu.Pizzas.Add(
                    new PizzaQty(p)
                    {
                        Quantity = tmpTotal
                    });

            }

            return cu;
        }
    }
}
