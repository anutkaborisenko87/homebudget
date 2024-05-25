
using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();
    Category GetCategoryById(Guid Id);
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(Guid Id);
}