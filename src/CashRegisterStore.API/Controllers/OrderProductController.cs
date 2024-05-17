using AutoMapper;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.DTOs;
using CashRegisterStore.DAL.Repository.Abstract;
using CashRegisterStore.DAL.Repository.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IMapper _mapper;

        public OrderProductController(IOrderProductRepository orderProductRepository, IMapper mapper)
        {
            _orderProductRepository= orderProductRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderProduct>>> GetAllOrdersProducts()
        {
            var orderProducts = await _orderProductRepository.GetAll();
            return Ok(orderProducts);
        }

        [HttpGet("{orderId}/{productId}")]
        public async Task<ActionResult<OrderProduct>> GetOrderProductByKey(long orderId, int productId)
        {
            var orderProduct = await _orderProductRepository.GetByKey(orderId, productId);
            return Ok(orderProduct);
        }

        [HttpPost]
        public async Task<ActionResult<OrderProduct>> CreateOrderProduct(OrderProduct orderProduct)
        {
            await _orderProductRepository.Add(orderProduct);
            return CreatedAtAction(nameof(GetOrderProductByKey), new { orderId = orderProduct.OrderId, productId = orderProduct.ProductId }, orderProduct);
        }
        [HttpDelete("{orderId}/{productId}")]
        public async Task<ActionResult> DeleteOrderProduct(long orderId, int productId)
        {
            await _orderProductRepository.DeleteByKey(orderId, productId);
            return NoContent();
        }
        [HttpPut("{orderId}/{productId}")]
        public async Task<ActionResult> UpdateOrderProduct(long orderId, int productId, OrderProductDto orderProductDto)
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductDto);
            orderProduct.OrderId = orderId;
            orderProduct.ProductId = productId;
            await _orderProductRepository.UpdateQuantity(orderProduct);
            return NoContent();
        }
    }
}
