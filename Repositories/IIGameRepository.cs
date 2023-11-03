using GameStore.API.Entities;

namespace GameStore.API.Repositories;

/// <summary>
/// This is how to do the dependency injection in C# using the dependencies.
/// We create a dependency calss using interfaces that allow multiple inheritance.
/// </summary>
public interface IIGameRepository
{
    Task CreateAsync(Game game);
    Task UpdateGameAsync(Game updatedGame);
    Task DeleteAsync(int id);
    Task<Game?> GetAsync(int id);

    Task<IEnumerable<Game>> GetAllAsync();
    
}
