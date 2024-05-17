using AutoMapper;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Basket>>> GetAllBaskets()
        {
            var baskets = await _basketRepository.GetAll();
            return Ok(baskets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Basket>> GetBasketByKey(long id)
        {
            var basket = await _basketRepository.GetByKey(id);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> CreateBasket(Basket basket)
        {
            await _basketRepository.Add(basket);
            return CreatedAtAction(nameof(GetBasketByKey), new { id = basket.Id }, basket);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasket(long id)
        {
            await _basketRepository.DeleteByKey(id);
            return NoContent();
        }
       
    }
}
            
        

