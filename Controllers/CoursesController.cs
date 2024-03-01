using Academy_2024.Models;
using Academy_2024.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private CourseRepository _courseRepository;

        public CoursesController()
        {
            _courseRepository = new CourseRepository();
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course=_courseRepository.GetById(id);
            return course == null ? NotFound() : course;
        }

        // POST api/<CoursesController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            _courseRepository.Create(data);
            return NoContent();
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course value)
        {
            var course=_courseRepository.Update(id, value);
            return course==null?NotFound():NoContent();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _courseRepository.Delete(id)?NoContent():NotFound();
        }
    }
}
