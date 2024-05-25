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
        return context.Categories.ToList();
    }

    public Category GetCategoryById(Guid id)
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
        context.Entry(category).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void DeleteCategory(Guid id)
    {
        var category = context.Categories.Find(id);
        context.Categories.Remove(category);
        context.SaveChanges();
    }
}