using API.Dtos;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
  
  public class FurnishingTypeController : BaseController
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public FurnishingTypeController(IUnitOfWork uow, IMapper mapper)
    {
      this.uow = uow;
      this.mapper = mapper;
    }

    // GET api/furnishingtypes
    [HttpGet("list")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFurnishingTypes()
    {
      var furnishingTypes = await uow.FurnishingTypeRepository.GetFurnishingTypesAsync();
      var furnishingTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(furnishingTypes);
      return Ok(furnishingTypesDto);
    }
  }
}
