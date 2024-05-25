using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetAllTransactions();
    Transaction GetTransactionById(Guid id);
    IEnumerable<Transaction> GetTransactionsByType(TransactionType type);
    IEnumerable<Transaction> GetTransactionsByCategory(Category category);
    IEnumerable<Transaction> GetCategoryTransactionsByType(Category category, TransactionType type);
    IEnumerable<Transaction> GetTransactionsByUser(User user);
    IEnumerable<Transaction> GetUserTransactionsByType(User user, TransactionType type);
    void AddTransaction(Transaction transaction);
    void UpdateTransaction(Transaction transaction);
    void DeleteTransaction(Guid id);
}