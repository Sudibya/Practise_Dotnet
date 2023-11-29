using System.ComponentModel.DataAnnotations;


namespace GameStore.API.Entities
{
    public class ModuleMaster
    {
    [Key]
    public int ModuleID { get; set; }

    [Required]
    [StringLength(20)]
    public required string ModuleName { get; set; }

    // Navigation property for Programs
    public virtual ICollection<ProgramMaster>? ProgramMaster { get; set; }
    }
}