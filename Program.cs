
using GameStore.API.Entities;
 
List<Game> games=new(){
    
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



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); //This is used to build the 
 
app.MapGet("/games", () => games);
app.MapGet("games/{id}", (int id) => 
        {
            
          Game? game= games.Find(game => game.Id==id ); //the "?" will change the Game to a nullable value.

          if(game is null){

            return Results.NotFound();
          }

          return Results.Ok(game);
        
        }


        );

app.Run();
