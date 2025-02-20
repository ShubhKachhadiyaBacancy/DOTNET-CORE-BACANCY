using DAY3.Additional_Task_Classes;
using Microsoft.AspNetCore.Mvc;

namespace DAY3.Controllers
{   
    [ApiController]
    [Route("guid")]
    public class GuidController : ControllerBase
    {
        private readonly IGuidSingleton _singletonGuid;
        private readonly IGuidScoped _scopedGuid;
        private readonly IGuidTransient _transientGuid;

        public GuidController(IGuidSingleton singletonGuid, IGuidScoped scopedGuid, IGuidTransient transientGuid)
        {
            _singletonGuid = singletonGuid;
            _scopedGuid = scopedGuid;
            _transientGuid = transientGuid;
        }

        [HttpGet]
        public IActionResult GetGuids()
        {
            Console.WriteLine($"SINGLETON : {_singletonGuid.GetGuid()}");
            Console.WriteLine($"TRANSIENT : {_transientGuid.GetGuid()}");
            Console.WriteLine($"SCOPED : {_scopedGuid.GetGuid()}");
            Console.WriteLine();    
            return Ok();
        }
    }
}