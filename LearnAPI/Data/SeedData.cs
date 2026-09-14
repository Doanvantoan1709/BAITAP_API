using LearnAPI.Model;

namespace LearnAPI.Data
{
   
    public static class SeedData
    {
        public static List<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Name = "Trái cây" },
            new Category { Id = 2, Name = "Đồ uống" },
            new Category { Id = 3, Name = "Đồ ăn vặt" },
            new Category { Id = 4, Name = "Gia dụng" },
            new Category { Id = 5, Name = "Văn phòng phẩm" } // Danh mục trống để test
        };

        public static List<Product> Products = new List<Product>
        {
            new Product { Id = 1,  Name = "Táo",          Price = 20000, Stock = 10, CategoryId = 1 },
            new Product { Id = 2,  Name = "Cam",          Price = 30000, Stock = 0,  CategoryId = 1 },
            new Product { Id = 3,  Name = "Chuối",        Price = 18000, Stock = 12, CategoryId = 1 },
            new Product { Id = 4,  Name = "Sữa",          Price = 25000, Stock = 5,  CategoryId = 2 },
            new Product { Id = 5,  Name = "Nước suối",    Price = 10000, Stock = 20, CategoryId = 2 },
            new Product { Id = 6,  Name = "Cà phê",       Price = 40000, Stock = 3,  CategoryId = 2 },
            new Product { Id = 7,  Name = "Bánh mì",      Price = 15000, Stock = 8,  CategoryId = 3 },
            new Product { Id = 8,  Name = "Bánh quy",     Price = 35000, Stock = 0,  CategoryId = 3 },
            new Product { Id = 9,  Name = "Mì gói",       Price = 8000,  Stock = 30, CategoryId = 3 },
            new Product { Id = 10, Name = "Nước rửa chén",Price = 55000, Stock = 6,  CategoryId = 4 },
            new Product { Id = 11, Name = "Khăn giấy",    Price = 28000, Stock = 18, CategoryId = 4 },
            new Product { Id = 12, Name = "Sản phẩm ế",   Price = 50000, Stock = 10, CategoryId = 4 } // Không có đơn hàng
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order { Id = 101, ProductId = 1,  Quantity = 2,  OrderDate = new DateTime(2026, 1, 5),  Status = "Completed" },
            new Order { Id = 102, ProductId = 4,  Quantity = 1,  OrderDate = new DateTime(2026, 1, 12), Status = "Completed" },
            new Order { Id = 103, ProductId = 2,  Quantity = 5,  OrderDate = new DateTime(2026, 1, 20), Status = "Cancelled" },
            new Order { Id = 104, ProductId = 6,  Quantity = 2,  OrderDate = new DateTime(2026, 2, 3),  Status = "Completed" },
            new Order { Id = 105, ProductId = 10, Quantity = 1,  OrderDate = new DateTime(2026, 2, 8),  Status = "Pending" },
            new Order { Id = 106, ProductId = 3,  Quantity = 4,  OrderDate = new DateTime(2026, 2, 15), Status = "Completed" },
            new Order { Id = 107, ProductId = 5,  Quantity = 10, OrderDate = new DateTime(2026, 2, 25), Status = "Completed" },
            new Order { Id = 108, ProductId = 1,  Quantity = 4,  OrderDate = new DateTime(2026, 3, 2),  Status = "Completed" },
            new Order { Id = 109, ProductId = 7,  Quantity = 3,  OrderDate = new DateTime(2026, 3, 9),  Status = "Completed" },
            new Order { Id = 110, ProductId = 8,  Quantity = 2,  OrderDate = new DateTime(2026, 3, 18), Status = "Cancelled" },
            new Order { Id = 111, ProductId = 10, Quantity = 2,  OrderDate = new DateTime(2026, 3, 28), Status = "Completed" },
            new Order { Id = 112, ProductId = 11, Quantity = 5,  OrderDate = new DateTime(2026, 4, 4),  Status = "Pending" },
            new Order { Id = 113, ProductId = 9,  Quantity = 10, OrderDate = new DateTime(2026, 4, 11), Status = "Completed" },
            new Order { Id = 114, ProductId = 7,  Quantity = 5,  OrderDate = new DateTime(2026, 4, 19), Status = "Completed" },
            new Order { Id = 115, ProductId = 4,  Quantity = 3,  OrderDate = new DateTime(2026, 5, 1),  Status = "Completed" }
        };
    }
}
