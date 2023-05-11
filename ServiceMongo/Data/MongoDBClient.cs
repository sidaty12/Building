using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ServiceMongo.Data.MongoConfig;
using ServiceMongo.Models;

namespace ServiceMongo.Data
{
  public class MongoDBClient : IMongoDBClient
  {
    private readonly IMongoCollection<MongoCity> _cities;

    public MongoDBClient(IOptions<BuildingMongoDbConfig> buildingMongoDbConfig)
    {
      var client = new MongoClient(buildingMongoDbConfig.Value.Connection_String);
      var detabase = client.GetDatabase(buildingMongoDbConfig.Value.Database_Name);
      _cities = detabase.GetCollection<MongoCity>(buildingMongoDbConfig.Value.City_Collection_Name);



    }

   public IMongoCollection<MongoCity> GetCityCollection() => _cities;


  }
}
