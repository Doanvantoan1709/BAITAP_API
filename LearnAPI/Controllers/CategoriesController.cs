using LearnAPI.DTO;
using LearnAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // BAI 11
        [HttpGet("with-products")]
        public List<CategoryWithProductsDto> GetCategoryStatistic()
        {
            var res = _categoryService.GetCategoryStatistic();
            return res;
        }


        // BAI 15
        [HttpGet("revenue")]
        public List<CategoryRevenueDto> GetCategoryRevenue()
        {
            var res = _categoryService.GetCategoryRevenue();
            return res;
        }
    }
}
