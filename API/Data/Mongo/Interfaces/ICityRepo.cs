using API.Data.Mongo.MongoModels;
using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Mongo.Interfaces
{
  public interface ICityRepo
  {
    Task<IEnumerable<MongoCity>> GetAllAsync();
    Task<MongoCity> GetByIdAsync(string id);
  }
}
