using GameStore.API.Entities;

namespace GameStore.API.Repositories;

/// <summary>
/// This is how to do the dependency injection in C# using the dependencies.
/// We create a dependency calss using interfaces that allow multiple inheritance.
/// </summary>
public interface IIGameRepository
{
    void Create(Game game);
    void UpdateGame(Game updatedGame);
    void Delete(int id);
    Game? Get(int id);

    IEnumerable<Game> GetAll();
}
