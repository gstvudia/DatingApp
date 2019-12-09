using Boia.API.Data;
using Boia.API.Data.DTO;
using Boia.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Boia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDTO userForRegisterDTO)
        {
            {
                //validate request
                userForRegisterDTO.Username = userForRegisterDTO.Username.ToLower();

                if (await _authRepository.UserExists(userForRegisterDTO.Username))
                {
                    return BadRequest("Username already exists");
                }

                var userToCreate = new User
                {
                    Username = userForRegisterDTO.Username
                };

                var createdUser = await _authRepository.Register(userToCreate, userForRegisterDTO.Password);

                return StatusCode(201);
            }
        }
    }
}
