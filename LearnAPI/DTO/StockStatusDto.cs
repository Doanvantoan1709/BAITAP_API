using LearnAPI.Model;

namespace LearnAPI.DTO
{
    public class StockStatusDto
    {
        public string Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
