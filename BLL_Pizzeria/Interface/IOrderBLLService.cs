using Domain_Pizzeria.Models;

namespace BLL_Pizzeria.Interface
{
    public interface IOrderBLLService
    {
        void AddOrder(Order order);
    }
}