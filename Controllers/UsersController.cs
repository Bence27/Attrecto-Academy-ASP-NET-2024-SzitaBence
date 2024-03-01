using Academy_2024.Models;
using Academy_2024.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//calculator nugetpackage lertehozasa
//Course controller alap CRUD muveletekkel ()
namespace Academy_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }



        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user=_userRepository.GetById(id);
            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User data)
        {
            _userRepository.Create(data);
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User data)
        {
            var user= _userRepository.Update(id,data);
            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _userRepository.Delete(id)?NoContent():NotFound();
            
        }
    }
}
