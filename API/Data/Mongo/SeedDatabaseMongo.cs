using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Mongo
{
  public class SeedDatabaseMongo
  {
    private readonly IMongoDatabase _database;

    private readonly IMongoClient _mongoClient;
    private readonly IConfiguration _configuration;

    public SeedDatabaseMongo(IMongoClient mongoClient, IConfiguration configuration)
    {
      _mongoClient = mongoClient;
      _configuration = configuration;
      _database = _mongoClient.GetDatabase(_configuration.GetSection("MongoDBSettings:DatabaseName").Value);

    }

    public async Task Seed()
    {
      // Remplacez les champs par ceux appropriés pour vos documents.
      // Insérez les utilisateurs
      var users = new List<BsonDocument>
            {
                new BsonDocument
                {
                    { "Username", "Demo" },
                    // Ajoutez les autres champs...
                }
            };
      await InsertIfNotExists("Users", users);

      // Insérez les types de propriété
      var propertyTypes = new List<BsonDocument>
            {
                new BsonDocument { { "Name", "House" } },
                new BsonDocument { { "Name", "Apartment" } },
                new BsonDocument { { "Name", "Duplex" } }
            };
      await InsertIfNotExists("PropertyTypes", propertyTypes);

      // Insérez les types d'ameublement
      var furnishingTypes = new List<BsonDocument>
            {
                new BsonDocument { { "Name", "Fully" } },
                new BsonDocument { { "Name", "Semi" } },
                new BsonDocument { { "Name", "Unfurnished" } }
            };
      await InsertIfNotExists("FurnishingTypes", furnishingTypes);

      // Insérez les villes
      var cities = new List<BsonDocument>
            {
                new BsonDocument
                {
                    { "Name", "New York" },
                    { "Country", "USA" }
                },
                new BsonDocument
                {
                    { "Name", "Houston" },
                    { "Country", "USA" }
                },
                new BsonDocument
                {
                    { "Name", "Los Angeles" },
                    { "Country", "USA" }
                },
                new BsonDocument
                {
                    { "Name", "New Delhi" },
                    { "Country", "India" }
                },
                new BsonDocument
                {
                    { "Name", "Bangalore" },
                    { "Country", "India" }
                }
            };
      await InsertIfNotExists("Cities", cities);

      // Insérez les propriétés
      var properties = new List<BsonDocument>
            {
                new BsonDocument
                {
                    { "SellRent", 1 },
                    { "Name", "White House Demo" },
                    // Ajoutez les autres champs...
                },
                new BsonDocument
                {
                    { "SellRent", 2 },
                    { "Name", "Birla House Demo" },
                    // Ajoutez les autres champs...
                }
            };
      await InsertIfNotExists("Properties", properties);
    }

    private async Task InsertIfNotExists(string MyCollection, List<BsonDocument> documents)
    {
      var collection = _database.GetCollection<BsonDocument>(MyCollection);

      foreach (var document in documents)
      {
        string searchField = "Name";

        if (MyCollection == "Users")
        {
          searchField = "Username";
        }

        if (document.Contains(searchField))
        {
          var filter = Builders<BsonDocument>.Filter.Eq(searchField, document[searchField]);
          var existingDocument = await collection.Find(filter).FirstOrDefaultAsync();

          if (existingDocument == null)
          {
            await collection.InsertOneAsync(document);
          }
        }
      }
    }
  }
}
