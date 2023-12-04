using System.ComponentModel.DataAnnotations;


namespace GameStore.API.Dtos;

public record ProgramMasterDto(
    int ProgramID,
    string ProgramName,
    int ModuleID,
    ModuleMasterDto ModuleMaster,
    string ModuleName,
    bool Active,
    DateTime ActiveDate,
    DateTime? DeactiveDate,
    string ProgramHeader
);

public record CreateProgramMasterDto(
    [Required][StringLength(255)] string ProgramName,
    [Required] int ModuleID,
    [Required][StringLength(255)] string ModuleName,
    bool Active,
    [Required] DateTime ActiveDate,
    DateTime? DeactiveDate,
    [StringLength(255)] string ProgramHeader
);

public record UpdateProgramMasterDto(
    [Required][StringLength(255)] string ProgramName,
    int ModuleID,
    [Required][StringLength(255)] string ModuleName,
    bool Active,
    [Required] DateTime ActiveDate,
    DateTime? DeactiveDate,
    [StringLength(255)] string ProgramHeader
);