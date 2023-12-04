using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Repositories;
using System.Linq;

namespace GameStore.API.Endpoints
{
    public static class ProgramMasterEndpoints
    {
        private const string GetEndPointName = "GetProgram";

        public static RouteGroupBuilder MapProgramMasterEndpoints(this IEndpointRouteBuilder routes)
        {
            
            var group = routes.MapGroup("/programs").WithParameterValidation();


            group.MapGet("/", async (IIProgramMasterRepository programRepository) =>
            {
                var programs = await programRepository.GetAllProgramAsync();
                return programs.Select(program => program.AsDto());
            });

            group.MapGet("/{id}", async (IIProgramMasterRepository programRepository, int id) =>
            {
                var program = await programRepository.GetProgramAsync(id);
                return program is not null ? Results.Ok(program.AsDto()) : Results.NotFound();
            }).WithName("GetProgram");

            group.MapPost("/", async (IIProgramMasterRepository programRepository, IIModuleMasterRepository moduleRepository , CreateProgramMasterDto programDto) =>
            {
                var module = await moduleRepository.GetModuleAsync(programDto.ModuleID);

                if (module != null)
                {
                    var program = new ProgramMaster
                    {
                        ProgramName = programDto.ProgramName,
                        ModuleID = programDto.ModuleID,
                        ModuleMaster = module,
                        ModuleName = programDto.ModuleName,
                        Active = programDto.Active,
                        ActiveDate = programDto.ActiveDate,
                        DeactiveDate = programDto.DeactiveDate,
                        ProgramHeader = programDto.ProgramHeader
            // Additional properties as needed
                    };


                    await programRepository.CreateProgramAsync(program);

                    return Results.CreatedAtRoute(GetEndPointName, new { id = program.ProgramID }, program);

        // Rest of the code...
                }
                else
                {
        
                    return Results.NotFound($"ModuleMaster with ID: {programDto.ModuleID} not found");
                }
                
            });

            group.MapPut("/{id}", async (int id, IIProgramMasterRepository programRepository, UpdateProgramMasterDto updatedProgramDto) =>
            {
                var existingProgram = await programRepository.GetProgramAsync(id);

                if (existingProgram is null)
                {
                    return Results.NotFound();
                }

                existingProgram.ProgramName = updatedProgramDto.ProgramName;
                existingProgram.ModuleID = updatedProgramDto.ModuleID;
                existingProgram.ModuleName = updatedProgramDto.ModuleName;
                existingProgram.Active = updatedProgramDto.Active;
                existingProgram.ActiveDate = updatedProgramDto.ActiveDate;
                existingProgram.DeactiveDate = updatedProgramDto.DeactiveDate;
                existingProgram.ProgramHeader = updatedProgramDto.ProgramHeader;
                // Update additional properties as needed

                await programRepository.UpdateProgramAsync(existingProgram);

                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (IIProgramMasterRepository programRepository, int id) =>
            {
                var program = await programRepository.GetProgramAsync(id);

                if (program is not null)
                {
                    await programRepository.DeleteProgramAsync(id);
                    return Results.Ok($"Deleted the program with ID: {id}");
                }
                else
                {
                    return Results.NotFound($"Program with ID: {id} not found");
                }
            });

            return group;
        }
    }
}
