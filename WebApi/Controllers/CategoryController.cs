using Microsoft.AspNetCore.Mvc;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _categoryService.GetCategories());
        }
    }
}
