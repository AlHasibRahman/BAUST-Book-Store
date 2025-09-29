using System.Threading.Tasks;
using AutoMapper;
using BAUST_Book_Store.Models.Domain;
using BAUST_Book_Store.Models.Dtos;
using BAUST_Book_Store.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAUST_Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository repository;
        private readonly IMapper mapper;

        public ProfileController(IProfileRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var userDomain = await repository.GetAllUserAsync();
            var userDto = mapper.Map<List<UserProfileDto>>(userDomain);
            return Ok(userDto);
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var idStr = id.ToString();
            if (idStr.Length != 16) return BadRequest("Id must be 16 digits");
            var userDomain = await repository.GetUserByIdAsync(id);
            var userDto = mapper.Map<UserProfileDto>(userDomain);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserProfileDto createProfile)
        {

            var userDomain = mapper.Map<UserProfile>(createProfile);
            userDomain = await repository.CreateUserAsync(userDomain);
            var userDto = mapper.Map<UserProfileDto>(userDomain);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UpdateUserProfileDto updateUser)
        {
            var userDomain = mapper.Map<UserProfile>(updateUser);
            userDomain = await repository.UpdateUserAsync(id, userDomain);
            if (userDomain is null)
            {
                return NotFound();
            }
            var userDto = mapper.Map<UserProfileDto>(userDomain);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);

        }
        
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteBook([FromRoute] long id)
        {
            try
            {
                await repository.DeleteUserByIdAsync(id);
                return NoContent(); // 204
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // 404
            }
        }


    }
}
