using HomeBudget.Models.Entities;
using HomeBudget.Models.Entities.DAL;
using HomeBudget.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Models.Repositories;

public class TransactionRepository: ITransactionRepository
{
    private HomeBudgetContext context;

    public TransactionRepository(HomeBudgetContext context)
    {
        this.context = context;
    }
    
    public IEnumerable<Transaction> GetAllTransactions()
    {
        return context.Transactions.ToList();
    }

    public Transaction GetTransactionById(Guid id)
    {
        return context.Transactions.Find(id);
    }

    public IEnumerable<Transaction> GetTransactionsByType(TransactionType type)
    {
        return context.Transactions.Where(t => t.TransactionType == type).ToList();
    }

    public IEnumerable<Transaction> GetTransactionsByCategory(Category category)
    {
        return context.Transactions.Where(t => t.CategoryId == category.Id).ToList();
    }

    public IEnumerable<Transaction> GetCategoryTransactionsByType(Category category, TransactionType type)
    {
        return context.Transactions.Where(t => t.CategoryId == category.Id)
            .Where(t=> t.TransactionType == type).ToList();
    }

    public IEnumerable<Transaction> GetTransactionsByUser(User user)
    {
        return context.Transactions.Where(t => t.UserId == user.Id).ToList();
    }

    public IEnumerable<Transaction> GetUserTransactionsByType(User user, TransactionType type)
    {
        return context.Transactions.Where(t => t.UserId == user.Id)
            .Where(t=> t.TransactionType == type).ToList();
    }

    public void AddTransaction(Transaction transaction)
    {
       context.Transactions.Add(transaction);
       context.SaveChanges();
    }

    public void UpdateTransaction(Transaction transaction)
    {
        context.Entry(transaction).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void DeleteTransaction(Guid id)
    {
        var transaction = context.Transactions.Find(id);
        context.Transactions.Remove(transaction);
        context.SaveChanges();
    }
}