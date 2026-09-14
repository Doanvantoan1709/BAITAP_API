namespace LearnAPI.DTO
{
    public class CategoryRevenueDto
    {
        public int CategoryId { get; set; }
        public double TotalRevenue { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
