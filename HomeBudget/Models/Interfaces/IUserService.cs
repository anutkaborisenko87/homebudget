using HomeBudget.Models.Entities.BLL;

namespace HomeBudget.Models.Interfaces;

public interface IUserService
{
    IEnumerable<UserBLL> GetAllUsers();

    UserBLL GetUser(int id);

    UserBLL DeleteUser(int id);

    UserBLL UpdateUser(UserBLL userBll);

    UserBLL AddUser(UserBLL userBll);
}