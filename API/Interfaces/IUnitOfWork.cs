using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {

         ICityRepository CityRepository {get;}
         Task<bool> SaveAsync();
    }
}
