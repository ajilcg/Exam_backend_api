using Exam.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreExam.Data;
using PreExam.Model;

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            this._context = context;

        }
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            if (_context.courses == null)
            {
                return Enumerable.Empty<Course>();
            }
            return _context.courses.ToList();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Course>> Post(Course course)
        {
            if (course == null)
            {
                return BadRequest("student Null");
            }
            else
            {

            _context.courses.Add(course);
            await _context.SaveChangesAsync();
            }
            return Ok();

        }
    }
}
