using MongoDB.Driver;

namespace API.Data.Mongo
{
  public class MongoDbContext : IMongoDbContext
  {
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoDBSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
      return _database.GetCollection<T>(collectionName);
    }
  }
}
