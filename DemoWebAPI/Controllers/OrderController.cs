using BLL_Pizzeria.Interface;
using Domain_Pizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBLLService _orderService;

        public OrderController(IOrderBLLService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult AddOrder(Order o)
        {
            _orderService.AddOrder(o);
            return Ok();
        }
    }
}
