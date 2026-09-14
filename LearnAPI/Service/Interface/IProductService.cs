using LearnAPI.DTO;
using LearnAPI.Model;

namespace LearnAPI.Service.Interface
{
    public interface IProductService
    {
        List<Product> GetAvailableProducts();
        List<Product> GetSortedProducts();
        List<Product> GetPagingProducts(int pageNumber, int pageSize);
        Product GetProductById(int id);
        double GetTotalPriceStock();
        Product GetExpensiveProduct();
        List<CategoryReportDto> GetCategoryReport();
        List<StockStatusDto> GetStockStatus();
        List<Product> GetProductUnsold();
        List<TopProductDto> GetTopProduct();
    }
}
