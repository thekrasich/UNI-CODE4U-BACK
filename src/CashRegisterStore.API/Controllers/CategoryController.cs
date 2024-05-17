using AutoMapper;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.DTOs;
using CashRegisterStore.DAL.Repository.Abstract;
using CashRegisterStore.DAL.Repository.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace CashRegisterStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryByKey(short id)
        {
            var category = await _categoryRepository.GetByKey(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            await _categoryRepository.Add(category);
            return CreatedAtAction(nameof(GetCategoryByKey), new { id = category.Id }, category);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(short id)
        {
            await _categoryRepository.DeleteByKey(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(short id, CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.Id = id;
            await _categoryRepository.UpdateName(category);
            return NoContent();
        }
    }
}
