using Domain_Pizzeria.Models;

namespace DAL_Pizzeria.Interface
{
    public interface IPizzaService
    {
        void Create(Pizza pizza);
        IEnumerable<Pizza> GetAll();
        Pizza GetById(int id);
    }
}