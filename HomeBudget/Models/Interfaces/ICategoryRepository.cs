
using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();
    Category GetCategoryById(int Id);
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(int Id);
    bool HasTransactions(int categoryId);
}