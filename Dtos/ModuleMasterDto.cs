using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record ModuleMasterDto(
    int ModuleID,
    string ModuleName
);

public record CreateModuleMasterDto(
    [Required][StringLength(20)] string ModuleName
);

public record UpdateModuleMasterDto(
    [Required][StringLength(20)] string ModuleName
);