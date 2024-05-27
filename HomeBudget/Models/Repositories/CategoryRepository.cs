using HomeBudget.Models.Entities.DAL;
using HomeBudget.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.Models.Repositories;

public class CategoryRepository: ICategoryRepository
{
    private HomeBudgetContext context;

    public CategoryRepository(HomeBudgetContext context)
    {
        this.context = context;
    }
    
    public IEnumerable<Category> GetAllCategories()
    {
        return context.Categories
            .Include(c => c.Transactions)
            .ToList();
    }

    public Category GetCategoryById(int id)
    {
        return context.Categories.Find(id);
    }

    public void AddCategory(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        var existingCategory = context.Categories.Find(category.Id);
        context.Entry(existingCategory).CurrentValues.SetValues(category);
        context.Entry(existingCategory).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = context.Categories.Find(id);
        context.Categories.Remove(category);
        context.SaveChanges();
    }
    
    public bool HasTransactions(int categoryId)
    {
        return context.Transactions.Any(t => t.CategoryId == categoryId);
    }
}