using AutoMapper;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Entities.DAL;
using HomeBudget.Models.Interfaces;

namespace HomeBudget.Models.Services;

public class TransactionService: ITransactionService
{
    private ITransactionRepository transactionRepository;
    private IMapper mapper;

    public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
    {
        this.transactionRepository = transactionRepository;
        this.mapper = mapper;
    }

    public IEnumerable<TransactionBLL> GetAllTransactions()
    {
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetAllTransactions());
    }

    public  TransactionBLL GetTransactionById(int id)
    {
        var transactionEntity = transactionRepository.GetTransactionById(id);
        return mapper.Map<TransactionBLL>(transactionEntity);
    }

    public IEnumerable<TransactionBLL> GetTransactionsByType(TransactionType type)
    {
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetTransactionsByType(type));
    }

    public IEnumerable<TransactionBLL> GetTransactionsByCategory(int categoryId)
    {
        var transactions = transactionRepository.GetTransactionsByCategory(categoryId);
        return mapper.Map<IEnumerable<TransactionBLL>>(transactions);
    }

    public IEnumerable<TransactionBLL> GetCategoryTransactionsByType(int categoryId, TransactionType type)
    {
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetCategoryTransactionsByType(categoryId, type));
    }

    public IEnumerable<TransactionBLL> GetTransactionsByUser(int userId)
    {
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetTransactionsByUser(userId));
    }

    public IEnumerable<TransactionBLL> GetUserTransactionsByType(int userId, TransactionType type)
    {
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetUserTransactionsByType(userId, type));
    }

    public void AddTransaction(TransactionBLL transactionBll)
    {
        transactionRepository.AddTransaction(mapper.Map<Transaction>(transactionBll));
    }

    public void UpdateTransaction(TransactionBLL transactionBll)
    {
        transactionRepository.UpdateTransaction(mapper.Map<Transaction>(transactionBll));
    }

    public void DeleteTransaction(int id)
    {
       transactionRepository.DeleteTransaction(id);
    }

    public decimal CalculateIncomeExpenseDifference()
    {
        var incomeTransactions = transactionRepository.GetTransactionsByType(TransactionType.Income);
        var expenseTransactions = transactionRepository.GetTransactionsByType(TransactionType.Expense);
        decimal incomeTotal = incomeTransactions.Sum(t => t.Amount);
        decimal expenseTotal = expenseTransactions.Sum(t => t.Amount);
        decimal difference = incomeTotal - expenseTotal;
        return difference;
    }

    public decimal CalculateExpenseSum()
    {
        var expenseTransactions = transactionRepository.GetTransactionsByType(TransactionType.Expense);
        return expenseTransactions.Sum(t => t.Amount);
    }

    public decimal CalculateIncomeSum()
    {
        var incomeTransactions = transactionRepository.GetTransactionsByType(TransactionType.Income);
        return incomeTransactions.Sum(t => t.Amount);
    }

    public decimal CalculateCategoryIncomeExpenseDifference(int categoryId)
    {
        var incomeTransactions = transactionRepository.GetCategoryTransactionsByType(categoryId, TransactionType.Income);
        var expenseTransactions = transactionRepository.GetCategoryTransactionsByType(categoryId, TransactionType.Expense);
        decimal incomeTotal = incomeTransactions.Sum(t => t.Amount);
        decimal expenseTotal = expenseTransactions.Sum(t => t.Amount);
        decimal difference = incomeTotal - expenseTotal;
        return difference;
    }

    public decimal CalculateCategoryIncomeSum(int categoryId)
    {
        var incomeTransactions = transactionRepository.GetCategoryTransactionsByType(categoryId, TransactionType.Income);
        return incomeTransactions.Sum(t => t.Amount);
    }

    public decimal CalculateCategoryExpenseSum(int categoryId)
    {
        var expenseTransactions = transactionRepository.GetCategoryTransactionsByType(categoryId, TransactionType.Expense);
        return expenseTransactions.Sum(t => t.Amount);
    }

    public decimal CalculateUserIncomeExpenseDifference(int userId)
    {
        var incomeTransactions = transactionRepository.GetUserTransactionsByType(userId, TransactionType.Income);
        var expenseTransactions = transactionRepository.GetUserTransactionsByType(userId, TransactionType.Expense);
        decimal incomeTotal = incomeTransactions.Sum(t => t.Amount);
        decimal expenseTotal = expenseTransactions.Sum(t => t.Amount);
        decimal difference = incomeTotal - expenseTotal;
        return difference;
    }

    public decimal CalculateUserIncomeSum(int userId)
    {
        var incomeTransactions = transactionRepository.GetUserTransactionsByType(userId, TransactionType.Income);
        return incomeTransactions.Sum(t => t.Amount);
    }

    public decimal CalculateUserExpenseSum(int userId)
    {
        var expenseTransactions = transactionRepository.GetUserTransactionsByType(userId, TransactionType.Expense);
        return expenseTransactions.Sum(t => t.Amount);
    }
}