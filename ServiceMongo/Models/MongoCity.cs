using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ServiceMongo.Models
{
  public class MongoCity
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("Country")]
    public string Country { get; set; }
  }
}
