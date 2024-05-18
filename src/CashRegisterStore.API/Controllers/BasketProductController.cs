using AutoMapper;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.DTOs;
using CashRegisterStore.DAL.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketProductController : ControllerBase
    {
        private readonly IBasketProductRepository _productRepository;
        private readonly IMapper _mapper;

        public BasketProductController(IBasketProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<BasketProduct>>> GetAllBasketsProducts()
        {
            var basketProducts = await _productRepository.GetAll();
            return Ok(basketProducts);
        }

        [HttpGet("{basketId}/{productId}")]
        public async Task<ActionResult<BasketProduct>> GetBasketProductByKey(long basketId, int productId)
        {
            var basketProduct = await _productRepository.GetByKey(basketId,productId);
            return Ok(basketProduct);
        }

        [HttpPost]
        public async Task<ActionResult<BasketProduct>> CreateBasketProduct(BasketProduct basketProduct)
        {
            await _productRepository.Add(basketProduct);
            return CreatedAtAction(nameof(GetBasketProductByKey), new { basketId = basketProduct.BasketId, productId = basketProduct.ProductId }, basketProduct);
        }
        [HttpDelete("{basketId}/{productId}")]
        public async Task<ActionResult> DeleteBasketProduct(long basketId, int productId)
        {
            await _productRepository.DeleteByKey(basketId, productId);
            return NoContent();
        }
        [HttpPut("{basketId}/{productId}")]
        public async Task<ActionResult> UpdateBasketProduct(long basketId, int productId, BasketProductDto basketProductDto)
        {
            var basketProduct = _mapper.Map<BasketProduct>(basketProductDto);
            basketProduct.BasketId = basketId;
            basketProduct.ProductId = productId;
            await _productRepository.UpdateQuantity(basketProduct);
            return NoContent();
        }

    }
}
