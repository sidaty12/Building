using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Interfaces;

namespace API.Data.Repo
{
  public class CityRepository : ICityRepository
  {

     private readonly DataContext dc;


     public CityRepository(DataContext dc)
     {
      this.dc = dc;
     }

   public async Task<IEnumerable<City>> GetCitiesAsync()
    {
      return await dc.Cities.ToListAsync();
    }
    public void AddCity(City city)
     {
         dc.Cities.AddAsync(city);
     }

     public void DeleteCity(int CityId)
     {
         var city = dc.Cities.Find(CityId);
         dc.Cities.Remove(city);
     }

    public async Task<City> FindCity(int id)
    {
      return await dc.Cities.FindAsync(id);
    }
  }
}
