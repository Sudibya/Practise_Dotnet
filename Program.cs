
using GameStore.API.Data;
using GameStore.API.Endpoints;
using GameStore.API.Repositories;



var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddScoped<IIGameRepository, InMemGameRepository>(); //This is AddScoped this recreate InMemGameRepository every time we call it.
builder.Services.AddSingleton<IIGameRepository, InMemGameRepository>();

var connString=builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(connString);
var app = builder.Build(); //Add middleware, services, and routes in the Application.

app.Services.InitializeDb();

app.MapGamesEndpoints();

app.Run();
