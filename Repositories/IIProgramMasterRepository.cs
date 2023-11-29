
using GameStore.API.Entities;


namespace GameStore.API.Repositories
{
    public interface IIProgramMasterRepository
    {
        Task CreateProgramAsync(ProgramMaster program);
        Task UpdateProgramAsync(ProgramMaster updatedProgram);
        Task DeleteProgramAsync(int id);
        Task<ProgramMaster?> GetProgramAsync(int id);

        Task<IEnumerable<ProgramMaster>> GetAllProgramAsync(); 
    }
}