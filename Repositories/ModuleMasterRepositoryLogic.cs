using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.API.Data;
using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Repositories
{
    public class ModuleMasterRepositoryLogic: IIModuleMasterRepository
    {
        private readonly GameStoreContext dbContext;

        public ModuleMasterRepositoryLogic(GameStoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ModuleMaster>> GetAllModulesAsync()
        {
            return await dbContext.Module.AsNoTracking().ToListAsync();
        }

        public async Task<ModuleMaster?> GetModuleAsync(int id)
        {
            return await dbContext.Module.FindAsync(id);
        }

        public async Task CreateModuleAsync(ModuleMaster module)
        {
            dbContext.Module.Add(module);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateModuleAsync(ModuleMaster updatedModule)
        {
            dbContext.Update(updatedModule);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteModuleAsync(int id)
        {
            var module = await dbContext.Module.FindAsync(id);
            if (module != null)
            {
                dbContext.Module.Remove(module);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}