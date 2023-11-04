using GameStore.API.Entities;

namespace GameStore.API.Repositories;
public class InMemGameRepository : IIGameRepository
{
    private readonly List<Game> games = new(){      //readonly: This keyword indicates that the field is a read-only field. Once a value is assigned to a read-only field, it cannot be changed or modified afterward. It essentially makes the field immutable.
    
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
    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await Task.FromResult(games);
    }
    public async Task<Game?> GetAsync(int id)
    {

        return await Task.FromResult(games.Find(game => game.Id == id));
    }

    public async Task CreateAsync(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);

        await Task.CompletedTask;
    }

    public async Task UpdateGameAsync(Game updatedGame)
    {

        var index = games.FindIndex(game => game.Id == updatedGame.Id);
         games[index] = updatedGame;
         await Task.CompletedTask;
    }

    public async Task DeleteGame(int id)
    {

        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
        await Task.CompletedTask;
    }
}