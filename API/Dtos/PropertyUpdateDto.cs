using API.Models;
using System;

namespace API.Dtos
{
  public class PropertyUpdateDto
  {
    public string SellRent { get; set; }
    public string Name { get; set; }
  //  public PropertyType PropertyType { get; set; }
  //  public FurnishingType FurnishingType { get; set; }
    public decimal Price { get; set; }
    public int BHK { get; set; }
    public double BuiltArea { get; set; }
    public bool ReadyToMove { get; set; }
    //public DateTime EstPossessionOn { get; set; }
   // public byte[] Photo { get; set; }
  }
}
