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
    public class NumOfGamesModel : PageModel
    {

      private readonly TicTacToe5.Data.TicTacToe5GamesContext _context;
      public int Count { get; set; }

      public NumOfGamesModel(TicTacToe5.Data.TicTacToe5GamesContext context)
        {
            _context = context;
         Count = 0;
      }

        public IList<TblGames> TblGames { get;set; }

        public async Task OnGetAsync()
        {
         /*int numOfRows;
         numOfRows = _context.TblGames.Select(g => g.PlayerId).Count();

         _context.TblGames.Select(g => new { PlayerId = g.PlayerId, Count = Count })
            .OrderBy(numOfGames => numOfGames)

         //string l =
         await _context.TblGames.GroupBy(g => new { PlayerId = g.PlayerId, Count = Count})
            .Select(g => g).ToListAsync();
         int x;
         x = 4;*/

         //_context.TblGames.Select(g => new { PlayerId = g.PlayerId });
         //TblGames = await _context.TblGames.Select(g => g.PlayerId).ToListAsync();
        }
    }
}
