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

    public UserBLL GetUser(int id)
    {
        return mapper.Map<UserBLL>(userRepository.GetUser(id));
    }

    public UserBLL DeleteUser(int id)
    {
       return mapper.Map<UserBLL>(userRepository.DeleteUser(id));
    }

    public UserBLL UpdateUser(UserBLL userBll)
    {
        return mapper.Map<UserBLL>(userRepository.UpdateUser(mapper.Map<User>(userBll)));
    }

    public UserBLL AddUser(UserBLL userBll)
    {
        return mapper.Map<UserBLL>(userRepository.AddUser(mapper.Map<User>(userBll)));
    }
}