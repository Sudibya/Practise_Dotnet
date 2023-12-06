using GameStore.API.Data;
using Microsoft.EntityFrameworkCore;
using GameStore.API.Entities; 

namespace GameStore.API.Repositories;

public class RoleMasterRepositoryLogic: IIRoleMasterRepository
{
    private readonly GameStoreContext _dbContext;

    public RoleMasterRepositoryLogic(GameStoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<RoleMaster>> GetAllRolesAsync()
    {
        return await _dbContext.Roles.AsNoTracking().ToListAsync();
    }

    public async Task<RoleMaster?> GetRoleAsync(int id)
    {
        return await _dbContext.Roles.FindAsync(id);
    }

    public async Task CreateRoleAsync(RoleMaster role)
    {
        _dbContext.Roles.Add(role);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRoleAsync(RoleMaster updatedRole)
    {
        _dbContext.Update(updatedRole);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(int id)
    {
        var role = await _dbContext.Roles.FindAsync(id);
        if (role != null)
        {
            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
        }
    }
}