using Domain_Pizzeria.Models;

namespace DAL_Pizzeria.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetByUser(int userId);
        void RegisterOrder(Order order);
    }
}