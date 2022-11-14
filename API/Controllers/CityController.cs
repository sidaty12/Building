using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

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

   // POST: api/city/add?cityname=Miami
      // POST: api/city/add/los Angelos


      [HttpPost("add")]
       [HttpPost("add/{cityName}")]


    public async Task<IActionResult> AddCity(string cityName)
    {
      City city = new City();
      city.Name = cityName;
      await dc.cities.AddAsync(city);
      await dc.SaveChangesAsync();
      return Ok(city);
       }

 // POST: api/city/post --post the data in json format

    [HttpPost("post")]
    public async Task<IActionResult> AddCity(City city)
    {
      //City city = new City();
      //city.Name = cityName;
      await dc.cities.AddAsync(city);
      await dc.SaveChangesAsync();
      return Ok(city);
       }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {

      var city = await dc.cities.FindAsync(id);
       dc.cities.Remove(city);
      await dc.SaveChangesAsync();
      return Ok(id);
       }
    }


    }


