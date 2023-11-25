using System.ComponentModel.DataAnnotations;

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
}