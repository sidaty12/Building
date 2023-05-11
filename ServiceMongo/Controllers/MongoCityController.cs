using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceMongo.Models;
using ServiceMongo.Repo;

namespace ServiceMongo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MongoCityController : ControllerBase
  {
    private readonly ICityMongoRepo _citymongorepo;
    public MongoCityController(ICityMongoRepo citymongorepo)
    {
      _citymongorepo = citymongorepo;
    }

    [HttpGet("Cities")]
    public IActionResult GetCities()
    {
      return Ok(_citymongorepo.GetMongoCities());
    }

    [HttpGet("{id}", Name = "GetCity")]
    public IActionResult GetCity(string id)
    {
      return Ok(_citymongorepo.GetMongoCity(id));
    }

    [HttpPost("addcity")]
    public IActionResult AddCity(MongoCity mongoCity)
    {
      var createdMongoCity = _citymongorepo.AddMongoCity(mongoCity);
      return CreatedAtRoute("GetCity", new { id = createdMongoCity.Id }, createdMongoCity);
    }


    [HttpPut("Updatecity")]
    public IActionResult UpdateBook(MongoCity mongoCity)
    {
      return Ok(_citymongorepo.UpdateMongoCity(mongoCity));
    }

    [HttpDelete("deletecity/{id}")]
    public IActionResult DeleteCity(string id)
    {
      _citymongorepo.DeleteMongoCity(id);
      return NoContent();
    }

    [HttpGet("test")]
    public IActionResult TestGetMethod()
    {
      return Ok("Test GET method works!");
    }

  }
}
