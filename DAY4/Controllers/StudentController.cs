using DAY4.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DAY4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost(Name="Register Student")]
        public IActionResult Post([FromBody] Student student)
        {
            studentService.AddStudent(student);
            return Ok("STUDENT REGISTERED");
        }

        [HttpGet(Name ="Retrieve Students")]
        public IActionResult Get() 
        {
            if (!System.IO.File.Exists("StudentDetails.txt"))
            {
                return BadRequest("FILE NOT FOUND");
            }
                
            try
            {
                string text = System.IO.File.ReadAllText("StudentDetails.txt");
                if (text == "" || text == null)
                {
                    return BadRequest("FILE IS EMPTY");
                }
                return Ok(text);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
