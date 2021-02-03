using Microsoft.AspNetCore.Mvc;

namespace ElsoWebSzerver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("{id}/minta")]
        public string Get([FromQuery] string adat, int id)
        {
            return $"ID: {id}, Hello {adat}";
        }

        [HttpPost]
        public string Post([FromBody] string adat)
        {
            return $"Hello {adat}";
        }
    }
}
