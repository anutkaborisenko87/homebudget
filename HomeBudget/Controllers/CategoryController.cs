using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private ICategoryService _categoryService;

    public CategoryController(
        ILogger<CategoryController> logger,
        ICategoryService categoryService
    )
    {
        _logger = logger;
        _categoryService = categoryService;
    }
    public IActionResult Index()
    {
        var categories = _categoryService.GetAllCategories();
        return View(categories);
    }
    public IActionResult Create()
    {
        return View();
    }
    
    public IActionResult AddCategory(CategoryBLL categoryBll)
    {
        _categoryService.AddCategory(categoryBll);
        return RedirectToAction("Index");
    }
    
    public IActionResult EditCategory(int categoryId)
    {
        var categoryBll = _categoryService.GetCategoryById(categoryId);
        if (categoryId == null || categoryBll == null)
        {
            return NotFound();
        }
        return View(categoryBll);
    }
    
    public IActionResult UpdateCategory(CategoryBLL categoryBll)
    {
         _categoryService.UpdateCategory(categoryBll);
         return RedirectToAction("Index");
    }
    
    
    public IActionResult DeleteCategory(int categoryId)
    {
        _categoryService.DeleteCategory(categoryId);
        return RedirectToAction("Index");
    }
        
}