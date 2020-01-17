using Boia.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Boia.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _datingRepository;

        public UsersController(IDatingRepository datingRepository)
        {
            _datingRepository = datingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _datingRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            var user = await _datingRepository.GetUser(Id);
            return Ok(user);
        }


    }
}
