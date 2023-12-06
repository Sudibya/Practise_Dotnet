using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace GameStore.API.Entities;

public class RoleMaster
{   
            [Key]public int RoleId { get; set; }

            [Required]
            [StringLength(50)]
            public required string  RoleName { get; set; }

            // Navigation properties
            [JsonIgnore]
            public virtual ICollection<ProgramMaster>? ProgramMasters { get; set; }
            [JsonIgnore]
            public virtual ICollection<ModuleMaster>? ModuleMasters { get; set; }
            [JsonIgnore]
            public virtual ICollection<UserMaster>? UserMasters { get; set; }

            public DateTime CreatedDate { get; set; }
            public required string CreatedBy { get; set; }


}