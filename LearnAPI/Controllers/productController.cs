using LearnAPI.DTO;
using LearnAPI.Model;
using LearnAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly IProductService _productService;

        public productController(IProductService productService)
        {
            _productService = productService;
        }

        // BAI 1
        [HttpGet("available")]
        public List<Product> GetAvailableProducts()
        {
            var res = _productService.GetAvailableProducts();
            return res;
        }


        // BAI 2
        [HttpGet("sorted")]
        public List<Product> GetSortedProducts()
        {
            var res = _productService.GetSortedProducts();
            return res;
        }


        // BAI 3
        [HttpGet("paging")]
        public List<Product> GetPagingProducts(int pageNumber, int pageSize)
        {
            var res = _productService.GetPagingProducts(pageNumber, pageSize);
            return res;
        }


        // BAI 4
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            var res = _productService.GetProductById(id);
            return res;
        }


        // BAI 5
        [HttpGet("total-inventory-value")]
        public double GetTotalProductPrice()
        {
            var res = _productService.GetTotalPriceStock();
            return res;
        }


        // BAI 6
        [HttpGet("most-expensive-available")]
        public Product GetExpensiveProduct()
        {
            var res = _productService.GetExpensiveProduct();
            return res;
        }


        // BAI 8
        [HttpGet("category-report")]
        public List<CategoryReportDto> GetCategoryReport()
        {
            var res = _productService.GetCategoryReport();
            return res;
        }


        // BAI 9
        [HttpGet("stock-status")]
        public List<StockStatusDto> GetStockStatus()
        {
            var res = _productService.GetStockStatus();
            return res;
        }


        // BAI 12
        [HttpGet("unsold")]
        public List<Product> GetProductUnsold()
        {
            var res = _productService.GetProductUnsold();
            return res;
        }


        // BAI 14
        [HttpGet("top-3-best-sellers")]
        public List<TopProductDto> GetTopProduct()
        {
            var res = _productService.GetTopProduct();
            return res;
        }
    }
}
