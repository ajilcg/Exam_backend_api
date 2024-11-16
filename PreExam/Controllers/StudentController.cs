using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using PreExam.Data;
using PreExam.Model;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            this._context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            if (_context.students == null)
            {
                return Enumerable.Empty<Student>();
            }
            return _context.students.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
          var val= await _context.students.FindAsync(id);
            if (val == null)
            {
                return NotFound();
            }
            return val;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student student)
        {
            if (student == null)
            {
                return BadRequest("student Null");
            }
            _context.students.Add(student);
            await _context.SaveChangesAsync();
            return Ok();

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Student student)
        {
            if (id != student.Id)
            {
                return  BadRequest("Invalid Id");
            }
            var employ = await _context.students.FindAsync(id);
            employ.Name = student.Name;
            employ.Email = student.Email;
 
          _context.students.Update(employ);
             await _context.SaveChangesAsync();
        
            return Ok();


         }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var val = await _context.students.FindAsync(id);

             _context.students.Remove(val);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
