using API.Interfaces;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{

  public class PropertyTypeController : BaseController
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public PropertyTypeController(IUnitOfWork uow, IMapper mapper)
    {
      this.uow = uow;
      this.mapper = mapper;
    }

    // GET api/propertytype/list
    [HttpGet("list")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPropertyTypes()
    {
      var PropertyTypes = await uow.PropertyTypeRepository.GetPropertyTypesAsync();
      var PropertyTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(PropertyTypes);
      return Ok(PropertyTypesDto);
    }

  }
}
