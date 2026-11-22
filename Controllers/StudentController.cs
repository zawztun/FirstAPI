using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static private List<Student> students = new List<Student>
        {
           new Student
    {
        Id = 1,
        FirstName = "Tony",
        LastName = "Wiff",
        DateOfBirth = new DateTime(2020, 1, 1)
    },
    new Student
    {
        Id = 2,
        FirstName = "Zaw",
        LastName = "Tun",
        DateOfBirth = new DateTime(2020, 1, 22)
    },
    new Student
    {
        Id = 3,
        FirstName = "Kai",
        LastName = "Goun",
        DateOfBirth = new DateTime(2021, 1, 2)
    },
    new Student
    {
        Id = 4,
        FirstName = "Zackel",
        LastName = "Bon",
        DateOfBirth = new DateTime(1999, 9, 2)
    },
    new Student
    {
        Id = 5,
        FirstName = "James",
        LastName = "Doe",
        DateOfBirth = new DateTime(1990, 1, 22)
    }

        };

        [HttpGet]

        public ActionResult <List<Student>> GetStudents()
        {
            return Ok(students);
        }


        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]

        public ActionResult<Student> AddStudent(Student newStudent)
        {
            if (newStudent == null)
                return BadRequest();

            newStudent.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1;
            students.Add(newStudent);

            return CreatedAtAction(nameof(AddStudent), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateStudent(int id, Student updateStudent)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            student.Id = updateStudent.Id;
            student.FirstName = updateStudent.FirstName;
            student.LastName = updateStudent.LastName;
            student.DateOfBirth = updateStudent.DateOfBirth;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(x=>x.Id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);
            return NoContent();
        }

    }
}
