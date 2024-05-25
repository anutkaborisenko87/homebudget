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

    public TransactionBLL GetTransactionById(Guid id)
    {
        return mapper.Map<TransactionBLL>(transactionRepository.GetTransactionById(id));
    }

    public IEnumerable<TransactionBLL> GetTransactionsByType(TransactionType type)
    {
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetTransactionsByType(type));
    }

    public IEnumerable<TransactionBLL> GetTransactionsByCategory(CategoryBLL categoryBll)
    {
        var category = mapper.Map<Category>(categoryBll);
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetTransactionsByCategory(category));
    }

    public IEnumerable<TransactionBLL> GetCategoryTransactionsByType(CategoryBLL categoryBll, TransactionType type)
    {
        var category = mapper.Map<Category>(categoryBll);
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetCategoryTransactionsByType(category, type));
    }

    public IEnumerable<TransactionBLL> GetTransactionsByUser(UserBLL userBll)
    {
        var user = mapper.Map<User>(userBll);
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetTransactionsByUser(user));
    }

    public IEnumerable<TransactionBLL> GetUserTransactionsByType(UserBLL userBll, TransactionType type)
    {
        var user = mapper.Map<User>(userBll);
        return mapper.Map<IEnumerable<TransactionBLL>>(transactionRepository.GetUserTransactionsByType(user, type));
    }

    public void AddTransaction(TransactionBLL transactionBll)
    {
        transactionRepository.AddTransaction(mapper.Map<Transaction>(transactionBll));
    }

    public void UpdateTransaction(TransactionBLL transactionBll)
    {
        transactionRepository.UpdateTransaction(mapper.Map<Transaction>(transactionBll));
    }

    public void DeleteTransaction(Guid id)
    {
       transactionRepository.DeleteTransaction(id);
    }
}