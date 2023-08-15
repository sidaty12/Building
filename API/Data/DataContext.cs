using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;
using System.Threading.Channels;

namespace API.Data
{

  public class DataContext : DbContext
  {
   
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    
    public DbSet<City> Cities { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Property> Properties { get; set; }

    public DbSet<PropertyType> PropertyTypes { get; set; }

    public DbSet<FurnishingType> FurnishingTypes { get; set; }




  }
}
