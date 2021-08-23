﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly TicTacToe5.Data.TicTacToe5GamesContext _context;

        public DetailsModel(TicTacToe5.Data.TicTacToe5GamesContext context)
        {
            _context = context;
        }

        public TblGames TblGames { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblGames = await _context.TblGames.FirstOrDefaultAsync(m => m.Id == id);

            if (TblGames == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
