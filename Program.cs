
using GameStore.API.Data;
using GameStore.API.Endpoints;
using System.Security.Claims;
using System.Text.Json.Serialization;



// Dictionary<string, List<string>> gamesMap = new(){

//    { "Player1", new List<string> { "Game A", "Game B", "Game C" }},
//    { "Player 2", new List<string> { "Game D", "Game E", "Game F" }},
//    { "Player 3", new List<string> { "Game G", "Game H", "Game I" }},
//    { "Player 4", new List<string> { "Game J", "Game K", "Game L" }}
// };

// Dictionary<string, List<string>> SubscriptionMap = new(){

//    { "Silver", new List<string> { "Game A", "Game B", "Game C" }},
//    { "Gold", new List<string> { "Game D", "Game E", "Game F" }},
//    { "Diamond", new List<string> { "Game G", "Game H", "Game I" }},
//    { "Platinum", new List<string> { "Game J", "Game K", "Game L" }}
// };

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddScoped<IIGameRepository, InMemGameRepository>(); //This is AddScoped this recreate InMemGameRepository every time we call it.
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
// AddScoped<IIGameRepository, EntityFrameworkGamesRepository>();

// var connString=builder.Configuration.GetConnectionString("GameStoreContext");
// builder.Services.AddSqlServer<GameStoreContext>(connString);
var app = builder.Build(); //Add middleware, services, and routes in the Application.



await app.Services.InitializeDbAsync();


// app.MapGet("/myyyyyyyGames",()=>gamesMap).RequireAuthorization(policy=>{
//     policy.RequireRole("admin");
// });

// app.MapGet("/userssssssGames", (ClaimsPrincipal user) =>
// {   
//     var hasClaim = user.HasClaim(claim => claim.Type== "subscription");

//     if(hasClaim){
//         var  subs = user.FindFirstValue("subscription")??throw new Exception("Claim has no value");
//         return  Task.FromResult(Results.Ok(SubscriptionMap[subs]));
//     }

//     //dotnet user-jwts create --role "player" -n player1 --claim "subscription=gold" 

//     ArgumentNullException.ThrowIfNull(user?.Identity?.Name);

//     var userName = user.Identity.Name;

//    if (!gamesMap.ContainsKey(userName)) {
//         return Task.FromResult(Results.NotFound());
//     }
//     return Task.FromResult(Results.Ok(gamesMap[userName]));
// }).RequireAuthorization(policy =>
// {
//     policy.RequireRole("player");
// });

// The below code will check if the applicaiton is UnderDevelopment for not.
// if (app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
// }


app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
// app.UseAuthorization();


app.MapAllEndpoints();

app.Run();
