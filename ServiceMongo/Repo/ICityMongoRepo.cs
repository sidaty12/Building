using ServiceMongo.Models;
using System.Collections.Generic;

namespace ServiceMongo.Repo
{
  public interface ICityMongoRepo
  {
    List<MongoCity> GetMongoCities();
    MongoCity GetMongoCity(string id);
    MongoCity AddMongoCity(MongoCity book);
    void DeleteMongoCity(string id);
    MongoCity UpdateMongoCity(MongoCity book);
  }
}
