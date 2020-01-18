using AutoMapper;
using Boia.API.Data;
using Boia.API.Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boia.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _datingRepository;
        private readonly IMapper _mapper;

        public UsersController(IDatingRepository datingRepository, IMapper mapper)
        {
            _datingRepository = datingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _datingRepository.GetUsers();
            var userToReturn = _mapper.Map<IEnumerable<UserForListDTO>>(users);

            return Ok(userToReturn);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            var user = await _datingRepository.GetUser(Id);
            var userToReturn = _mapper.Map<UserForDetailedDTO>(user);

            return Ok(userToReturn);
        }


    }
}
