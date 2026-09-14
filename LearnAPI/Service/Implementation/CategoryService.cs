using LearnAPI.Data;
using LearnAPI.DTO;
using LearnAPI.Model;
using LearnAPI.Service.Interface;

namespace LearnAPI.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        public List<CategoryWithProductsDto> GetCategoryStatistic()
        {
            List<CategoryWithProductsDto> listCategoryWithProducts = SeedData.Categories
                .GroupJoin
                (
                    SeedData.Products,
                    cate => cate.Id,
                    prod => prod.CategoryId,
                    (cate, prodGroup) => new
                    {
                        Cate = cate,
                        ProdGroup = prodGroup
                    }
                )
                .Select
                (
                    x => new CategoryWithProductsDto()
                    {
                        CategoryId = x.Cate.Id,
                        CategoryName = x.Cate.Name,
                        Products = x.ProdGroup.ToList(),
                    }
                ).ToList();

            return listCategoryWithProducts;
        }

        public List<CategoryRevenueDto> GetCategoryRevenue()
        {
            List<CategoryRevenueDto> ListCategoryRevenue = SeedData.Products
                .Join
                (
                    SeedData.Orders.Where(x => x.Status == "Completed"),
                    prod => prod.Id,
                    ord => ord.ProductId,
                    (prod, ord) => new
                    {
                        Prod = prod,
                        Ord = ord
                    }
                )
                .GroupBy(x => x.Prod.CategoryId)
                .Select
                (
                    x => new CategoryRevenueDto()
                    {
                        CategoryId = x.Key,
                        TotalRevenue = x.Sum(y => y.Prod.Price * y.Ord.Quantity),
                        OrderDetails = x.Select(y => new OrderDetailDto()
                        {
                            OrderId = y.Ord.Id,
                            ProductName = y.Prod.Name,
                            Price = y.Prod.Price,
                            Quantity = y.Ord.Quantity,
                            TotalAmount = y.Prod.Price * y.Ord.Quantity,
                        })
                        .ToList()
                    }
                )
                .ToList();

            return ListCategoryRevenue;

        }
    }
}
