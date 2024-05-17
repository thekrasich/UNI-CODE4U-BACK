using AutoMapper;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.DTOs;
using CashRegisterStore.DAL.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByKey(int id)
        {
            var product = await _productRepository.GetByKey(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _productRepository.Add(product);
            return CreatedAtAction(nameof(GetProductByKey), new { id = product.Id }, product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteByKey(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;
            await _productRepository.UpdateProduct(product);
            return NoContent();

        }
    }
}
