using API.Data.Mongo.Interfaces;
using API.Data.Mongo.MongoModels;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace API.Controllers
{
  [Route("api/[controller]")]

  [ApiController]
  public class MongCityController : ControllerBase
  {
    private readonly ICityRepo _cityRepository;
    private readonly ILogger<MongCityController> _logger;


    public MongCityController(ICityRepo cityRepository, ILogger<MongCityController> logger)
    {
      _cityRepository = cityRepository;
      _logger = logger;
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
      _logger.LogInformation($"Recherche de la ville avec l'identifiant : {id}");

      var city = await _cityRepository.GetByIdAsync(id);

      if (city == null)
      {
        _logger.LogWarning($"Aucune ville trouvée avec l'identifiant : {id}");

        return NotFound();
      }

      _logger.LogInformation($"Ville trouvée : {city.Name}, {city.Country}");

      return Ok(city);
    }

    [HttpGet("test")]
    public IActionResult TestGetMethod()
    {
      return Ok("Test GET method works!");
    }


  }
}
