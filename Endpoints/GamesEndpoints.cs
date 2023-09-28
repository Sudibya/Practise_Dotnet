using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.API.Entities;

namespace GameStore.API.Endpoints;


public static class GamesEndpoints //The endpoints method are always static
{


    const string GetEndPointName = "GetGame";
    static List<Game> games=new(){
    
    new Game(){
        Id=1,
        Name="StreetFighter2",
        Genre="Action",
        Price=20.50M,
        ReleaseDate=new DateTime(1991, 2, 1),
        ImageUrl="https://placehold.co/500"       

    },
    new Game(){
        Id=2,
        Name="StreetFighter3",
        Genre="Action and Adventure",
        Price=30M,
        ReleaseDate=new DateTime(2022, 2, 1),
        ImageUrl="https://placehold.co/500"       

    }
};
    public static  RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes){

        var group = routes.MapGroup("/games").WithParameterValidation(); // we got this from the NuGet packages it will add server side validation.
            
            group.MapGet("/", () => games);

            group.MapGet("/{id}", (int id) => 
        {
            
          Game? game= games.Find(game => game.Id==id ); //the "?" will change the Game to a nullable value.

          if(game is null){

            return Results.NotFound();
          }

          return Results.Ok(game);
        
        }


        ).WithName("GetGame");
group.MapPost("/", (Game game) =>
{
  game.Id= games.Max(game => game.Id)+1;
  games.Add(game);

  return Results.CreatedAtRoute(GetEndPointName, new {id = game.Id}, game);

} );


group.MapPut("/{id}", (int id, Game updatedGame)=>{

  Game? existingGame= games.Find(game => game.Id==id ); //the "?" will change the Game to a nullable value.

          if(existingGame is null){

            return Results.NotFound();
          }

          existingGame.Name = updatedGame.Name;
          existingGame.Genre=updatedGame.Genre;
          existingGame.Price=updatedGame.Price;
          existingGame.ReleaseDate=updatedGame.ReleaseDate;
          existingGame.ImageUrl=updatedGame.ImageUrl;

          return Results.NoContent();
          
});


group.MapDelete("/{id}",(int id)=>{

   Game? game= games.Find(game => game.Id==id ); //the "?" will change the Game to a nullable value.

          if(game is not null){

            games.Remove(game);
          }
          if(game is null){
            return Results.Ok("No such game");
          }

          return Results.Ok($"Deleted the game name:{game?.Name}");
        
        


});

    return group;

    }
    
}