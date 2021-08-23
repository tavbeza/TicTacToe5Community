using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe5.Model
{
   public class TblPlayers
   {
      [Key]
      public string PlayerId { get; set; }

      [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*Username is mandatory")]
      public string Username { get; set; }

      [Required]
      //[StringLength(10, ErrorMessage = "Password length can't be more than 10.")]
      [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
      public string Password { get; set; }

   }
}
