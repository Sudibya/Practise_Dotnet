using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record UserMasterDto(
        int UserId,
        string UserName,
        string Password,
        string LoginId,
        DateTime DateOfActivation,
        int EmployeeId
    );

    public record CreateUserMasterDto(
        [Required][StringLength(50)] string UserName,
        [Required][StringLength(20)] string Password,
        [Required][StringLength(20)] string LoginId,
        [Required] DateTime DateOfActivation,
        int EmployeeId
    );

    public record UpdateUserMasterDto(
        [Required][StringLength(50)] string UserName,
        [Required][StringLength(20)] string Password,
        [Required][StringLength(20)] string LoginId,
        [Required] DateTime DateOfActivation,
        int EmployeeId
    );
