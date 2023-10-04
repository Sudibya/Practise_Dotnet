
using GameStore.API.Endpoints;
 


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); //This is used to build the 

app.MapGamesEndpoints();

app.Run();
