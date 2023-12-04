using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace GameStore.API.Entities;

public class UserMaster
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string UserName { get; set; }

    [Required]
    [StringLength(20)]
    public required string Password { get; set; }

    [Required]
    [StringLength(20)]
    public required string LoginId { get; set; }

    [Required]
    public DateTime DateOfActivation { get; set; }
    
    
    public int EmployeeId { get; set; } 

    [ForeignKey("RoleId")]
    [JsonIgnore]
    public virtual RoleMaster? RoleMaster { get; set; }

}


