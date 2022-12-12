using API.Dtos;
using API.Interfaces;
using API.Models;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Errors;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

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

      if (user == null)
      {
        return Unauthorized();
      }

      var loginRes = new LoginResDto();
      loginRes.UserName = user.Username;
      loginRes.Token = CreateJWT(user);

      return Ok(loginRes);
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register(LoginReqDto loginReq)
    {
      if (await uow.UserRepository.UserAlreadyExists(loginReq.UserName))
      
       // apiError.ErrorCode = BadRequest().StatusCode;
       // apiError.ErrorMessage = "User already exists, please try different user name";
        return BadRequest("User alerdy exists, please try something else");
      

      uow.UserRepository.Register(loginReq.UserName, loginReq.Password);
      await uow.SaveAsync();
      return StatusCode(201);

    }
      private string CreateJWT(User user)
    {

      //   var secretKey = configuration.GetSection("AppSettings:key").Value;

      var secretKey = configuration.GetSection("AppSettings:Key").Value;

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
        Expires = DateTime.UtcNow.AddMinutes(2),
        SigningCredentials = signingCredentials
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

  }
}
