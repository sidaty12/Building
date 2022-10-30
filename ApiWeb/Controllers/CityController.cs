using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWeb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    // GET: api/<CityController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "Atzlanta", "New York;  " +
        "" };
    }

    // GET api/<CityController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<CityController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<CityController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CityController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
