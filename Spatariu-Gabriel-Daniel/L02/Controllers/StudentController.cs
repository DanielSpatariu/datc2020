using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class StudentController
    {

        [ApiController]
        [Route("[controller]")]
        public class StudentControllers : ControllerBase
        {
            [HttpGet]
            public IEnumerable<Student> GetStudents()
            {
                return Stud.getAll();
            }

            [HttpGet("{id}")]
            public Student GetStudentsbyId([FromRoute] int id)
            {
                return Stud.getById(id);
            }

            [HttpPost]
            public string CreateStudent([FromBody] Student student)
            {
                try
                {
                    Console.WriteLine(student.ToString());
                    Stud.insert(student);
                    return "Student created successfully";
                }
                catch (System.Exception error)
                {
                    return "Eroare: " + error.Message;
                    throw;
                }
            }

            [HttpPut("{id}")]
            public string UpdateStudent([FromRoute] int id, [FromBody] Student student)
            {
                Student updatedStudent = Stud.update(id, student);
                return updatedStudent.ToString();
            }

            [HttpDelete("{id}")]
            public string DeleteStudentById([FromRoute] int id)
            {
                Stud.deleteById(id);
                return "Student removed successfully";
            }
        }
    }
}
