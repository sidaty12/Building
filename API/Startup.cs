using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using AutoMapper;
using API.Helpers;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using API.Extentions;
using API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Data.SqlClient;
using API.Services;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using System;

namespace API
{

  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddDbContext<DataContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      services.AddControllers().AddNewtonsoftJson();
        services.AddCors(); //This needs to let it default

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mon API", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
      });



      services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPhotoService, PhotoService>();

      var secretKey = "votre_clé_secrète_ici_avec_au_moins_16_caractères";

      // var secretKey = Configuration.GetSection("AppSettings:Key").Value;

      var key = new SymmetricSecurityKey(Encoding.UTF8
        .GetBytes(secretKey));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
              opt.TokenValidationParameters = new TokenValidationParameters
              {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = key

              };
            });
      }


      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {

        app.ConfigureExeptionHandeler(env);

        // app.ConfigureBuiltinExeptionHandeler
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseHsts();
        app.UseHttpsRedirection();

        app.UseCors(
        options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()); //This needs to set everything allowed

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mon API v1");
          c.RoutePrefix = "swagger"; // Ceci fait en sorte que Swagger UI soit la page par défaut
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllers();
        });
      }
    }
  }




