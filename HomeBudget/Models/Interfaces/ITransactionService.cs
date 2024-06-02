using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface ITransactionService
{
    IEnumerable<TransactionBLL> GetAllTransactions();
    TransactionBLL GetTransactionById(int id);
    IEnumerable<TransactionBLL> GetTransactionsByType(TransactionType type);
    IEnumerable<TransactionBLL> GetTransactionsByCategory(int categoryId);
    IEnumerable<TransactionBLL> GetCategoryTransactionsByType(int categoryId, TransactionType type);
    IEnumerable<TransactionBLL> GetTransactionsByUser(int userId);
    IEnumerable<TransactionBLL> GetUserTransactionsByType(int userId, TransactionType type);
    TransactionBLL AddTransaction(TransactionBLL transactionBll);
    TransactionBLL UpdateTransaction(TransactionBLL transactionBll);
    TransactionBLL DeleteTransaction(int id);
    decimal CalculateIncomeExpenseDifference();
    decimal CalculateExpenseSum();
    decimal CalculateIncomeSum();
    decimal CalculateCategoryIncomeExpenseDifference(int categoryId);
    decimal CalculateCategoryExpenseSum(int categoryId);
    decimal CalculateCategoryIncomeSum(int categoryId);
    decimal CalculateUserIncomeExpenseDifference(int userId);
    decimal CalculateUserIncomeSum(int userId);
    decimal CalculateUserExpenseSum(int userId);
}