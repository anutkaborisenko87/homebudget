using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();

    User GetUser(Guid Id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(Guid Id);
}