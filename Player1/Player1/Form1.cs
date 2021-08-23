using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace Player1
{
   public partial class Form1 : Form
   {

      private static HttpClient client = new HttpClient();

      public Form1()
      {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         this.CenterToScreen();
         txtPassword.PasswordChar = '*';
         client.BaseAddress = new Uri("https://localhost:44339/");
         TblBindingNavigator.BindingSource = TblBindingSource;
      }

      private static async Task<Player> GetPlayerAsync(string path)
      {
         Player player = null;
         HttpResponseMessage response = await client.GetAsync(path);
         if (response.IsSuccessStatusCode)
         {
            player = await response.Content.ReadAsAsync<Player>();
         }
         return player;
      }


      private async void btnLogin_Click(object sender, EventArgs e)
      {
         string username = txtUsername.Text;
         string password = txtPassword.Text;
         string id = String.Format("{0}%23{1}", username, password); //username + password;

         string path = "api/TblPlayers/" + id.ToString();  // "api/TblPlayers/id"
         Player player = await GetPlayerAsync(path);
         TblBindingSource.DataSource = player;

         if(player != null) // nevigate to Game.cs
         {
            Game game = new Game(player);
            game.Show();
            Hide();
         }
         else // the player is not exist in db
         {

         }

         //TblBindingSource.DataSource = 
         //TblDataGridView.DataSource = TblBindingSource;
      }

      private void buttonExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         System.Diagnostics.Process.Start("https://localhost:44339/");
      }
   }
}
