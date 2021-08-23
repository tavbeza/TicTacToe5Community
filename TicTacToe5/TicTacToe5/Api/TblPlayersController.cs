using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicTacToe5.Data;
using TicTacToe5.Model;

namespace TicTacToe5.Api
{
   [Route("api/[controller]")]
   [ApiController]
   public class TblPlayersController : ControllerBase
   {
      private readonly TicTacToe5PlayersContext _context;

      public TblPlayersController(TicTacToe5PlayersContext context)
      {
         _context = context;
      }

      // GET: api/TblPlayers
      [HttpGet]
      public async Task<ActionResult<IEnumerable<TblPlayers>>> GetTblPlayers()
      {
         return await _context.TblPlayers.ToListAsync();
      }

      // GET: api/TblPlayers/5/1101
      [HttpGet("{id}/{enabledString}")]
      public string GetTblPlayers(string? id, string enabledString)
      {
         char[] s = enabledString.ToCharArray();
         //Task<string> res = Task.FromResult(enabledString);

         bool checker = true;
         while (checker)
         {
            var random = new Random();
            int index = random.Next(enabledString.Length);

            if (enabledString[index] == '1')
            {

               s[index] = '0';
               //res = Task.FromResult(s.ToString());
               return new String(s);
               /*ListOfButtons[index].Text = "O";
               ListOfButtons[index].Enabled = false;
               checker = false;
               score("O");*/
            }
         }
         return new String(s);
      }

      // GET: api/TblPlayers/5
      [HttpGet("{id}")]
      public async Task<ActionResult<TblPlayers>> GetTblPlayers(string id)
      {
         var tblPlayers = await _context.TblPlayers.FindAsync(id);

         if (tblPlayers == null)
         {
            return NotFound();
         }

         return tblPlayers;
      }

      // PUT: api/TblPlayers/5
      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      [HttpPut("{id}")]
      public async Task<IActionResult> PutTblPlayers(string id, TblPlayers tblPlayers)
      {
         if (id != tblPlayers.PlayerId)
         {
            return BadRequest();
         }

         _context.Entry(tblPlayers).State = EntityState.Modified;

         try
         {
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!TblPlayersExists(id))
            {
               return NotFound();
            }
            else
            {
               throw;
            }
         }

         return NoContent();
      }

      // POST: api/TblPlayers
      // To protect from overposting attacks, enable the specific properties you want to bind to, for
      // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
      [HttpPost]
      public async Task<ActionResult<TblPlayers>> PostTblGameState(TblPlayers tblPlayers)
      {
         //_context.TblGameState.Add(tblGameState);
         //await _context.SaveChangesAsync();

         try
         {
            //_context.TblGameState.Add(tblGameState);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTblGameState", new { id = tblPlayers.PlayerId }, tblPlayers);
         }
         catch (Exception ex)
         {
            throw new Exception("Error-" + ex.Message);
         }

         //return CreatedAtAction("GetTblGameState", tblGameState);

         /* _context.TblGameState.Add(tblGameState);
             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateException)
             {
                 /*if (TblPlayersExists(tblPlayers.Id))
                 {
                     return Conflict();
                 }
                 else*/
         //{
         // throw;
         //}
         //}
         //return CreatedAtAction("GetTblPlayers", new { id = tblPlayers.Id }, tblPlayers);
      }

      // DELETE: api/TblPlayers/5
      [HttpDelete("{id}")]
      public async Task<ActionResult<TblPlayers>> DeleteTblPlayers(string id)
      {
         var tblPlayers = await _context.TblPlayers.FindAsync(id);
         if (tblPlayers == null)
         {
            return NotFound();
         }

         _context.TblPlayers.Remove(tblPlayers);
         await _context.SaveChangesAsync();

         return tblPlayers;
      }

      private bool TblPlayersExists(string id)
      {
         return _context.TblPlayers.Any(e => e.PlayerId == id);
      }

   }
}
