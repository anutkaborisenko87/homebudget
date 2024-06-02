
using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();
    Category? GetCategoryById(int Id);
    Category AddCategory(Category category);
    Category UpdateCategory(Category category);
    Category DeleteCategory(int Id);
     bool HasTransactions(int categoryId);
}