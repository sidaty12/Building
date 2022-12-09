using API.Models;
using System.Threading.Tasks;

namespace API.Interfaces
{
  public interface IUserRepository
  {
    Task<User> Authenticate(string username, string password);

  }
}
