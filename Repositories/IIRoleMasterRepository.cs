using GameStore.API.Entities;

namespace GameStore.API.Repositories;

public interface IIRoleMasterRepository
{
        Task CreateRoleAsync(RoleMaster role);
        Task UpdateRoleAsync(RoleMaster updatedRole);
        Task DeleteRoleAsync(int id);
        Task<RoleMaster?> GetRoleAsync(int id);
        Task<IEnumerable<RoleMaster>> GetAllRolesAsync();
}