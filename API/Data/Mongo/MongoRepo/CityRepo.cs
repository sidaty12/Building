using API.Data.Mongo.Interfaces;
using API.Data.Mongo.MongoModels;
using API.Interfaces;
using API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Mongo.MongoRepo
{
  public class CityRepo : ICityRepo
  {
    private readonly IMongoCollection<MongoCity> _collection;

    public CityRepo(IMongoClient mongoClient)
    {
      var database = mongoClient.GetDatabase("MyDatabase");
      _collection = database.GetCollection<MongoCity>("Cities");
    }
    public async Task<IEnumerable<MongoCity>> GetAllAsync()
    {
      return await _collection.Find(_ => true).ToListAsync();

    }

    public async Task<MongoCity> GetByIdAsync(string id)
    {
      var filter = Builders<MongoCity>.Filter.Eq("_id", id);
      return await _collection.Find(filter).FirstOrDefaultAsync();
    }
  }
}



 

