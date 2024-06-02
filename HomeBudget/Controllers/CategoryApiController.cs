using AutoMapper;
using HomeBudget.Models.Entities.Api;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private IMapper _mapper;
        private ICategoryService _categoryService;

        public CategoryApiController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAllCategories();
            var res = _mapper.Map<IEnumerable<GetCategoryResponse>>(categories);
            return Ok(res);
        }
        
        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            var res = _mapper.Map<GetCategoryResponse>(category);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post(PostCategoryRequest category)
        {
            return Ok(
                _mapper.Map<GetCategoryResponse>(_categoryService.AddCategory(_mapper.Map<CategoryBLL>(category))));
        }

        [HttpPut]
        public IActionResult Put(PutCategoryRequest category)
        {
            return Ok(
                _mapper.Map<GetCategoryResponse>(_categoryService.UpdateCategory(_mapper.Map<CategoryBLL>(category))));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            return Ok(
                _mapper.Map<GetCategoryResponse>(_categoryService.DeleteCategory(id)));
        }
    }
}
