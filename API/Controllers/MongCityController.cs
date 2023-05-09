using API.Data.Mongo.Interfaces;
using API.Data.Mongo.MongoModels;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
  [Route("api/[controller]")]

  [ApiController]
  public class MongCityController : ControllerBase
  {
    private readonly ICityRepo _cityRepository;

    public MongCityController(ICityRepo cityRepository)
    {
      _cityRepository = cityRepository;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MongoCity>>> GetCities()
    {
      var cities = await _cityRepository.GetAllAsync();
      return Ok(cities);
    }

    // GET: api/cities/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<MongoCity>> GetCity(string id)
    {
      var city = await _cityRepository.GetByIdAsync(id);

      if (city == null)
      {
        return NotFound();
      }

      return Ok(city);
    }

  }
}
