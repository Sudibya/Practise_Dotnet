
using GameStore.API.Data;
using GameStore.API.Endpoints;
using GameStore.API.Repositories;



var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddScoped<IIGameRepository, InMemGameRepository>(); //This is AddScoped this recreate InMemGameRepository every time we call it.
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthorization();

// AddScoped<IIGameRepository, EntityFrameworkGamesRepository>();

// var connString=builder.Configuration.GetConnectionString("GameStoreContext");
// builder.Services.AddSqlServer<GameStoreContext>(connString);
var app = builder.Build(); //Add middleware, services, and routes in the Application.



await app.Services.InitializeDbAsync();



app.MapGamesEndpoints();

app.Run();
