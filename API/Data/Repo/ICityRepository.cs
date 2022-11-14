using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Data.Repo

{
    public interface ICityRepository
    {
          Task<IEnumerable<City>> GetCitiesAsync();

          void AddCity(City city);

          void DeleteCity(int CityId);

          Task<bool> SaveAsync();
    }
}
