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
    public class DetailsModel : PageModel
    {
        private readonly TicTacToe5.Data.TicTacToe5PlayersContext _context;

        public DetailsModel(TicTacToe5.Data.TicTacToe5PlayersContext context)
        {
            _context = context;
        }

        public TblPlayers TblPlayers { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblPlayers = await _context.TblPlayers.FirstOrDefaultAsync(m => m.PlayerId == id);

            if (TblPlayers == null)
            {
                return NotFound();
            }
            return Page();
            //return RedirectToPage("./Index", "NewPlayer", new { id = TblPlayers.PlayerId });
      }
    }
}
