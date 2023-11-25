using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Repositories;

namespace GameStore.API.Endpoints;


public static class GamesEndpoints //The endpoints method are always static
{

    const string GetEndPointName = "GetGame";
    

    public static  RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes){

        // InMemGameRepository gameRepository = new();//InMemGameRepository

        var group = routes.MapGroup("/games").WithParameterValidation(); // we got this from the NuGet packages it will add server side validation.
            
            group.MapGet("/", async (IIGameRepository gameRepository) => (await gameRepository.GetAllAsync()).Select(game => game.AsDto()));

            group.MapGet("/{id}", async (IIGameRepository gameRepository, int id) => 
        {
            
          Game? game= await gameRepository.GetAsync(id); //the "?" will change the Game to a nullable value.


            return game is not null? Results.Ok(game.AsDto()) :Results.NotFound();

        //   if(game is null){

        //     return Results.NotFound();
        //   }

        //   return Results.Ok(game);
        
        }).WithName("GetGame");


        group.MapPost("/", async  (IIGameRepository gameRepository, CreateGameDto gameDto) =>
        { 
          Game game = new(){
            Name = gameDto.Name,
            Genre = gameDto.Genre,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate,
            ImageUrl= gameDto.ImageUrl

          };

            await   gameRepository.CreateAsync(game);

  return Results.CreatedAtRoute(GetEndPointName, new {id = game.Id}, game);

} );


group.MapPut("/{id}", async (int id,IIGameRepository gameRepository, UpdateGameDto updatedGameDto)=>{

  Game? existingGame= await gameRepository.GetAsync(id)  ; //the "?" will change the Game to a nullable value.

          if(existingGame is null){

            return Results.NotFound();
          }

          existingGame.Name = updatedGameDto.Name;
          existingGame.Genre=updatedGameDto.Genre;
          existingGame.Price=updatedGameDto.Price;
          existingGame.ReleaseDate=updatedGameDto.ReleaseDate;
          existingGame.ImageUrl=updatedGameDto.ImageUrl;

          await gameRepository.UpdateGameAsync(existingGame);

          return Results.NoContent();
          
});


group.MapDelete("/{id}", async (IIGameRepository gameRepository,int id)=>{

   Game? game=await gameRepository.GetAsync(id); //the "?" will change the Game to a nullable value.

          if(game is not null){

            await gameRepository.DeleteAsync(id);
          }

          else if(game is null){
            return Results.Ok("No such game");
          }

          return Results.Ok($"Deleted the game name:{game?.Name}");
        
        


});

    return group;

    }
    
}