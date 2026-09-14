using LearnAPI.Model;

namespace LearnAPI.DTO
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalAmount { get; set; }
    }
}
