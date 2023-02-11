using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
  public interface IPropertyTypeRepository
  {
    Task<IEnumerable<PropertyType>> GetPropertyTypesAsync();

  }
}
