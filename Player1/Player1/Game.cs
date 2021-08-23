using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Player1
{
   public partial class Game : Form
   {
      private Timer timer = new Timer();
      private static HttpClient client = new HttpClient();
      private TblGamesDataContext _context = new TblGamesDataContext();
      private Player _player;
      private GameModel GameModel { get; set; }

      // TiTacToe Variables
      Boolean checker;
      int plusone;
      private static int Turn { get; set; }

      // Contain a sequences of 4 buttons that constitute a win in the game
      public List<List<Button>> WinningMoves { get; set; }
      public List<Control> ListOfButtons { get; set; }
      public char[] Buttons { get; set; }
      public char[] EnabledArray { get; set; }

      void SetWinningMoves()
      {
         WinningMoves = new List<List<Button>>();
         // row 1
         WinningMoves.Add(new List<Button>() { button1, button2, button3, button4 });
         WinningMoves.Add(new List<Button>() { button5, button2, button3, button4 });
         // row 2
         WinningMoves.Add(new List<Button>() { button6, button7, button8, button9 });
         WinningMoves.Add(new List<Button>() { button7, button8, button9, button10 });
         // row 3
         WinningMoves.Add(new List<Button>() { button11, button12, button13, button14 });
         WinningMoves.Add(new List<Button>() { button15, button12, button13, button14 });
         // row 4
         WinningMoves.Add(new List<Button>() { button16, button17, button18, button19 });
         WinningMoves.Add(new List<Button>() { button20, button17, button18, button19 });
         // row 5
         WinningMoves.Add(new List<Button>() { button21, button22, button23, button24 });
         WinningMoves.Add(new List<Button>() { button25, button22, button23, button24 });

         // column1 1
         WinningMoves.Add(new List<Button>() { button1, button6, button11, button16 });
         WinningMoves.Add(new List<Button>() { button21, button6, button11, button16 });
         // column1 2
         WinningMoves.Add(new List<Button>() { button2, button7, button12, button17 });
         WinningMoves.Add(new List<Button>() { button22, button7, button12, button17 });
         // column1 3
         WinningMoves.Add(new List<Button>() { button3, button8, button13, button18 });
         WinningMoves.Add(new List<Button>() { button23, button8, button13, button18 });
         // column1 4
         WinningMoves.Add(new List<Button>() { button4, button9, button14, button19 });
         WinningMoves.Add(new List<Button>() { button24, button9, button14, button19 });
         // column1 5
         WinningMoves.Add(new List<Button>() { button5, button10, button15, button20 });
         WinningMoves.Add(new List<Button>() { button25, button10, button15, button20 });

         // small slant
         WinningMoves.Add(new List<Button>() { button2, button8, button14, button20 });
         WinningMoves.Add(new List<Button>() { button6, button12, button18, button24 });
         WinningMoves.Add(new List<Button>() { button4, button8, button12, button16 });
         WinningMoves.Add(new List<Button>() { button10, button14, button18, button22 });

         // big slant
         WinningMoves.Add(new List<Button>() { button1, button7, button13, button19 });
         WinningMoves.Add(new List<Button>() { button25, button7, button13, button19 });
         WinningMoves.Add(new List<Button>() { button5, button9, button13, button17 });
         WinningMoves.Add(new List<Button>() { button21, button9, button13, button17 });
      }

      void SetListOfButtons()
      {
         ListOfButtons = new List<Control>();
         Buttons = new char[25];

         foreach (Control c in panel3.Controls)
         {
            if (c.GetType() == typeof(Button))
            {
               ListOfButtons.Add(c);
               //ListOfButtons1.Add((Button) c.AccessibilityObject.Value);
            }

         }
      }

      void SetEnabledArray()
      {
         EnabledArray = new char[25];

         for (int i = 0; i < 25; i++)  // אולי זה רץ הפוך אחד מהשני
         {
            if (ListOfButtons[i].Enabled)
            {
               EnabledArray[i] = '1';
            }
            else
            {
               EnabledArray[i] = '0';
            }
         }
      }

      void EnableFalse()
      {
         foreach (var button in ListOfButtons)
         {
            button.Enabled = false;
         }
      }

      void score(string turn)
      {
         foreach (List<Button> winMove in WinningMoves)
         {
            if (winMove.All(b => b.Text == turn))
            {
               foreach (Button button in winMove)
               {
                  button.BackColor = Color.PowderBlue;
               }

               MessageBox.Show("The winner is Player " + turn, "TiCTacToe5!", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
               if(turn == "X")
               {
                  plusone = int.Parse(lblPlayerX.Text);
                  lblPlayerX.Text = Convert.ToString(plusone + 1);
               }
               else
               {
                  plusone = int.Parse(lblPlayerO.Text);
                  lblPlayerO.Text = Convert.ToString(plusone + 1);
               }

               EnableFalse();

               TblGame tblGame = new TblGame();
               tblGame.PlayerId = GameModel.PlayerId;
               tblGame.StatesJSON = JsonConvert.SerializeObject(GameModel.StatesJSON);

               if (turn == "X")
                  tblGame.Winner = _player.Username;
               else
                  tblGame.Winner = "Server";

               _context.TblGames.InsertOnSubmit(tblGame);
               _context.SubmitChanges();

               break;
            }
         }
      }

      void scoreWithoutDbSave(string turn)
      {
         foreach (List<Button> winMove in WinningMoves)
         {
            if (winMove.All(b => b.Text == turn))
            {
               foreach (Button button in winMove)
               {
                  button.BackColor = Color.PowderBlue;
               }

               //MessageBox.Show("The winner is Player " + turn, "TiCTacToe5!", MessageBoxButtons.OK, MessageBoxIcon.Information);

               if (turn == "X")
               {
                  plusone = int.Parse(lblPlayerX.Text);
                  lblPlayerX.Text = Convert.ToString(plusone + 1);
               }
               else
               {
                  plusone = int.Parse(lblPlayerO.Text);
                  lblPlayerO.Text = Convert.ToString(plusone + 1);
               }

               //EnableFalse();

               TblGame tblGame = new TblGame();
               tblGame.PlayerId = GameModel.PlayerId;
               tblGame.StatesJSON = JsonConvert.SerializeObject(GameModel.StatesJSON);

               if (turn == "X")
                  tblGame.Winner = _player.Username;
               else
                  tblGame.Winner = "Server";

               break;
            }
         }
      }

      private static async Task<Uri> PostMoveAsync(GameModel state)
      {
         HttpResponseMessage response = await client.PostAsJsonAsync("api/TblGameStates", state);
         response.EnsureSuccessStatusCode();

         return response.Headers.Location;

      }

      private static async Task<string> GetPlayersAsync2(string enabledString)
      {
         string path = string.Format("{0}/{1}/{2}", "api/TblPlayers", 5, enabledString);
         string answer = enabledString;
         HttpResponseMessage response = await client.GetAsync(path);
         if (response.IsSuccessStatusCode)
         {
            try
            {
               answer = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "TicTacToe5!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
         return answer;
      }

      private static async Task<Player> GetPlayersAsync(string path)
      {
         Player player = null;
         HttpResponseMessage response = await client.GetAsync(path);
         if (response.IsSuccessStatusCode)
         {
            player = await response.Content.ReadAsAsync<Player>();
         }
         return player;
      }

      private void SearchForValidMove(string btnName)
      {
         //Player p = await GetPlayersAsync("api/TblPlayers/5");

         if (ListOfButtons.Find(b => b.Enabled == true) != null)
         {
            checker = true;
         }

         while (checker)
         {
            var random = new Random();
            int index = random.Next(ListOfButtons.Count);

            if (ListOfButtons[index].Enabled == true && ListOfButtons[index].Name != btnName)
            {
               ListOfButtons[index].Text = "O";
               ListOfButtons[index].Enabled = false;
               checker = false;
               score("O");
            }
         }
      }

      private void Timer_Tick(object sender, EventArgs e, int i)
      {
         int p;
         for (int n = 0; n < 100000000; n++);
         
         if((i-1) <= GameModel.StatesJSON.Count() && i > 1)
         {
            string currentButton = GameModel.StatesJSON[i-1];

            ListOfButtons.Where(b => b.Name == currentButton).Single().Enabled = false;

            if (i % 2 == 0)
            {
               ListOfButtons.Where(b => b.Name == currentButton).Single().Text = "X";
               scoreWithoutDbSave("X");
            }
            else
            {
               ListOfButtons.Where(b => b.Name == currentButton).Single().Text = "O";
               scoreWithoutDbSave("O");
            }
            i = i - 1;
         }
         else
         {
            timer.Stop();
         }

         Invalidate();
         Update();
         
      }

      private void GetLoadDisplay()
      {

         for (int i = 1; i <= GameModel.StatesJSON.Count(); i++)
         {
            string currentButton;

            //timer = new Timer();
            timer.Interval = 300;
            timer.Tick += (sender, e) => Timer_Tick(sender, e, i--);
            timer.Start();

            /*currentButton = GameModel.StatesJSON[i];

            ListOfButtons.Where(b => b.Name == currentButton).Single().Enabled = false;

            if (i % 2 != 0)
            {
               ListOfButtons.Where(b => b.Name == currentButton).Single().Text = "X";
               scoreWithoutDbSave("X");
            }
            else
            {
               ListOfButtons.Where(b => b.Name == currentButton).Single().Text = "O";
               scoreWithoutDbSave("O");
            }*/

         }

      }


      public Game(Player player)
      {
         InitializeComponent();
         _player = player;
         SetWinningMoves();
         SetListOfButtons();
         GameModel = new GameModel();
         GameModel.StatesJSON = new Dictionary<int, string>();
         Turn = 1;

         //client.BaseAddress = new Uri("https://localhost:44339/");
      }

      public Game(Player player, string stepsJSON)
      {
         InitializeComponent();
         _player = player;
         SetWinningMoves();
         SetListOfButtons();
         Turn = 1;
         
         GameModel = new GameModel();
         GameModel.StatesJSON = new Dictionary<int, string>();
         GameModel.StatesJSON = JsonConvert.DeserializeObject<Dictionary<int, string>>(stepsJSON);
         
         
         
         
      }

      private void Game_Load(object sender, EventArgs e)
      {
         this.CenterToScreen();
         if (GameModel.StatesJSON.Count() == 0) // no load
         {
            client.BaseAddress = new Uri("https://localhost:44339/");
         }
         else
         {
            this.DoubleBuffered = true;
            GetLoadDisplay();
         }
         
      }

      private void btnNewGame_Click(object sender, EventArgs e)
      {
         try
         {
            Turn = 1;
            GameModel = new GameModel();
            GameModel.StatesJSON = new Dictionary<int, string>();

            foreach (var button in ListOfButtons)
            {
               button.Enabled = true;
               button.Text = "";
               button.BackColor = Color.WhiteSmoke;
            }

            lblPlayerX.Text = "0";
            lblPlayerO.Text = "0";
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "TicTacToe5!", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }

      private void btnLoad_Click(object sender, EventArgs e)
      {
         LoadedGames load = new LoadedGames(_player);
         load.Show();
         this.Close();
      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         this.Close();
         /*try
         {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "TicTacToe5!",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(iExit == DialogResult.Yes)
            {
               Application.Exit();
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "TicTacToe5!", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }*/
      }

      private async void button1_Click(object sender, EventArgs e)
      {
         button1.Text = "X";
         button1.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button1.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for(int i = 0; i<25; i++)
         {
            if(Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }

      }

      private async void button2_Click(object sender, EventArgs e)
      {
         button2.Text = "X";
         button2.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button2.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button3_Click(object sender, EventArgs e)
      {
         button3.Text = "X";
         button3.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button3.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button4_Click(object sender, EventArgs e)
      {
         button4.Text = "X";
         button4.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button4.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button5_Click(object sender, EventArgs e)
      {
         button5.Text = "X";
         button5.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button5.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button6_Click(object sender, EventArgs e)
      {
         button6.Text = "X";
         button6.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button6.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button7_Click(object sender, EventArgs e)
      {
         button7.Text = "X";
         button7.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button7.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button8_Click(object sender, EventArgs e)
      {
         button8.Text = "X";
         button8.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button8.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button9_Click(object sender, EventArgs e)
      {
         button9.Text = "X";
         button9.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button9.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button10_Click(object sender, EventArgs e)
      {
         button10.Text = "X";
         button10.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button10.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button11_Click(object sender, EventArgs e)
      {
         button11.Text = "X";
         button11.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button11.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button12_Click(object sender, EventArgs e)
      {
         button12.Text = "X";
         button12.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button12.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button13_Click(object sender, EventArgs e)
      {
         button13.Text = "X";
         button13.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button13.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button14_Click(object sender, EventArgs e)
      {
         button14.Text = "X";
         button14.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button14.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button15_Click(object sender, EventArgs e)
      {
         button15.Text = "X";
         button15.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button15.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button16_Click(object sender, EventArgs e)
      {
         button16.Text = "X";
         button16.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button16.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button17_Click(object sender, EventArgs e)
      {
         button17.Text = "X";
         button17.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button17.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button18_Click(object sender, EventArgs e)
      {
         button18.Text = "X";
         button18.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button19.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button19_Click(object sender, EventArgs e)
      {
         button19.Text = "X";
         button19.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button19.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button20_Click(object sender, EventArgs e)
      {
         button20.Text = "X";
         button20.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button20.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button21_Click(object sender, EventArgs e)
      {
         button21.Text = "X";
         button21.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button21.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button22_Click(object sender, EventArgs e)
      {
         button22.Text = "X";
         button22.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button22.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button23_Click(object sender, EventArgs e)
      {
         button23.Text = "X";
         button23.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button23.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button24_Click(object sender, EventArgs e)
      {
         button24.Text = "X";
         button24.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button24.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

      private async void button25_Click(object sender, EventArgs e)
      {
         button25.Text = "X";
         button25.Enabled = false;

         GameModel.PlayerId = _player.PlayerId;
         GameModel.StatesJSON.Add(Turn, button25.Name);
         Turn = Turn + 1;

         score("X");

         SetEnabledArray();

         string answer;
         answer = await GetPlayersAsync2(new String(EnabledArray));

         Buttons = answer.ToCharArray();

         for (int i = 0; i < 25; i++)
         {
            if (Buttons[i] == '0' && ListOfButtons[i].Enabled)
            {
               ListOfButtons[i].Text = "O";
               ListOfButtons[i].Enabled = false;

               GameModel.StatesJSON.Add(Turn, ListOfButtons[i].Name);
               Turn = Turn + 1;

               score("O");
               break;
            }
         }
      }

   }
}

      