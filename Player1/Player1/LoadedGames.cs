using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player1
{
   public partial class LoadedGames : Form
   {
      private TblGamesDataContext _context = new TblGamesDataContext();
      private Player _player;
      public string SelectedRowJSON { get; set; }

      public LoadedGames(Player player)
      {
         InitializeComponent();
         _player = player;
         labeltTitle.Text = String.Format("{0} Past Games:", _player.Username);
      }

      private void LoadedGames_Load(object sender, EventArgs e)
      {
         this.CenterToScreen();

         TblBindingSource.DataSource = _context.TblGames.Where(g => g.PlayerId == _player.PlayerId);
         TblDataGridView.DataSource = TblBindingSource;

      }

      private void SetSelectedRowJSON(object sender, System.EventArgs e)
      {
         Int32 selectedRowCount =
             TblDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
         if (selectedRowCount > 0)
         {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            SelectedRowJSON = TblDataGridView.SelectedRows[0].Cells[3].Value.ToString();
         }
      }

      private void buttonLoad_Click(object sender, EventArgs e)
      {
         SetSelectedRowJSON(sender, e);
         Game g = new Game(_player, SelectedRowJSON);
         g.Show();
         
      }
   }
}
