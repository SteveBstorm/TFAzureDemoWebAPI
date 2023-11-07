using Domain_Pizzeria.Models;

namespace DAL_Pizzeria.Interface
{
    public interface IUserService
    {
        string CheckPassword(string email);
        IEnumerable<User> GetAll();
        User Login(string email);
        void Register(string nickname, string email, string pwd);

        User GetById(int id);
    }
}