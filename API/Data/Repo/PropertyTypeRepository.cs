using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Repo
{
  public class PropertyTypeRepository : IPropertyTypeRepository
  {
    private readonly DataContext dc;

    public PropertyTypeRepository(DataContext dc)
    {
      this.dc = dc;
    }
    public async Task<IEnumerable<PropertyType>> GetPropertyTypesAsync()
    {
      return await dc.PropertyTypes.ToListAsync();
    }
  }
}
