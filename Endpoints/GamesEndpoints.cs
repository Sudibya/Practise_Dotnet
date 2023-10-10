using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.API.Entities;
using GameStore.API.Repositories;

namespace GameStore.API.Endpoints;


public static class GamesEndpoints //The endpoints method are always static
{

    const string GetEndPointName = "GetGame";
    

    public static  RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes){

        // InMemGameRepository gameRepository = new();//InMemGameRepository

        var group = routes.MapGroup("/games").WithParameterValidation(); // we got this from the NuGet packages it will add server side validation.
            
            group.MapGet("/", (IIGameRepository gameRepository) => gameRepository.GetAll());

            group.MapGet("/{id}", (IIGameRepository gameRepository, int id) => 
        {
            
          Game? game= gameRepository.Get(id); //the "?" will change the Game to a nullable value.


            return game is not null? Results.Ok(game) :Results.NotFound();

        //   if(game is null){

        //     return Results.NotFound();
        //   }

        //   return Results.Ok(game);
        
        }).WithName("GetGame");


        group.MapPost("/",  (IIGameRepository gameRepository, Game game) =>
        {
            gameRepository.Create(game);

  return Results.CreatedAtRoute(GetEndPointName, new {id = game.Id}, game);

} );


group.MapPut("/{id}", (int id,IIGameRepository gameRepository, Game updatedGame)=>{

  Game? existingGame= gameRepository.Get(id)  ; //the "?" will change the Game to a nullable value.

          if(existingGame is null){

            return Results.NotFound();
          }

          existingGame.Name = updatedGame.Name;
          existingGame.Genre=updatedGame.Genre;
          existingGame.Price=updatedGame.Price;
          existingGame.ReleaseDate=updatedGame.ReleaseDate;
          existingGame.ImageUrl=updatedGame.ImageUrl;

          gameRepository.UpdateGame(existingGame);

          return Results.NoContent();
          
});


group.MapDelete("/{id}",(IIGameRepository gameRepository,int id)=>{

   Game? game= gameRepository.Get(id); //the "?" will change the Game to a nullable value.

          if(game is not null){

            gameRepository.Delete(id);
          }

          else if(game is null){
            return Results.Ok("No such game");
          }

          return Results.Ok($"Deleted the game name:{game?.Name}");
        
        


});

    return group;

    }
    
}