using MongoDB.Driver;
using ServiceMongo.Models;

namespace ServiceMongo.Data
{
  public interface IMongoDBClient
  {
    IMongoCollection<MongoCity> GetCityCollection();

  }
}
