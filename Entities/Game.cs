using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.API.Entities;

public class Game
{

     public int Id { get; set; }
     
     [Required]
     [StringLength(50)]
     public required string Name { get; set; }

     [Required]
     [StringLength(20)]
     public required string Genre  { get; set; }

     [Range(0,100)]
     public decimal Price { get; set; }


     public DateTime ReleaseDate { get; set; }

     [Url]
     [StringLength(100)]
     public required String ImageUrl{ get; set; }
}