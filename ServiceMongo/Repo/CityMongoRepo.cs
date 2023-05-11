using MongoDB.Driver;
using ServiceMongo.Data;
using ServiceMongo.Models;
using System.Collections.Generic;

namespace ServiceMongo.Repo
{
  public class CityMongoRepo : ICityMongoRepo
  {
    private readonly IMongoCollection<MongoCity> _cities;

    public CityMongoRepo(IMongoDBClient mongoClient)
    {
      _cities = mongoClient.GetCityCollection();
    }

    public List<MongoCity> GetMongoCities() => _cities.Find(MongoCity => true).ToList();

    public void DeleteMongoCity(string id)
    {
      _cities.DeleteOne(MongoCity => MongoCity.Id == id);

    }
    public MongoCity AddMongoCity(MongoCity mongocity)
    {
      _cities.InsertOne(mongocity);
      return mongocity;
    }


    public MongoCity GetMongoCity(string id) => _cities.Find(MongoCity => MongoCity.Id == id).First();



    public MongoCity UpdateMongoCity(MongoCity mongocity)
    {
      GetMongoCity(mongocity.Id);
      _cities.ReplaceOne(b => b.Id == mongocity.Id, mongocity);
      return mongocity;
    }

    
  }
}
