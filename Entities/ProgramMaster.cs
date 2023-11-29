using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace GameStore.API.Entities
{
    public class ProgramMaster
    {
            [Key]
    public int ProgramID { get; set; }

    [Required]
    [StringLength(255)]
    public required string ProgramName { get; set; }

    public int ModuleID { get; set; }

    // Navigation property for Module
    [ForeignKey ("ModuleID")]
    public virtual required ModuleMaster ModuleMaster { get; set; }

    [Required]
    [StringLength(255)]
    public required string ModuleName { get; set; }

    public bool Active { get; set; }

    [DataType(DataType.Date)]
    public DateTime ActiveDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DeactiveDate { get; set; }

    [StringLength(255)]
    public required string ProgramHeader { get; set; }
    }
}