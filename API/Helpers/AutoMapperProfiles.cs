using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    { 
      CreateMap<City, CityDto>().ReverseMap();
    }
  }
}
