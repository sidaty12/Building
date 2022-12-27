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
using Microsoft.AspNetCore.JsonPatch;
using API.Controllers;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWeb.Controllers
{

  [Authorize]
  public class CityController : BaseController
  {
    private readonly IUnitOfWork uow;

    private readonly IMapper mapper;

    public CityController(IUnitOfWork uow, IMapper mapper){

      this.uow = uow;

      this.mapper = mapper;
    }
    // GET: api/<CityController>

    [HttpGet ("cities")]
    [AllowAnonymous]

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
      city.LastUpdatedOn = DateTime.Now;
      uow.CityRepository.AddCity(city);
      await uow.SaveAsync();
      return StatusCode(201);
       }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
    {
      if (id != cityDto.Id)
        return BadRequest("Update not allowed");

      var cityFromDb = await uow.CityRepository.FindCity(id);

      if (cityFromDb == null)
        return BadRequest("Update not allowed");
      cityFromDb.LastUpdatedBy = 1;
      cityFromDb.LastUpdatedOn = DateTime.Now;
      mapper.Map(cityDto, cityFromDb);

      //throw new Exception("some unknown error occured");
      await uow.SaveAsync();
      return StatusCode(200);
    }

    [HttpPut("updateCityName/{id}")]
    public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
    {
      var cityFromDb = await uow.CityRepository.FindCity(id);
      cityFromDb.LastUpdatedBy = 1;
      cityFromDb.LastUpdatedOn = DateTime.Now;
      mapper.Map(cityDto, cityFromDb);
      await uow.SaveAsync();
      return StatusCode(200);
    }

    [HttpPatch("update/{id}")]
    public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
    {
      var cityFromDb = await uow.CityRepository.FindCity(id);
      cityFromDb.LastUpdatedBy = 1;
      cityFromDb.LastUpdatedOn = DateTime.Now;
      cityToPatch.ApplyTo(cityFromDb, ModelState);
     // mapper.Map(cityDto, cityFromDb);
      await uow.SaveAsync();
      return StatusCode(200);
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


