using Domain_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Pizzeria.Models
{
    public class PizzaQty : Pizza
    {
        public int Quantity{ get; set; }

        public PizzaQty(Pizza p)
        {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
        }
    }
}
