using DAY4.Classes;
using Microsoft.AspNetCore.Mvc;

namespace DAY4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminVerificationController : Controller
    {
        [HttpPost(Name = "AdminVerification")]
        public IActionResult Post([FromQuery]string password)
        {
            return Ok("PASSWORD VERIFIED");
        }
    }
}
