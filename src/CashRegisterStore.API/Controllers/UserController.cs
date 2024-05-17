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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByKey(long id)
        {
            var user = await _userRepository.GetByKey(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            await _userRepository.Add(user);
            return CreatedAtAction(nameof(GetUserByKey), new { id = user.Id }, user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            await _userRepository.DeleteByKey(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(long id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;
            await _userRepository.UpdateUser(user);
            return NoContent();

        }
    }
}
