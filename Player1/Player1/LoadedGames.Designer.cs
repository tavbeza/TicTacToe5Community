
namespace Player1
{
   partial class LoadedGames
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.TblBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.TblDataGridView = new System.Windows.Forms.DataGridView();
         this.labeltTitle = new System.Windows.Forms.Label();
         this.buttonLoad = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.TblBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.TblDataGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // TblDataGridView
         // 
         this.TblDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.TblDataGridView.Location = new System.Drawing.Point(24, 112);
         this.TblDataGridView.Name = "TblDataGridView";
         this.TblDataGridView.RowHeadersWidth = 51;
         this.TblDataGridView.RowTemplate.Height = 24;
         this.TblDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.TblDataGridView.Size = new System.Drawing.Size(620, 329);
         this.TblDataGridView.TabIndex = 1;
         // 
         // labeltTitle
         // 
         this.labeltTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.labeltTitle.Location = new System.Drawing.Point(11, 10);
         this.labeltTitle.Name = "labeltTitle";
         this.labeltTitle.Size = new System.Drawing.Size(452, 92);
         this.labeltTitle.TabIndex = 2;
         this.labeltTitle.Text = "PlayerName Games:";
         this.labeltTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // buttonLoad
         // 
         this.buttonLoad.BackColor = System.Drawing.Color.WhiteSmoke;
         this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.buttonLoad.Location = new System.Drawing.Point(461, 12);
         this.buttonLoad.Name = "buttonLoad";
         this.buttonLoad.Size = new System.Drawing.Size(183, 75);
         this.buttonLoad.TabIndex = 3;
         this.buttonLoad.Text = "Load";
         this.buttonLoad.UseVisualStyleBackColor = false;
         this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
         // 
         // LoadedGames
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.CadetBlue;
         this.ClientSize = new System.Drawing.Size(663, 453);
         this.Controls.Add(this.buttonLoad);
         this.Controls.Add(this.labeltTitle);
         this.Controls.Add(this.TblDataGridView);
         this.Name = "LoadedGames";
         this.Text = "TicTacToe5!";
         this.Load += new System.EventHandler(this.LoadedGames_Load);
         ((System.ComponentModel.ISupportInitialize)(this.TblBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.TblDataGridView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.BindingSource TblBindingSource;
      private System.Windows.Forms.DataGridView TblDataGridView;
      private System.Windows.Forms.Label labeltTitle;
      private System.Windows.Forms.Button buttonLoad;
   }
}