using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Data;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWeb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {

    private readonly DataContext dc;
    public CityController(DataContext dc){

       this.dc = dc;
    }
    // GET: api/<CityController>
    [HttpGet]
    public IActionResult GetCities()
    {
      var cities = dc.cities.ToList();
      return Ok(cities);
       }
    }


  }

