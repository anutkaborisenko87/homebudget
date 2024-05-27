using HomeBudget.Models.Entities.BLL;

namespace HomeBudget.Models.Interfaces;

public interface IUserService
{
    IEnumerable<UserBLL> GetAllUsers();

    UserBLL GetUser(int id);

    void DeleteUser(int id);

    void UpdateUser(UserBLL userBll);

    void AddUser(UserBLL userBll);
}