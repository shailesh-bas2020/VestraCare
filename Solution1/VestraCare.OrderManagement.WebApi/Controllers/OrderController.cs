using Microsoft.AspNetCore.Mvc;
using VestraCare.OrderManagement.Core.Application;
using VestraCare.OrderManagement.Core.Application.Interfaces.Services;
using VestraCare.OrderManagement.Core.Application.Models;
using VestraCare.OrderManagement.Core.Application.VIewModel;

namespace VestraCare.OrderManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService=orderService;
        }
        [HttpGet("GetOrders")]
        public async Task<ActionResult<PagignationResponseModel<OrderViewModel>>> GetOrders([FromQuery] BaseFilter baseFilter)
        {
            var order = await _orderService.GetAllOrderByFilterAsync(baseFilter);
            if (order is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }
        [HttpGet("GetOrdersByFilter")]
        public async Task<ActionResult<PagignationResponseModel<OrderViewModel>>> GetOrdersByFilter([FromQuery] OrderFilter orderFilter)
        {
            var order = await _orderService.GetAllOrderAsync(orderFilter);
            if (order is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }
    }
}
