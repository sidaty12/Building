var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
  options.AddPolicy(devCorsPolicy, builder => {
    //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
    //builder.SetIsOriginAllowed(origin => true);
  });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.UseCors(devCorsPolicy);
}
else
{
  app.UseHttpsRedirection();
  app.UseAuthorization();
  //app.UseCors(prodCorsPolicy);
}

app.MapControllers();

app.Run();
