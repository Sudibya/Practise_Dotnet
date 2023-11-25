using GameStore.API.Entities;




namespace GameStore.API.Repositories;

public interface IIUserMasterRepository
{
    Task CreateUserAsync(UserMaster user);
    Task UpdateUserAsync(UserMaster updatedUser);
    Task DeleteUserAsync(int id);
    Task<UserMaster?> GetUserAsync(int id);
    Task<IEnumerable<UserMaster>> GetAllUsersAsync();
}