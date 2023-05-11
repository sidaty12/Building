using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceMongo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MongoCityController : ControllerBase
  {
    [HttpGet("test")]
    public IActionResult TestGetMethod()
    {
      return Ok("Test GET method works!");
    }
  }
}
