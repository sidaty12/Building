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
      return await dc.cities.ToListAsync();
    }
    public void AddCity(City city)
     {
         dc.cities.AddAsync(city);
     }

     public void DeleteCity(int CityId)
     {
         var city = dc.cities.Find(CityId);
         dc.cities.Remove(city);
     }

    public async Task<City> FindCity(int id)
    {
      return await dc.cities.FindAsync(id);
    }
  }
}
