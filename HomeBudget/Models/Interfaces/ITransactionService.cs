using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface ITransactionService
{
    IEnumerable<TransactionBLL> GetAllTransactions();
    TransactionBLL GetTransactionById(Guid id);
    IEnumerable<TransactionBLL> GetTransactionsByType(TransactionType type);
    IEnumerable<TransactionBLL> GetTransactionsByCategory(CategoryBLL categoryBll);
    IEnumerable<TransactionBLL> GetCategoryTransactionsByType(CategoryBLL categoryBll, TransactionType type);
    IEnumerable<TransactionBLL> GetTransactionsByUser(UserBLL userBll);
    IEnumerable<TransactionBLL> GetUserTransactionsByType(UserBLL userBll, TransactionType type);
    void AddTransaction(TransactionBLL transactionBll);
    void UpdateTransaction(TransactionBLL transactionBll);
    void DeleteTransaction(Guid id);
}