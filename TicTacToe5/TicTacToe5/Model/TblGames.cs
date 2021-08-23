using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe5.Model
{
   public class TblGames
   {
      [Key]
      public int Id { get; set; }
      public string PlayerId { get; set; }
      public string Winner { get; set; }
      public string StatesJSON { get; set; }
   }
}
