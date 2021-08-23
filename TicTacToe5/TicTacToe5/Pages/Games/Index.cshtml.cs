using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicTacToe5.Data;
using TicTacToe5.Model;

namespace TicTacToe5.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly TicTacToe5.Data.TicTacToe5GamesContext _context;

        public IndexModel(TicTacToe5.Data.TicTacToe5GamesContext context)
        {
            _context = context;
        }

        public IList<TblGames> TblGames { get;set; }

        public async Task OnGetAsync()
        {
            TblGames = await _context.TblGames.ToListAsync();
        }
    }
}
