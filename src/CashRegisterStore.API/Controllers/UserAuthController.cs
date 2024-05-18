using CashRegisterStore.DAL.Auth;
using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.DTOs.UserAuth;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CashRegisterStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthController : Controller
    {
        public CashRegisterStoreDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UserAuthController(CashRegisterStoreDbContext context, UserManager<User> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> Token([FromBody] UserLoginDto userLoginDto)
        {
            var identity = await GetUser(userLoginDto.Email, userLoginDto.Password);

            if (identity == null)
            {
                return NotFound(new { errorText = "Invalid Login or Password." });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOption.ISSUER,
                    audience: AuthOption.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOption.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto dto)
        {
            var user = new User
            {
                Name = dto.FirstName,
                Surname = dto.LastName,
                UserName = dto.FirstName + "_" + dto.LastName,
                Role = dto.Role,
                Email = dto.Email,
                PhoneNumber = dto.Phone
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                _dbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    Console.WriteLine(item.Description);
                }
                return BadRequest(result.Errors);
            }
        }


        [HttpGet]
        [Route("get-user")]
        [Authorize("Bearer")]
        public IActionResult GetUser()
        {
            var userIdClaim = User.Claims;

            if (userIdClaim == null)
            {
                return NotFound();
            }

            var nameClaim = userIdClaim.Where(x => x.Type
             == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
             .FirstOrDefault();

            if (nameClaim == null)
            {
                return Forbid();
            }
            else
            {
                var userId = long.Parse(nameClaim.Value);
                var currentUser = _dbContext.Users.Where(x => x.Id == userId).First();

                var returnResult = new UserInfoDto()
                {
                    Id = currentUser.Id,
                    FirstName = currentUser.Name,
                    LastName = currentUser.Surname,
                    Email = currentUser.Email,
                    Role = currentUser.Role,
                    Phone = currentUser.PhoneNumber
                };
                return Ok(returnResult);
            }
        }

        private async Task<ClaimsIdentity?> GetUser(string email, string password)
        {

            User user = _dbContext.Users.FirstOrDefault(x => x.Email == email);

            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (user != null && result != PasswordVerificationResult.Failed)
            {
                var claims = new List<Claim>
                {
                    new(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                new(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
