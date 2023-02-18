using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Interfaces;
using API.Models;
using System;

namespace API.Controllers
{
  public class PropertyController : BaseController
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;
    private readonly IPhotoService photoService;

    public PropertyController(IUnitOfWork uow,
    IMapper mapper,
    IPhotoService photoService)
    {
      //  this.photoService = photoService;
      this.uow = uow;
      this.mapper = mapper;
      this.photoService = photoService;
    }

    //property/list/1
    [HttpGet("list/{sellRent}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPropertyList(int sellRent)
    {
      var properties = await uow.PropertyRepository.GetPropertiesAsync(sellRent);
      var propertyListDTO = mapper.Map<IEnumerable<PropertyListDto>>(properties);
      return Ok(propertyListDTO);
    }

    [HttpGet("detail/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPropertyDetail(int id)
    {
      var property = await uow.PropertyRepository.GetPropertyDetailAsync(id);
      var propertyDTO = mapper.Map<PropertyDetailDto>(property);
      return Ok(propertyDTO);
    }

    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> AddProperty(PropertyDto propertyDto)
    {
      var property = mapper.Map<Property>(propertyDto);
      var userId = GetUserId();
      property.PostedBy = userId;
      property.LastUpdatedBy = userId;
      uow.PropertyRepository.AddProperty(property);
      await uow.SaveAsync();
      return StatusCode(201);
    }


    [HttpPost("add/photo/{propId}")]
    [Authorize]
    public async Task<IActionResult> AddPropertyPhoto(IFormFile file, int propId)
    {
      var result = await photoService.UploadPhotoAsync(file);
      if (result.Error != null)
        return BadRequest(result.Error.Message);

      var property = await uow.PropertyRepository.GetPropertyByIdAsync(propId);

      var photo = new Photo
      {
        ImageUrl = result.SecureUrl.AbsoluteUri,
        PublicId = result.PublicId,
      };

      if (property.Photos.Count == 0)
      {
        photo.IsPrimary = true;
      }

      property.Photos.Add(photo);
      await uow.SaveAsync();
      return StatusCode(201);
    }

    [HttpPost("set-primary-photo/{propId}/{photoPublicId}")]
    [Authorize]
    public async Task<IActionResult> SetPrimaryPhoto(int propId, string photoPublicId)
    {
      var userId = GetUserId();

      var property = await uow.PropertyRepository.GetPropertyByIdAsync(propId);

      if (property == null)
      {
        return BadRequest("No such property or photo exists");
      }
      var P = property.PostedBy;
      if (P != userId)
      {
        return BadRequest("You are not authorised to change the photo");
      }

      var photo = property.Photos.FirstOrDefault(p => p.PublicId == photoPublicId);

      if (photo == null)
        return BadRequest("No such property or photo exists");

      if (photo.IsPrimary)
        return BadRequest("This is already a primary photo");

      var currentPrimary = property.Photos.FirstOrDefault(p => p.IsPrimary);
      if (currentPrimary == null) currentPrimary.IsPrimary = false;
      photo.IsPrimary = true;

      if (await uow.SaveAsync()) return NoContent();

      return BadRequest("Some error has occured, failed to set primary photo");
    }
  }
}
