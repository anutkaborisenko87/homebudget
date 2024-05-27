using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using HomeBudget.Models;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Interfaces;

namespace HomeBudget.Controllers;

public class HomeController : Controller
{
    private ITransactionService transactionService;

    public HomeController(
        ITransactionService transactionService
        )
    {
        this.transactionService = transactionService;
    }

    public IActionResult Index()
    {
        var budget = transactionService.CalculateIncomeExpenseDifference();
        return View(budget);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}