namespace LearnAPI.DTO
{
    public class CategoryReportDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TotalStock { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
    }
}
