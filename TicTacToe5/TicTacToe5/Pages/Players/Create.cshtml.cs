using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicTacToe5.Data;
using TicTacToe5.Model;

namespace TicTacToe5.Pages.Players
{
   public class CreateModel : PageModel
   {
      private readonly TicTacToe5.Data.TicTacToe5PlayersContext _context;

      public CreateModel(TicTacToe5.Data.TicTacToe5PlayersContext context)
      {
         _context = context;
      }

      public IActionResult OnGet()
      {
         return Page();
      }

      [BindProperty]
      public TblPlayers TblPlayers { get; set; }

      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://aka.ms/RazorPagesCRUD.
      public async Task<IActionResult> OnPostAsync()
      {
         if (!ModelState.IsValid)
         {
            return Page();
         }

         string uniqueId = TblPlayers.Username + "#" + TblPlayers.Password;
         TblPlayers.PlayerId = uniqueId;

         // before Add shout check if this id exist in db
         bool isExist = _context.TblPlayers.Contains(TblPlayers);

         if (isExist)
         {
            // here the user should be get that this user is already exist
            return Page();
         }
         else
         {
            _context.TblPlayers.Add(TblPlayers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", "NewPlayer", new { id = TblPlayers.PlayerId });
         }

      }
   }
}
