using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


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

    [ForeignKey("RoleId")]
    [JsonIgnore]
    public virtual RoleMaster? RoleMaster { get; set; }

    }
}