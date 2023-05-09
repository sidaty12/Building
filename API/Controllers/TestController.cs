using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {
    [HttpGet]
    public ActionResult<string> Get()
    {
      return Ok("Hello, world!");
    }
  }
}
