using LearnAPI.DTO;

namespace LearnAPI.Service.Interface
{
    public interface IOrderService
    {
        int GetTotalProductSold();
        List<OrderDetailDto> GetOrderDetail();
        List<MonthlyRevenueDto> GetMonthlyRevenue();
    }
}
