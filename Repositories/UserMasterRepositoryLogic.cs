using GameStore.API.Data;
using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;


namespace GameStore.API.Repositories;

public class UserMasterRepositoryLogic : IIUserMasterRepository
{
    private readonly GameStoreContext dbContext;

    public UserMasterRepositoryLogic(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<UserMaster>> GetAllUsersAsync()
    {
        return await dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<UserMaster?> GetUserAsync(int id)
    {
        return await dbContext.Users.FindAsync(id);
    }

    public async Task CreateUserAsync(UserMaster user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(UserMaster updatedUser)
    {
        dbContext.Update(updatedUser);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await dbContext.Users.FindAsync(id);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }

    
}

