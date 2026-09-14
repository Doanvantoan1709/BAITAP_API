using LearnAPI.DTO;
using LearnAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public orderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // BAI 7
        [HttpGet("total-completed-quantity")]
        public int GetTotalProductSold()
        {
            var res = _orderService.GetTotalProductSold();
            return res;
        }


        // BAI 10
        [HttpGet("details")]
        public List<OrderDetailDto> GetOrderDetail()
        {
            var res = _orderService.GetOrderDetail();
            return res;
        }


        // BAI 13
        [HttpGet("revenue-by-month")]
        public List<MonthlyRevenueDto> GetMonthlyRevenue()
        {
            var res = _orderService.GetMonthlyRevenue();
            return res;
        }
    }
}
