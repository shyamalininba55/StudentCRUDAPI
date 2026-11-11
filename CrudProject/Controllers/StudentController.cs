using CrudProject.Db;
using CrudProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Student s1)
        {
            _db.Add(s1);
            _db.SaveChanges();
            return Ok(s1);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Student> students = new List<Student>();
            students = _db.students.ToList();
            return Ok(students);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult Get(int id)
        {
            var student = _db.students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Student s1)
        {
            var student = _db.students.FirstOrDefault(x => x.Id == s1.Id);

            if (student == null)
            {
                return NotFound();
            }

            student.Name = s1.Name;
            student.Address = s1.Address;
            student.PhoneNo = s1.PhoneNo;

            _db.SaveChanges();

            return Ok(student);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var student = _db.students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound();  
            }

            _db.students.Remove(student);
            _db.SaveChanges();

            return Ok(student);
        }
    }
}