using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
  public interface IFurnishingTypeRepository
  {
    Task<IEnumerable<FurnishingType>> GetFurnishingTypesAsync();

  }
}
