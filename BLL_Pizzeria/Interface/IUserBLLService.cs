using BLL_Pizzeria.Models;
using Domain_Pizzeria.Models;

namespace BLL_Pizzeria.Interface
{
    public interface IUserBLLService
    {
        IEnumerable<User> GetAll();
        CompleteUser GetById(int id);
        User Login(string email, string pwd);
        void Register(string email, string pwd, string nickname);
    }
}