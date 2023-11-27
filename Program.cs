
using GameStore.API.Data;
using GameStore.API.Endpoints;
using GameStore.API.Repositories;
using System.Security.Claims;


Dictionary<string, List<string>> gamesMap = new(){

   { "Player 1", new List<string> { "Game A", "Game B", "Game C" }},
   { "Player 2", new List<string> { "Game D", "Game E", "Game F" }},
   { "Player 3", new List<string> { "Game G", "Game H", "Game I" }},
   { "Player 4", new List<string> { "Game J", "Game K", "Game L" }}
};

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddScoped<IIGameRepository, InMemGameRepository>(); //This is AddScoped this recreate InMemGameRepository every time we call it.
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

// AddScoped<IIGameRepository, EntityFrameworkGamesRepository>();

// var connString=builder.Configuration.GetConnectionString("GameStoreContext");
// builder.Services.AddSqlServer<GameStoreContext>(connString);
var app = builder.Build(); //Add middleware, services, and routes in the Application.



await app.Services.InitializeDbAsync();



app.MapAllEndpoints();
app.MapGet("/myGames",(ClaimsPrincipal user))=>{

    ArgumentNullException.ThrowIfNull(user.)
};



app.Run();
