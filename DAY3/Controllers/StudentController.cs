using DAY3.Classes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DAY3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ISaveFile saveFile;

        public StudentController(ISaveFile saveFile)
        {
            this.saveFile = saveFile;
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Student> newStudents)
        {
            try
            {
                saveFile.SaveText(newStudents);
                return Ok("TEXT ADDED");
            }
            catch (Exception ex) 
            {
                return BadRequest("ERROR OCCURRED");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var students = saveFile.RetrieveText();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest("ERROR OCCURRED");
            }
        }

    }
}