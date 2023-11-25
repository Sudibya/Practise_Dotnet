using GameStore.API.Dtos;
using GameStore.API.Entities;
using GameStore.API.Repositories;
using System.Linq;

namespace GameStore.API.Endpoints;

public static class UserMasterEndpoints
{
    private const string GetEndPointName = "GetUser";

        public static RouteGroupBuilder MapUserMasterEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/users").WithParameterValidation();

            group.MapGet("/", async (IIUserMasterRepository userRepository) => (await userRepository.GetAllUsersAsync()).Select(user => user.AsDto()));

            group.MapGet("/", async (IIUserMasterRepository userRepository) =>
            {
                var user = await userRepository.GetAllUsersAsync();
                return user.Select(user => user.AsDto());
            });

            group.MapGet("/{id}", async (IIUserMasterRepository userRepository, int id) =>
            {
                var user = await userRepository.GetUserAsync(id);
                return user is not null ? Results.Ok(user.AsDto()) : Results.NotFound();
            }).WithName("GetUser");

            group.MapPost("/", async (IIUserMasterRepository userRepository, CreateUserMasterDto userDto) =>
            {
                var user = new UserMaster
                {
                    UserName = userDto.UserName,
                    Password = userDto.Password,
                    LoginId = userDto.LoginId,
                    DateOfActivation = userDto.DateOfActivation,
                    EmployeeId = userDto.EmployeeId
                };

                await userRepository.CreateUserAsync(user);

                return Results.CreatedAtRoute(GetEndPointName, new { id = user.Id }, user);
            });

            group.MapPut("/{id}", async (int id, IIUserMasterRepository userRepository, UpdateUserMasterDto updatedUserDto) =>
            {
                var existingUser = await userRepository.GetUserAsync(id);

                if (existingUser is null)
                {
                    return Results.NotFound();
                }

                existingUser.UserName = updatedUserDto.UserName;
                existingUser.Password = updatedUserDto.Password;
                existingUser.LoginId = updatedUserDto.LoginId;
                existingUser.DateOfActivation = updatedUserDto.DateOfActivation;
                existingUser.EmployeeId = updatedUserDto.EmployeeId;

                await userRepository.UpdateUserAsync(existingUser);

                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (IIUserMasterRepository userRepository, int id) =>
            {
                var user = await userRepository.GetUserAsync(id);

                if (user is not null)
                {
                    await userRepository.DeleteUserAsync(id);
                    return Results.Ok($"Deleted the user with ID: {id}");
                }
                else
                {
                    return Results.NotFound($"User with ID: {id} not found");
                }
            });

            return group;
        }
}