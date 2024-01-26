using Dethi.Data;
using Dethi.Dto;
using Dethi.Model;
using Dethi.Sevice.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dethi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly MyDb _myDb;
        public OrderController(IOrderService orderService, MyDb myDb)
        {
            _orderService = orderService;
            _myDb = myDb;
        }

        [HttpPost("create")]
        public IActionResult Create(int Id, OrderDto order)
        {
            try
            {
                var oder = _orderService.CreateOrder(Id, order);
                return Ok(oder);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                var result = _orderService.DeleteOrder(orderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting order: {ex.Message}");
            }
        }

        [HttpPut("{orderId}")]
        public IActionResult UpdateOrder(int orderId, [FromBody] Update updatedOrderDto)
        {
            try
            {
                var result = _orderService.UpdateOrder(orderId, updatedOrderDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating order: {ex.Message}");
            }
        }

        [HttpPut("all")]
        public IActionResult Getall()
        {
            try
            {
                var result = _orderService.Getall();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating order: {ex.Message}");
            }
        }

    }
}
