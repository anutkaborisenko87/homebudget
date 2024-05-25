using HomeBudget.Models.Entities.BLL;

namespace HomeBudget.Models.Interfaces;

public interface IUserService
{
    IEnumerable<UserBLL> GetAllUsers();

    UserBLL GetUser(Guid id);

    void DeleteUser(Guid id);

    void UpdateUser(UserBLL userBll);

    void AddUser(UserBLL userBll);
}