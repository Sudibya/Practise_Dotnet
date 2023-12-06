using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Repositories;
using System.Linq;

namespace GameStore.API.Endpoints
{
    public static class RoleMasterEndpoints
    {
        private const string GetEndPointName = "GetRole";

        public static RouteGroupBuilder MapRoleMasterEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/roles").WithParameterValidation();

            group.MapGet("/", async (IIRoleMasterRepository roleRepository) =>
            {
                var roles = await roleRepository.GetAllRolesAsync();
                return roles.Select(role => role.AsDto());
            });

            group.MapGet("/{id}", async (IIRoleMasterRepository roleRepository, int id) =>
            {
                var role = await roleRepository.GetRoleAsync(id);
                return role is not null ? Results.Ok(role.AsDto()) : Results.NotFound();
            }).WithName("GetRole");

            group.MapPost("/", async (IIRoleMasterRepository roleRepository, IIProgramMasterRepository programRepository,
                IIModuleMasterRepository moduleRepository, IIUserMasterRepository userRepository,
                CreateRoleMasterDto roleDto) =>
            {
                var role = new RoleMaster
                {
                    RoleName = roleDto.RoleName,
                    CreatedBy = roleDto.CreatedBy,
    
                };


                await roleRepository.CreateRoleAsync(role);

                // Tag programs to the role
                if (roleDto.ProgramIds != null)
                {
                    foreach (var programId in roleDto.ProgramIds)
                    {
                        var program = await programRepository.GetProgramAsync(programId);
                        if (program != null)
                        {
                            role.ProgramMasters.Add(program);
                        }
                        else
                        {
                            return Results.NotFound($"Program with ID: {programId} not found");
                        }
                    }
                }

                // Tag modules to the role
                if (roleDto.ModuleIds != null)
                {
                    foreach (var moduleId in roleDto.ModuleIds)
                    {
                        var module = await moduleRepository.GetModuleAsync(moduleId);
                        if (module != null)
                        {
                            role.ModuleMasters.Add(module);
                        }
                        else
                        {
                            return Results.NotFound($"Module with ID: {moduleId} not found");
                        }
                    }
                }

                // Tag users to the role
                if (roleDto.UserIds != null)
                {
                    foreach (var userId in roleDto.UserIds)
                    {
                        var user = await userRepository.GetUserAsync(userId);
                        if (user != null)
                        {
                            role.UserMasters.Add(user);
                        }
                        else
                        {
                            return Results.NotFound($"User with ID: {userId} not found");
                        }
                    }
                }

                return Results.CreatedAtRoute(GetEndPointName, new { id = role.RoleId }, role);
            });

            group.MapPut("/{id}", async (int id, IIRoleMasterRepository roleRepository, IIProgramMasterRepository programRepository,
                IIModuleMasterRepository moduleRepository, IIUserMasterRepository userRepository,
                UpdateRoleMasterDto updatedRoleDto) =>
            {
                var existingRole = await roleRepository.GetRoleAsync(id);

                if (existingRole is null)
                {
                    return Results.NotFound();
                }

                // Update role properties
                existingRole.RoleName = updatedRoleDto.RoleName;
                // Update other properties as needed...

                // Clear existing program, module, and user associations
                existingRole.ProgramMasters.Clear();
                existingRole.ModuleMasters.Clear();
                existingRole.UserMasters.Clear();

                // Tag programs to the role
                if (updatedRoleDto.ProgramIds != null)
                {
                    foreach (var programId in updatedRoleDto.ProgramIds)
                    {
                        var program = await programRepository.GetProgramAsync(programId);
                        if (program != null)
                        {
                            existingRole.ProgramMasters.Add(program);
                        }
                        else
                        {
                            return Results.NotFound($"Program with ID: {programId} not found");
                        }
                    }
                }

                // Tag modules to the role
                if (updatedRoleDto.ModuleIds != null)
                {
                    foreach (var moduleId in updatedRoleDto.ModuleIds)
                    {
                        var module = await moduleRepository.GetModuleAsync(moduleId);
                        if (module != null)
                        {
                            existingRole.ModuleMasters.Add(module);
                        }
                        else
                        {
                            return Results.NotFound($"Module with ID: {moduleId} not found");
                        }
                    }
                }

                // Tag users to the role
                if (updatedRoleDto.UserIds != null)
                {
                    foreach (var userId in updatedRoleDto.UserIds)
                    {
                        var user = await userRepository.GetUserAsync(userId);
                        if (user != null)
                        {
                            existingRole.UserMasters.Add(user);
                        }
                        else
                        {
                            return Results.NotFound($"User with ID: {userId} not found");
                        }
                    }
                }

                // Update the role in the repository
                await roleRepository.UpdateRoleAsync(existingRole);

                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (IIRoleMasterRepository roleRepository, int id) =>
            {
                var role = await roleRepository.GetRoleAsync(id);

                if (role is not null)
                {
                    await roleRepository.DeleteRoleAsync(id);
                    return Results.Ok($"Deleted the role with ID: {id}");
                }
                else
                {
                    return Results.NotFound($"Role with ID: {id} not found");
                }
            });

            return group;
        }
    }
}
