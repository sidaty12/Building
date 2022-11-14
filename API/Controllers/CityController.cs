using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetCities()
    {
      var cities = await dc.cities.ToListAsync();
      return Ok(cities);
       }
    }


  }

