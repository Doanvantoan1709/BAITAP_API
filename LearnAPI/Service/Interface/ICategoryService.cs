using LearnAPI.DTO;

namespace LearnAPI.Service.Interface
{
    public interface ICategoryService
    {
        List<CategoryWithProductsDto> GetCategoryStatistic();

        List<CategoryRevenueDto> GetCategoryRevenue();
    }
}
