using HomeBudget.Models.Entities.BLL;

namespace HomeBudget.Models.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryBLL> GetAllCategories();
    CategoryBLL GetCategoryById(int id);
    void AddCategory(CategoryBLL categoryBll);
    void UpdateCategory(CategoryBLL categoryBll);
    void DeleteCategory(int id);
    bool HasTransactions(int categoryId);
}