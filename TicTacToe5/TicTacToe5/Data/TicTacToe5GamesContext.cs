using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicTacToe5.Model;

namespace TicTacToe5.Data
{
    public class TicTacToe5GamesContext : DbContext
    {
        public TicTacToe5GamesContext (DbContextOptions<TicTacToe5GamesContext> options)
            : base(options)
        {
        }

        public DbSet<TicTacToe5.Model.TblGames> TblGames { get; set; }
    }
}
