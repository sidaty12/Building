using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Repo
{
  public class FurnishingTypeRepository : IFurnishingTypeRepository
  {
    private readonly DataContext dc;

    public FurnishingTypeRepository(DataContext dc)
    {
      this.dc = dc;
    }
    public async Task<IEnumerable<FurnishingType>> GetFurnishingTypesAsync()
    {
      return await dc.FurnishingType.ToListAsync();
    }
  }
}
