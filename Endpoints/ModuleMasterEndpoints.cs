using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Repositories;
using System.Linq;

namespace GameStore.API.Endpoints
{
    public static class ModuleMasterEndpoints
    {
        private const string GetEndPointName = "GetModule";

        public static RouteGroupBuilder MapModuleMasterEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/modules").WithParameterValidation();

            group.MapGet("/", async (IIModuleMasterRepository moduleRepository) =>
            {
                var modules = await moduleRepository.GetAllModulesAsync();
                return modules.Select(module => module.AsDto());
            });

            group.MapGet("/{id}", async (IIModuleMasterRepository moduleRepository, int id) =>
            {
                var module = await moduleRepository.GetModuleAsync(id);
                return module is not null ? Results.Ok(module.AsDto()) : Results.NotFound();
            }).WithName("GetModule");

            group.MapPost("/", async (IIModuleMasterRepository moduleRepository, CreateModuleMasterDto moduleDto) =>
            {
                var module = new ModuleMaster
                {
                    ModuleName = moduleDto.ModuleName
                    // Additional properties as needed
                };

                await moduleRepository.CreateModuleAsync(module);

                return Results.CreatedAtRoute(GetEndPointName, new { id = module.ModuleID }, module);
            });

            group.MapPut("/{id}", async (int id, IIModuleMasterRepository moduleRepository, UpdateModuleMasterDto updatedModuleDto) =>
            {
                var existingModule = await moduleRepository.GetModuleAsync(id);

                if (existingModule is null)
                {
                    return Results.NotFound();
                }

                existingModule.ModuleName = updatedModuleDto.ModuleName;
                // Update additional properties as needed

                await moduleRepository.UpdateModuleAsync(existingModule);

                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (IIModuleMasterRepository moduleRepository, int id) =>
            {
                var module = await moduleRepository.GetModuleAsync(id);

                if (module is not null)
                {
                    await moduleRepository.DeleteModuleAsync(id);
                    return Results.Ok($"Deleted the module with ID: {id}");
                }
                else
                {
                    return Results.NotFound($"Module with ID: {id} not found");
                }
            });

            return group;
        }
    }
}