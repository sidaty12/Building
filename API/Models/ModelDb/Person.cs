using MongoDB.Bson;

namespace API.Models.ModelDb
{
  public class Person
  {
    public ObjectId Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
