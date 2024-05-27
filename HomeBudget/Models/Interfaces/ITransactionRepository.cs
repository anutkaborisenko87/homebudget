using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetAllTransactions();
    Transaction? GetTransactionById(int id);
    IEnumerable<Transaction> GetTransactionsByType(TransactionType type);
    IEnumerable<Transaction> GetTransactionsByCategory(int categoryId);
    IEnumerable<Transaction> GetCategoryTransactionsByType(int categoryId, TransactionType type);
    IEnumerable<Transaction> GetTransactionsByUser(int userId);
    IEnumerable<Transaction> GetUserTransactionsByType(int userId, TransactionType type);
    void AddTransaction(Transaction transaction);
    void UpdateTransaction(Transaction transaction);
    void DeleteTransaction(int id);
}