using DAY5.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DAY5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManagement studentManagement;
        public StudentController(IStudentManagement studentManagement)
        {
            this.studentManagement = studentManagement;
        }

        [HttpGet("GetStudents")]
        public IActionResult GetStudentsController()
        {
            var studentList = studentManagement.GetStudents();
            if (!studentList.Any())
            {
                return NotFound("NO STUDENTS FOUND");
            }
            return Ok(studentList);
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudentsController([FromBody] Student student)
        {
            var msg = studentManagement.AddStudent(student);
            if (msg == "STUDENT ADDED")
            {
                return Ok(msg);
            }
            return BadRequest(msg);
        }

        [HttpDelete("RemoveStudent")]
        public IActionResult RemoveStudentsController([FromBody] Student student)
        {
            var msg = studentManagement.RemoveStudent(student);
            if (msg == "STUDENT REMOVED")
            {
                return Ok(msg);
            }
            return BadRequest(msg);
        }

        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudentsController([FromBody] Student student)
        {
            var msg = studentManagement.UpdateStudent(student);
            if (msg == "STUDENT UPDATED")
            {
                return Ok(msg);
            }
            return BadRequest(msg);
        }
    }
}
