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
    public class SubSubcategoryController : ControllerBase
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IMapper _mapper;
        public SubSubcategoryController(ISubcategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }
       

        [HttpGet]
        public async Task<ActionResult<List<Subcategory>>> GetAllSubcategories()
        {
            var subcategories = await _subcategoryRepository.GetAll();
            return Ok(subcategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subcategory>> GetSubcategoryByKey(short id)
        {
            var subcategory = await _subcategoryRepository.GetByKey(id);
            return Ok(subcategory);
        }

        [HttpPost]
        public async Task<ActionResult<Subcategory>> CreateSubcategory(Subcategory subcategory)
        {
            await _subcategoryRepository.Add(subcategory);
            return CreatedAtAction(nameof(GetSubcategoryByKey), new { id = subcategory.Id }, subcategory);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubcategory(short id)
        {
            await _subcategoryRepository.DeleteByKey(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubcategory(short id, SubcategoryDto subcategoryDto)
        {
            var subcategory = _mapper.Map<Subcategory>(subcategoryDto);
            subcategory.Id = id;
            await _subcategoryRepository.UpdateSubcategory(subcategory);
            return NoContent();
        }
    }
}
