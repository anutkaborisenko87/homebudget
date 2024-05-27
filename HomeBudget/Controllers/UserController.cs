using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private ITransactionService _transactionService;
    private ICategoryService _categoryService;
    private IUserService _userService;
    
    public UserController(
        ILogger<UserController> logger,
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
        var users = _userService.GetAllUsers();
        return View(users);
    }
    public IActionResult Create()
    {
        return View();
    }
    
    public IActionResult Edit(int userId)
    {
        var user = _userService.GetUser(userId);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
    
    public IActionResult UpdateUser(UserBLL userBll)
    {
        _userService.UpdateUser(userBll);
        return RedirectToAction("Index");
    }
    public IActionResult AddUser(UserBLL userBll)
    {
       _userService.AddUser(userBll);
       return RedirectToAction("Index");
    }
    
    public IActionResult DeleteUser(int userId)
    {
        var user = _userService.GetUser(userId);
        if (user == null)
        {
            return NotFound();
        }
        _userService.DeleteUser(userId);
        return RedirectToAction("Index");
    }
}