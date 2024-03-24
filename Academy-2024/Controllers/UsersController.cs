using Academy_2024.Dtos;
using Academy_2024.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> GetMe()
        {
            string token = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last()!;

            return await _userService.GetMeAsync(token);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] UserDto data)
        {
            await _userService.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto data)
        {
            var user = await _userService.UpdateAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await _userService.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
