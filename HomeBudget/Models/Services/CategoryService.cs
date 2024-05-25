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

    public CategoryBLL GetCategoryById(Guid id)
    {
        return mapper.Map<CategoryBLL>(categoryRepository.GetCategoryById(id));
    }

    public void AddCategory(CategoryBLL categoryBll)
    {
        categoryRepository.AddCategory(mapper.Map<Category>(categoryBll));
    }

    public void UpdateCategory(CategoryBLL categoryBll)
    {
        categoryRepository.UpdateCategory(mapper.Map<Category>(categoryBll));
    }

    public void DeleteCategory(Guid id)
    {
        categoryRepository.DeleteCategory(id);
    }
}