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

namespace API.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork uow;
       // private readonly IMapper mapper;
       // private readonly IPhotoService photoService;

        public PropertyController(IUnitOfWork uow
        //IMapper mapper
        )
        {
          //  this.photoService = photoService;
            this.uow = uow;
            //this.mapper = mapper;
        }

          //property/list/1
        [HttpGet("type/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellRent)
        {
            var properties = await uow.PropertyRepository.GetPropertiesAsync(sellRent);
            //var propertyListDTO = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(properties);
        }
    }
}
