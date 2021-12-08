using FluentValidation.Sample.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService= orderService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderModel model)
        {
            if(await _orderService.CreateOrderAsync(model))
            {
                return Ok();
            }
            else
            {
                return  BadRequest();
            }

        }

    }
}
