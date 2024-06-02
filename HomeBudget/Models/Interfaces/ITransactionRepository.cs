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
    Transaction AddTransaction(Transaction transaction);
    Transaction UpdateTransaction(Transaction transaction);
    Transaction DeleteTransaction(int id);
}