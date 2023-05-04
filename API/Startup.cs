using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using API.Data.Mongo;

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

      var builder = new SqlConnectionStringBuilder(
        Configuration.GetConnectionString("Default"));

      builder.Password = Configuration.GetSection("DBPassword").Value;

      var connectionString = builder.ConnectionString;
      services.AddSingleton(Configuration);

      // Configure MongoDB settings
      services.Configure<MongoDBSettings>(Configuration.GetSection(nameof(MongoDBSettings)));
      services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

      // Configure MongoDB client with Stable API version 1
      services.AddSingleton<IMongoClient>(sp =>
      {
        var mongoDBSettings = sp.GetRequiredService<IMongoDBSettings>();
        var clientSettings = MongoClientSettings.FromConnectionString(mongoDBSettings.ConnectionString);
        clientSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
        return new MongoClient(clientSettings);
      });


      services.AddDbContext<DataContext>(options =>
      options.UseSqlServer(connectionString));
      services.AddControllers().AddNewtonsoftJson();
      services.AddCors(); //This needs to let it default
      services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IPhotoService, PhotoService>();


     // var secretKey = Configuration.GetSection("AppSettings:Key").Value;

     // var key = new SymmetricSecurityKey(Encoding.UTF8
     // .GetBytes(secretKey));

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(opt =>
          {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateIssuerSigningKey = true,
              ValidateIssuer = false,
              ValidateAudience = false,
             // IssuerSigningKey = key

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllers();
        });
      }
    }
  }




