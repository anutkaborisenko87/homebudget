using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();

    User? GetUser(int Id);
    User AddUser(User user);
    User UpdateUser(User user);
    User DeleteUser(int Id);
}