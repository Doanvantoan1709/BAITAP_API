using LearnAPI.Model;

namespace LearnAPI.DTO
{
    public class CategoryWithProductsDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
