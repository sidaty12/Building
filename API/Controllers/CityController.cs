using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Data.Repo;
using API.Interfaces;
using API.Dtos;
using System;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWeb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private readonly IUnitOfWork uow;

    private readonly IMapper mapper;

    public CityController(IUnitOfWork uow, IMapper mapper){

      this.uow = uow;

      this.mapper = mapper;
    }
    // GET: api/<CityController>
    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
      var cities = await uow.CityRepository.GetCitiesAsync();

      var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
    
      return Ok(citiesDto);
    }

    [HttpPost("post")]
    public async Task<IActionResult> AddCity(CityDto cityDto)
    {

      var city = mapper.Map<City>(cityDto);
      city.LastUpdatedBy = 1;
   
      uow.CityRepository.AddCity(city);
      await uow.SaveAsync();
      return StatusCode(201);
       }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {

      uow.CityRepository.DeleteCity(id);
      await uow.SaveAsync();
      return Ok(id);
       }

        // POST: api/city/add?cityname=Miami
      // POST: api/city/add/los Angelos


    /*  [HttpPost("add")]
      [HttpPost("add/{cityName}")]
    public async Task<IActionResult> AddCity(string cityName)
    {
      City city = new City();
      city.Name = cityName;
      await dc.cities.AddAsync(city);
      await dc.SaveChangesAsync();
      return Ok(city);
       }
*/
 // POST: api/city/post --post the data in json format
    }


    }


