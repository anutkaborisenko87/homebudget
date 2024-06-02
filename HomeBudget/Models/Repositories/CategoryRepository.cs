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

    public Category? GetCategoryById(int id)
    {
        return context.Categories.Include(c => c.Transactions).Where(c => c.Id == id).FirstOrDefault();
    }

    public Category AddCategory(Category category)
    {
        var res = context.Categories.Add(category);
        context.SaveChanges();
        return res.Entity;
    }

    public Category UpdateCategory(Category category)
    {
        var existingCategory = context.Categories.Find(category.Id);
        context.Entry(existingCategory).CurrentValues.SetValues(category);
        context.Entry(existingCategory).State = EntityState.Modified;
        context.SaveChanges();
        return existingCategory;
    }

    public Category DeleteCategory(int id)
    {
        var category = context.Categories.Find(id);
        context.Categories.Remove(category);
        context.SaveChanges();
        return category;
    }
    
    public bool HasTransactions(int categoryId)
    {
        return context.Transactions.Any(t => t.CategoryId == categoryId);
    }
}