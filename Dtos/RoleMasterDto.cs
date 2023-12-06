using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GameStore.API.Dtos;

 public record RoleMasterDto(
        int RoleId,
        string RoleName,
        ICollection<ProgramMasterDto> ProgramMasters,
        ICollection<ModuleMasterDto> ModuleMasters,
        ICollection<UserMasterDto> UserMasters,
        DateTime CreatedDate,
        string CreatedBy
    );

    public record CreateRoleMasterDto
{
    [Required]
    [StringLength(50)]
    public required string RoleName { get; set; }

    public List<int>? ProgramIds { get; set; }

    public List<int>? ModuleIds { get; set; }

    public List<int>? UserIds { get; set; }

    public DateTime CreatedDate { get; set; }

    [Required]
    public required string CreatedBy { get; set; }
}


    public record UpdateRoleMasterDto
{
    [Required]
    [StringLength(50)]
    public required string RoleName { get; set; }

    public List<int>? ProgramIds { get; set; }

    public List<int>? ModuleIds { get; set; }

    public List<int>? UserIds { get; set; }

    // ... other properties ...
}
