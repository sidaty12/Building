using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

  public class DataContext : DbContext
  {

    public DataContext(DbContextOptions<DataContext> options) : base(options){}

    public DbSet<City> cities {get; set;}

  }
}
