using API.Data.Mongo.Interfaces;
using API.Data.Mongo.MongoModels;
using API.Interfaces;
using API.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Mongo.MongoRepo
{
  public class CityRepo : ICityRepo
  {
    private readonly IMongoCollection<MongoCity> _collection;
    private readonly ILogger<CityRepo> _logger;


    public CityRepo(IMongoDbContext dbContext, ILogger<CityRepo> logger)
    {
      //var database = mongoClient.GetDatabase("MyDbBuildingMong");
      _collection = dbContext.GetCollection<MongoCity>("Cities");
      _logger = logger;
    }
    public async Task<IEnumerable<MongoCity>> GetAllAsync()
    {
      return await _collection.Find(_ => true).ToListAsync();

    }

    public async Task<MongoCity> GetByIdAsync(string id)
    {
      _logger.LogInformation($"Recherche de la ville dans la base de données MongoDB avec l'identifiant : {id}");

      var filter = Builders<MongoCity>.Filter.Eq("_id", id);
      var city = await _collection.Find(filter).FirstOrDefaultAsync();

      if (city == null)
      {
        _logger.LogWarning($"Aucune ville trouvée dans la base de données MongoDB avec l'identifiant : {id}");
      }
      else
      {
        _logger.LogInformation($"Ville trouvée dans la base de données MongoDB : {city.Name}, {city.Country}");
      }
      return city;
    }
  }
}





