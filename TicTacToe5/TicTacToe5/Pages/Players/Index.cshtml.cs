using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicTacToe5.Data;
using TicTacToe5.Model;

namespace TicTacToe5.Pages.Players
{
   public class IndexModel : PageModel
   {
      private readonly TicTacToe5.Data.TicTacToe5PlayersContext _context;

      public IndexModel(TicTacToe5.Data.TicTacToe5PlayersContext context)
      {
         _context = context;
      }

      public TblPlayers TblPlayers { get; set; }
      public IList<TblPlayers> TblPlayersList { get; set; }

      public async Task OnGetNewPlayerAsync(string id)
      {
         TblPlayers = await _context.TblPlayers.Where(p => p.PlayerId == id).SingleAsync();
      }

      public async Task OnGetAsync()
      {
         TblPlayersList = await _context.TblPlayers.ToListAsync();
      }

      // when the usert click Login the program come here
      public async Task OnPostAsync()
      {
         string username = Request.Form["username"];
         string password = Request.Form["password"];

         string id = username + "#" + password;

         try
         {
            TblPlayers = await _context.TblPlayers.Where(p => p.PlayerId == id).SingleAsync();
         }
         catch (Exception e)
         {
            Console.WriteLine(e.GetType()); // what is the real exception?
            Response.Redirect("./Index");
         }
      }


   }
}
