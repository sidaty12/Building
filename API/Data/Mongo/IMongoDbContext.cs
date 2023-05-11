using MongoDB.Driver;

namespace API.Data.Mongo
{
  public interface IMongoDbContext
  {
    IMongoCollection<T> GetCollection<T>(string collectionName);

  }
}
