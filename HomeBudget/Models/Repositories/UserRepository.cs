using HomeBudget.Models.Entities;
using HomeBudget.Models.Entities.DAL;
using HomeBudget.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Models.Repositories;

public class UserRepository: IUserRepository
{
    private HomeBudgetContext context;

    public UserRepository(HomeBudgetContext context)
    {
        this.context = context;
    }
    
    public IEnumerable<User> GetUsers()
    {
        return context.Users.ToList();
    }

    public User GetUser(Guid id)
    {
        return context.Users.Find(id);
    }

    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        context.Entry(user).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void DeleteUser(Guid id)
    {
        var user = context.Users.Find(id);
        context.Users.Remove(user);
        context.SaveChanges();
    }
}