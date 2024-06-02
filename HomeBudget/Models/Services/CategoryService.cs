using AutoMapper;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Entities.DAL;
using HomeBudget.Models.Interfaces;

namespace HomeBudget.Models.Services;

public class CategoryService: ICategoryService
{
    private ICategoryRepository categoryRepository;
    private IMapper mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        this.categoryRepository = categoryRepository;
        this.mapper = mapper;
    }

    public IEnumerable<CategoryBLL> GetAllCategories()
    {
        return mapper.Map<IEnumerable<CategoryBLL>>(categoryRepository.GetAllCategories());
    }

    public CategoryBLL GetCategoryById(int id)
    {
        return mapper.Map<CategoryBLL>(categoryRepository.GetCategoryById(id));
    }

    public CategoryBLL AddCategory(CategoryBLL categoryBll)
    {
        return mapper.Map<CategoryBLL>(categoryRepository.AddCategory(mapper.Map<Category>(categoryBll)));
    }

    public CategoryBLL UpdateCategory(CategoryBLL categoryBll)
    {
        return mapper.Map<CategoryBLL>(categoryRepository.UpdateCategory(mapper.Map<Category>(categoryBll)));
    }

    public CategoryBLL DeleteCategory(int id)
    {
        return mapper.Map<CategoryBLL>(categoryRepository.DeleteCategory(id));
    }
    
    public bool HasTransactions(int categoryId)
    {
        return categoryRepository.HasTransactions(categoryId);
    }
}