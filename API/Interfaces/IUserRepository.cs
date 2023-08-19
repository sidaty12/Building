using API.Models;
using System.Threading.Tasks;

namespace API.Interfaces
{
  public interface IUserRepository
  {
    Task<User> Authenticate(string username, string password);

    public Task<User> GetUserByRefreshToken(string refreshToken);

    void Register(string userName, string password);

    Task<bool> UserAlreadyExists(string userName);

  }
}
