using System.Diagnostics;
using HomeBudget.Models;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeBudget.Controllers;

public class TransactionController: Controller
{
    private readonly ILogger<TransactionController> _logger;
    private ITransactionService _transactionService;
    private ICategoryService _categoryService;
    private IUserService _userService;
    
    public TransactionController(
        ILogger<TransactionController> logger,
        ITransactionService transactionService, 
        ICategoryService categoryService,
        IUserService userService
    )
    {
        _logger = logger;
        _transactionService = transactionService;
        _categoryService = categoryService;
        _userService = userService;
    }
    
    public IActionResult Index()
    {
        var transactions = _transactionService.GetAllTransactions();
        ViewBag.Income = _transactionService.CalculateIncomeSum();
        ViewBag.Expense = _transactionService.CalculateExpenseSum();
        ViewBag.Budget = _transactionService.CalculateIncomeExpenseDifference();
        return View(transactions);
    }
    
    public IActionResult TransactionByCategory(int categoryId)
    {
        var category = _categoryService.GetCategoryById(categoryId);
        var budget = _transactionService.CalculateCategoryIncomeExpenseDifference(categoryId);
        var catIncomes = _transactionService.CalculateCategoryIncomeSum(categoryId);
        var catExpense = _transactionService.CalculateCategoryExpenseSum(categoryId);
        ViewBag.Category = category;
        ViewBag.CatIncome = catIncomes;
        ViewBag.CatExpense = catExpense;
        ViewBag.Budget = budget;
        var transactions = _transactionService.GetTransactionsByCategory(categoryId);
        
        return View(transactions);
    }
    
    public IActionResult TransactionByUser(int userId)
    {
        var user = _userService.GetUser(userId);
        var budget = _transactionService.CalculateCategoryIncomeExpenseDifference(userId);
        var userIncomes = _transactionService.CalculateUserIncomeSum(userId);
        var userExpense = _transactionService.CalculateUserExpenseSum(userId);
        ViewBag.User = user;
        ViewBag.UserIncome = userIncomes;
        ViewBag.UserExpense = userExpense;
        ViewBag.Budget = budget;
        var transactions = _transactionService.GetTransactionsByUser(userId);
        
        return View(transactions);
    }
    
    public IActionResult TransactionByType(TransactionType transactionType)
    {
        var transactionTypeBag = transactionType == TransactionType.Income ? "Доходи" : "Витрати";
        decimal budget;
        if (transactionType == TransactionType.Income)
        {
            budget = _transactionService.CalculateIncomeSum();
        }
        else
        {
            budget = _transactionService.CalculateExpenseSum();
        }
        
       
        ViewBag.TransactionType = transactionTypeBag;
       
        ViewBag.Budget = budget;
        var transactions = _transactionService.GetTransactionsByType(transactionType);
        
        return View(transactions);
    }
    
    public IActionResult Create()
    {
        ViewBag.UserId = new SelectList(_userService.GetAllUsers(), "Id", "Name");
        ViewBag.CategoryId = new SelectList(_categoryService.GetAllCategories(), "Id", "Title");
        ViewBag.TransactionType = Enum.GetValues(typeof(TransactionType))
            .Cast<TransactionType>()
            .Select(t => new SelectListItem 
            {
                Value = t.ToString(),
                Text = t.ToString()
            });
        return View();
    }
    
    public IActionResult Edit(int transactionId)
    {
        var transaction = _transactionService.GetTransactionById(transactionId);
        if (transaction == null)
        {
            return NotFound();
        }
        ViewBag.UserId = new SelectList(_userService.GetAllUsers(), "Id", "Name");
        ViewBag.CategoryId = new SelectList(_categoryService.GetAllCategories(), "Id", "Title");
        ViewBag.TransactionType = Enum.GetValues(typeof(TransactionType))
            .Cast<TransactionType>()
            .Select(t => new SelectListItem 
            {
                Value = t.ToString(),
                Text = t.ToString()
            });
        return View(transaction);
    }
    
    public IActionResult AddTransaction(TransactionBLL transactionBll)
    {
        _transactionService.AddTransaction(transactionBll);
        return RedirectToAction("Index");
    }
    
    public IActionResult UpdateTransaction(TransactionBLL transactionBll)
    {
        _transactionService.UpdateTransaction(transactionBll);
        return RedirectToAction("Index");
    }
    
    public IActionResult DeleteTransaction(int transactionId)
    {
        _transactionService.DeleteTransaction(transactionId);
        return RedirectToAction("Index");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}