using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.API.Entities;

public class Game
{
     public int Id { get; set; }
     
     public required string Name { get; set; }

     public required string Genre  { get; set; }

     public decimal Price { get; set; }

     public DateTime ReleaseDate { get; set; }

     public required String ImageUrl{ get; set; }
}