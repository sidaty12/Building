using API.Dtos;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Errors;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using API.Extentions;
using System.Security.Cryptography;

namespace API.Controllers
{

  public class AccountController : BaseController
  {
    private readonly IUnitOfWork uow;

    private readonly IConfiguration configuration;

    public AccountController(IUnitOfWork uow, IConfiguration configuration)
    {
      this.configuration = configuration;
      this.uow = uow;
    }


    // api/account/login
    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginReqDto loginReq)
    {

      var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

      ApiError apiError = new ApiError();

      if (user == null)
      {
        apiError.ErrorCode = Unauthorized().StatusCode;
        apiError.ErrorMessage = "Invalid user name or password";
        apiError.ErrorDetails = "This error appear when provided user id or password does not exists";
        return Unauthorized(apiError);
      }

      var loginRes = new LoginResDto();
      loginRes.UserName = user.Username;
      loginRes.Token = CreateJWT(user);
      loginRes.RefreshToken = GenerateRefreshToken();
      user.RefreshToken = loginRes.RefreshToken;
      user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
      await uow.SaveAsync();

      return Ok(loginRes);
    }

    private string GenerateRefreshToken()
    {
      var randomNumber = new byte[32];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
      }
    }

    [HttpPost("refresh-token")]

    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
      var user = await uow.UserRepository.GetUserByRefreshToken(refreshToken);
      if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
        return BadRequest("Invalid token");

      var newToken = CreateJWT(user);
      var newRefreshToken = GenerateRefreshToken();
      user.RefreshToken = newRefreshToken;
      await uow.SaveAsync();

      return Ok(new { Token = newToken, RefreshToken = newRefreshToken });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Legout([FromBody] LogoutRequest refreshToken)
    {
      var user = await uow.UserRepository.GetUserByRefreshToken(refreshToken.RefreshToken);
      if (user == null) return BadRequest("Invalid request");

      user.RefreshToken = null;
      await uow.SaveAsync();

      return Ok();
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register(LoginReqDto loginReq)
    {
       ApiError apiError = new ApiError();

      if(loginReq.UserName.IsEmpty() || loginReq.Password.IsEmpty())
       {
         apiError.ErrorCode = BadRequest().StatusCode;
      apiError.ErrorMessage = "User name or password can not be blank";
             return BadRequest(apiError);

       }

      if (await uow.UserRepository.UserAlreadyExists(loginReq.UserName))
      {
        apiError.ErrorCode = BadRequest().StatusCode;
      apiError.ErrorMessage = "User already exists, please try different user name";
      return BadRequest(apiError);

    }
    uow.UserRepository.Register(loginReq.UserName, loginReq.Password);
      await uow.SaveAsync();
      return StatusCode(201);

  }
    private string CreateJWT(User user)
    {


      // var secretKey = configuration.GetSection("AppSettings:Key").Value;

      var secretKey = "votre_clé_secrète_ici_avec_au_moins_16_caractères";


      var key = new SymmetricSecurityKey(Encoding.UTF8
      .GetBytes(secretKey));



      var claims = new Claim[] {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())

      };

      var signingCredentials = new SigningCredentials(
        key, SecurityAlgorithms.HmacSha256Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddDays(2),
        SigningCredentials = signingCredentials
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

  }
}
