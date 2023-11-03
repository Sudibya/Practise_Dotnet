using GameStore.API.Data;
using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Repositories
{
    public class EntityFrameworkGamesRepository : IIGameRepository
    {

        private readonly GameStoreContext dbContext;

        public EntityFrameworkGamesRepository(GameStoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            // return dbContext.Games.AsNoTracking().ToList();
            return await dbContext.Games.AsNoTracking().ToListAsync();
        }
        public async Task<Game?> GetAsync(int id)
        {
            return await dbContext.Games.FindAsync(id);
        }
        public async Task CreateAsync(Game game)
        {
            dbContext.Games.Add(game);//This will create a new game
            await  dbContext.SaveChangesAsync(); //WIll change all the changes to the database.
        }
        public async Task UpdateGameAsync(Game updatedGame)
        {
            dbContext.Update(updatedGame);
            await dbContext.SaveChangesAsync(); //WIll change add the changes to the database.
        }
        public async Task DeleteAsync(int id)
        {
            // dbContext.Remove(id);
            // dbContext.SaveChanges(); 

           await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
        }


    }
}