using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicTacToe5.Data;
using TicTacToe5.Model;

namespace TicTacToe5.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly TicTacToe5.Data.TicTacToe5PlayersContext _context;

        public EditModel(TicTacToe5.Data.TicTacToe5PlayersContext context)
        {
            _context = context;
        }

        [BindProperty]
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
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblPlayers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayersExists(TblPlayers.PlayerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", "NewPlayer", new { id = TblPlayers.PlayerId });
      }

        private bool TblPlayersExists(string id)
        {
            return _context.TblPlayers.Any(e => e.PlayerId == id);
        }
    }
}
