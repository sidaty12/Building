using API.Data.Repo;
using API.Interfaces;
using System.Threading.Tasks;

namespace API.Data
{

  public class UnitOfWork : IUnitOfWork
  {
    private readonly DataContext dc;

    public UnitOfWork(DataContext dc)
    {
      this.dc = dc;
    }

    public ICityRepository CityRepository =>
      new CityRepository(dc);

    public IUserRepository UserRepository =>
      new UserRepository(dc);



    public IPropertyRepository PropertyRepository =>
        new PropertyRepository(dc);

   

    public IPropertyTypeRepository PropertyTypeRepository =>
       new PropertyTypeRepository(dc);

    public IFurnishingTypeRepository FurnishingTypeRepository =>

      new FurnishingTypeRepository(dc);

    public async Task<bool> SaveAsync()
    {
      return await dc.SaveChangesAsync() > 0;

    }
  }

}
