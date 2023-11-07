using Domain_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Pizzeria.Models
{
    public class CompleteUser : User
    {
        public List<PizzaQty> Pizzas { get; set; }

        public CompleteUser(User u)
        {
            Id = u.Id;
            Nickname = u.Nickname;
            Email = u.Email;
            IsAdmin = u.IsAdmin;
            Pizzas = new List<PizzaQty>();
        }
    }
}
