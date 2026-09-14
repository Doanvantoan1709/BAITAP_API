using LearnAPI.Data;
using LearnAPI.DTO;
using LearnAPI.Model;
using LearnAPI.Service.Interface;

namespace LearnAPI.Service.Implementation
{
    public class OrderService : IOrderService
    {
        public int GetTotalProductSold()
        {
            int total = SeedData.Orders
                .Where(x => x.Status == "Completed")
                .Sum(x => x.Quantity);
            return total;
        }

        public List<OrderDetailDto> GetOrderDetail()
        {
            List<OrderDetailDto> listOrderDetail = SeedData.Orders
                .Join
                (
                    SeedData.Products,
                    ord => ord.ProductId,
                    prod => prod.Id,
                    (ord, prod) => new
                    {
                        Ord = ord,
                        Prod = prod
                    }
                )
                .Where(x => x.Ord.Status == "Completed")
                .Select
                (
                    x => new OrderDetailDto()
                    {
                        OrderId = x.Ord.Id,
                        ProductName = x.Prod.Name,
                        Price = x.Prod.Price,
                        Quantity = x.Ord.Quantity,
                        TotalAmount = x.Prod.Price * x.Ord.Quantity
                    }
                ).ToList();
            return listOrderDetail;
                
        }

        public List<MonthlyRevenueDto> GetMonthlyRevenue()
        {
            List<MonthlyRevenueDto> listMonthlyRevenue = SeedData.Orders
                .Where(x => x.Status == "Completed")
                .GroupBy(x => x.OrderDate.Month)
                .Select
                (
                    x => new MonthlyRevenueDto()
                    {
                        Month = x.Key,
                        OrderCount = x.Count(),
                        TotalQuantitySold = x.Sum(y => y.Quantity)
                    }
                )
                .ToList();
            return listMonthlyRevenue;
        }
    }
}
