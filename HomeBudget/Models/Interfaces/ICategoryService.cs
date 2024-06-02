using HomeBudget.Models.Entities.BLL;

namespace HomeBudget.Models.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryBLL> GetAllCategories();
    CategoryBLL GetCategoryById(int id);
    CategoryBLL AddCategory(CategoryBLL categoryBll);
    CategoryBLL UpdateCategory(CategoryBLL categoryBll);
    CategoryBLL DeleteCategory(int id);
    bool HasTransactions(int categoryId);
}