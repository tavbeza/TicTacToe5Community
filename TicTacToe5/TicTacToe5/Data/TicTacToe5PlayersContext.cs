using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicTacToe5.Model;

namespace TicTacToe5.Data
{
    public class TicTacToe5PlayersContext : DbContext
    {
        public TicTacToe5PlayersContext (DbContextOptions<TicTacToe5PlayersContext> options)
            : base(options)
        {
        }

        public DbSet<TicTacToe5.Model.TblPlayers> TblPlayers { get; set; }

   }
}
