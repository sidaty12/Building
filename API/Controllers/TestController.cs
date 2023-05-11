using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {
    [HttpGet("test")]
    public IActionResult TestGetMethod()
    {
      return Ok("Test GET method works!");
    }
  }
}
