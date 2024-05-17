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
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;
        public PhotoController(IPhotoRepository photoRepository, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Photo>>> GetAllPhotos()
        {
            var photos = await _photoRepository.GetAll();
            return Ok(photos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetPhotoByKey(long id)
        {
            var photo = await _photoRepository.GetByKey(id);
            return Ok(photo);
        }

        [HttpPost]
        public async Task<ActionResult<Photo>> CreatePhoto(Photo photo)
        {
            await _photoRepository.Add(photo);
            return CreatedAtAction(nameof(GetPhotoByKey), new { id = photo.Id }, photo);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoto(long id)
        {
            await _photoRepository.DeleteByKey(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePhoto(long id, PhotoDto photoDto)
        {
            var photo = _mapper.Map<Photo>(photoDto);
            photo.Id = id;
            await _photoRepository.UpdatePath(photo);
            return NoContent();

        }
    }
}
