using HomeBudget.Models.Entities.BLL;

namespace HomeBudget.Models.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryBLL> GetAllCategories();
    CategoryBLL GetCategoryById(Guid id);
    void AddCategory(CategoryBLL categoryBll);
    void UpdateCategory(CategoryBLL categoryBll);
    void DeleteCategory(Guid id);
}