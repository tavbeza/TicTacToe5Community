using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe5.Model;

namespace TicTacToe5.Pages
{
   public class IndexModel : PageModel
   {
      private readonly ILogger<IndexModel> _logger;

      public TblPlayers TblPlayers { set; get; }

      public IndexModel(ILogger<IndexModel> logger)
      {
         _logger = logger;
      }

      public void OnGet()
      {
         
      }
      
   }
}
