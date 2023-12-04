using GameStore.API.Entities;

namespace GameStore.API.Repositories
{
    public interface IIModuleMasterRepository
    {
        Task CreateModuleAsync(ModuleMaster module);
        Task UpdateModuleAsync(ModuleMaster updatedModule);
        Task DeleteModuleAsync(int id);
        Task<ModuleMaster?> GetModuleAsync(int id);

        Task<IEnumerable<ModuleMaster>> GetAllModulesAsync();
    }
}