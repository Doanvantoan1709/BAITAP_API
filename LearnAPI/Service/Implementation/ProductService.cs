using LearnAPI.Data;
using LearnAPI.DTO;
using LearnAPI.Model;
using LearnAPI.Service.Interface;

namespace LearnAPI.Service.Implementation
{
    public class ProductService : IProductService
    {
        public List<Product> GetAvailableProducts()
        {
            List<Product> listProduct = SeedData.Products
                .Where(x => x.Stock > 0).ToList();
            return listProduct;
        }

        public List<Product> GetSortedProducts()
        {
            List<Product> listProduct = SeedData.Products
                .OrderByDescending(x => x.Price)
                .ThenBy(x => x.Price)
                .ToList();
            return listProduct;
        }

        public List<Product> GetPagingProducts(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0) return null;

            List<Product> listProduct = SeedData.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return listProduct;
        }

        public Product GetProductById(int id)
        {
            if (id <= 0) return null;
            Product? product = SeedData.Products
                .FirstOrDefault(x => x.Id == id);
            return product;
        }

        public double GetTotalPriceStock()
        {
            double total = SeedData.Products.Sum(x => x.Price * x.Stock);
            return total;
        }

        public Product GetExpensiveProduct()
        {
            Product? product = SeedData.Products
                    .Where(x => x.Stock > 0)
                    .MaxBy(x => x.Stock);
            return product;
        }

        public List<CategoryReportDto> GetCategoryReport()
        {
            List<CategoryReportDto> listCateReportDto = SeedData.Products
                .Join
                (
                    SeedData.Categories,
                    prod => prod.CategoryId,
                    cate => cate.Id,
                    (prod, cate) => new
                    {
                        Prod = prod,
                        Cate = cate
                    }
                )
                .GroupBy
                (
                    x => new
                    {
                        x.Prod.CategoryId,
                        x.Cate.Name
                    }
                )
                .Select
                (
                    x => new CategoryReportDto()
                    {
                        CategoryId = x.Key.CategoryId,
                        CategoryName = x.Key.Name,
                        TotalStock = x.Sum(y => y.Prod.Stock),
                        MaxPrice = x.Max(y => y.Prod.Price),
                        MinPrice = x.Min(y => y.Prod.Price),
                    }
                )
                .ToList();

            return listCateReportDto;
        }

        public List<StockStatusDto> GetStockStatus()
        {
            List<StockStatusDto> listStockStatus = SeedData.Products
                .GroupBy
                (
                    x => x.Stock > 0 ? "Còn hàng" : "Hết hàng"
                )
                .Select
                (
                    x => new StockStatusDto()
                    {
                        Status = x.Key,
                        Products = x.Select
                        (
                            y => new Product()
                            {
                                Id = y.Id,
                                Name = y.Name,
                                Price = y.Price,
                                Stock = y.Stock,
                                CategoryId = y.CategoryId,
                            }
                        )
                        .ToList()
                    }
                )
                .ToList();
            return listStockStatus;
        }

        // C1: Sử dụng GroupJoin (Left join)
        //public List<Product> GetProductUnsold()
        //{
        //    List<Product> listProduct = SeedData.Products
        //        .GroupJoin
        //        (
        //            SeedData.Orders.Where(x => x.Status == "Completed"),
        //            prod => prod.Id,
        //            order => order.ProductId,
        //            (prod, orderGroup) => new
        //            {
        //                Prod = prod,
        //                OrderGroup = orderGroup
        //            }
        //        )
        //        .Where(x => !x.OrderGroup.Any())
        //        .Select(x => x.Prod)
        //        .ToList();
        //    return listProduct;
        //}

        // C2: Sử dụng Except: dùng để tìm các phần tử chỉ xuất hiện ở tập hợp 1 mà không xuất hiện ở tập hợp 2
        public List<Product> GetProductUnsold()
        {
            var orderProductId = SeedData.Orders
                .Where(x => x.Status == "Completed")
                .Select(x => x.ProductId);

            List<Product> productSold = SeedData.Products
                .ExceptBy(orderProductId, x => x.Id) // tập hợp 1 trước Except, tập hợp 2 nằm sau. Còn hàm không tên chỉ định thuộc tính nào của tập 1 đem so sánh với tập hợp 2
                .ToList();
            return productSold;        
        }

        public List<TopProductDto> GetTopProduct()
        {
            List<TopProductDto> listTopProduct = SeedData.Products

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
                .GroupBy
                (
                    x => new
                    {
                        x.Prod.Id,
                        x.Prod.Name,
                    }
                )
                .Select
                (
                    x => new TopProductDto()
                    {
                        ProductId = x.Key.Id,
                        ProductName = x.Key.Name,
                        TotalQuantitySold = x.Sum(y => y.Ord.Quantity),
                    }
                )
                .OrderByDescending(x => x.TotalQuantitySold)
                .Take(3)
                .ToList();

            return listTopProduct;
        }
    }
}
