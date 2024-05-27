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
        return context.Users
            .Include(u => u.Transactions)
            .ToList();
    }

    public User GetUser(int id)
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

    public void DeleteUser(int id)
    {
        var user = context.Users.Find(id);
        context.Users.Remove(user);
        context.SaveChanges();
    }
}