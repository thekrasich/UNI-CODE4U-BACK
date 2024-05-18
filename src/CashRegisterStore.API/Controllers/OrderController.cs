using AutoMapper;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.DTOs;
using CashRegisterStore.DAL.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByKey(long id)
        {
            var order = await _orderRepository.GetByKey(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            await _orderRepository.Add(order);
            return CreatedAtAction(nameof(GetOrderByKey), new { id = order.Id }, order);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(long id)
        {
            await _orderRepository.DeleteByKey(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(long id, OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.Id = id;
            await _orderRepository.UpdateStatus(order);
            return NoContent();
        }
    }
}
