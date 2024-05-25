using AutoMapper;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Entities.DAL;
using HomeBudget.Models.Interfaces;

namespace HomeBudget.Models.Services;

public class UserService: IUserService
{
    private IUserRepository userRepository;
    private IMapper mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }


    public IEnumerable<UserBLL> GetAllUsers()
    {
        return mapper.Map<IEnumerable<UserBLL>>(userRepository.GetUsers());
    }

    public UserBLL GetUser(Guid id)
    {
        return mapper.Map<UserBLL>(userRepository.GetUser(id));
    }

    public void DeleteUser(Guid id)
    {
        userRepository.DeleteUser(id);
    }

    public void UpdateUser(UserBLL userBll)
    {
        userRepository.UpdateUser(mapper.Map<User>(userBll));
    }

    public void AddUser(UserBLL userBll)
    {
        userRepository.AddUser(mapper.Map<User>(userBll));
    }
}