using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


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

   

     public async Task<bool> SaveAsync()
     {
          return await dc.SaveChangesAsync() > 0;
     }

   
  }
}
