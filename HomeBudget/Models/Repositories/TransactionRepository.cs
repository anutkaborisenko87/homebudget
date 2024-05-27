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
        return context.Transactions
            .Include(t => t.User)
            .Include(t => t.Category)
            .ToList();
    }

    public Transaction? GetTransactionById(int id)
    {
        var transaction = context
            .Transactions
            .Include(t => t.User)
            .Include(t => t.Category)
            .FirstOrDefault(t => t.Id == id);
        return transaction;
    }

    public IEnumerable<Transaction> GetTransactionsByType(TransactionType type)
    {
        return context.Transactions.Where(t => t.TransactionType == type)
            .Include(t => t.User)
            .Include(t => t.Category)
            .ToList();
    }

    public IEnumerable<Transaction> GetTransactionsByCategory(int categoryId)
    {
        var transactions = context.Transactions.Where(t => t.CategoryId == categoryId)
            .Include(t => t.User)
            .ToList();
        return transactions;
    }

    public IEnumerable<Transaction> GetCategoryTransactionsByType(int categoryId, TransactionType type)
    {
        return context.Transactions.Where(t => t.CategoryId == categoryId)
            .Where(t=> t.TransactionType == type)
            .Include(t => t.User)
            .ToList();
    }

    public IEnumerable<Transaction> GetTransactionsByUser(int userId)
    {
        return context.Transactions.Where(t => t.UserId == userId)
            .Include(t => t.Category).ToList();
    }

    public IEnumerable<Transaction> GetUserTransactionsByType(int userId, TransactionType type)
    {
        return context.Transactions.Where(t => t.UserId == userId)
            .Where(t=> t.TransactionType == type)
            .Include(t => t.Category)
            .Include(t => t.User)
            .ToList();
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

    public void DeleteTransaction(int id)
    {
        var transaction = context.Transactions.Find(id);
        context.Transactions.Remove(transaction);
        context.SaveChanges();
    }
}