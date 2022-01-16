using BookOfHeroes.Models;
using Redis.OM;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(_ =>
    new RedisConnectionProvider(builder.Configuration.GetConnectionString("redisdb")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var redisConnectionProvider = app.Services.GetService<RedisConnectionProvider>();
redisConnectionProvider?.Connection.CreateIndex(typeof(Hero));

app.UseAuthorization();
app.MapControllers();
app.Run();
