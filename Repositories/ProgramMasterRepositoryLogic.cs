using GameStore.API.Data;
using Microsoft.EntityFrameworkCore;
using GameStore.API.Entities;



namespace GameStore.API.Repositories
{
    public class ProgramMasterRepositoryLogic : IIProgramMasterRepository
    {
        private readonly GameStoreContext dbContext;

        public ProgramMasterRepositoryLogic(GameStoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProgramMaster>> GetAllProgramAsync()
        {
            return await dbContext.Program.AsNoTracking().ToListAsync();
        }

        public async Task<ProgramMaster?> GetProgramAsync(int id)
        {
            return await dbContext.Program.FindAsync(id);
        }

        public async Task CreateProgramAsync(ProgramMaster program)
        {
            dbContext.Program.Add(program);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateProgramAsync(ProgramMaster updatedProgram)
        {
            dbContext.Update(updatedProgram);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProgramAsync(int id)
        {
            var program = await dbContext.Program.FindAsync(id);
            if (program != null)
            {
                dbContext.Program.Remove(program);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
