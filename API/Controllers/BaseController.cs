using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BaseController : ControllerBase
  {
    protected int? GetUserId()
    {
      var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

      if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
      {
        return userId;
      }

      return null; // L'utilisateur n'est pas authentifié ou l'ID n'a pas pu être extrait.
    }
  }
}
