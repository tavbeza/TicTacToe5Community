
namespace Player1
{
   partial class Form1
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.TblBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.TblBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
         this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
         this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
         this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
         this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.username = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.txtUsername = new System.Windows.Forms.TextBox();
         this.txtPassword = new System.Windows.Forms.TextBox();
         this.btnLogin = new System.Windows.Forms.Button();
         this.buttonExit = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.linkLabel1 = new System.Windows.Forms.LinkLabel();
         this.label3 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.TblBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.TblBindingNavigator)).BeginInit();
         this.TblBindingNavigator.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // TblBindingNavigator
         // 
         this.TblBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
         this.TblBindingNavigator.CountItem = this.bindingNavigatorCountItem;
         this.TblBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
         this.TblBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.TblBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
         this.TblBindingNavigator.Location = new System.Drawing.Point(0, 0);
         this.TblBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
         this.TblBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
         this.TblBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
         this.TblBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
         this.TblBindingNavigator.Name = "TblBindingNavigator";
         this.TblBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
         this.TblBindingNavigator.Size = new System.Drawing.Size(799, 27);
         this.TblBindingNavigator.TabIndex = 0;
         this.TblBindingNavigator.Text = "bindingNavigator1";
         // 
         // bindingNavigatorAddNewItem
         // 
         this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
         this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
         this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
         this.bindingNavigatorAddNewItem.Text = "Add new";
         // 
         // bindingNavigatorCountItem
         // 
         this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
         this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
         this.bindingNavigatorCountItem.Text = "of {0}";
         this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
         // 
         // bindingNavigatorDeleteItem
         // 
         this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
         this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
         this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
         this.bindingNavigatorDeleteItem.Text = "Delete";
         // 
         // bindingNavigatorMoveFirstItem
         // 
         this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
         this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
         this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
         this.bindingNavigatorMoveFirstItem.Text = "Move first";
         // 
         // bindingNavigatorMovePreviousItem
         // 
         this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
         this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
         this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
         this.bindingNavigatorMovePreviousItem.Text = "Move previous";
         // 
         // bindingNavigatorSeparator
         // 
         this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
         this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
         // 
         // bindingNavigatorPositionItem
         // 
         this.bindingNavigatorPositionItem.AccessibleName = "Position";
         this.bindingNavigatorPositionItem.AutoSize = false;
         this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
         this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
         this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
         this.bindingNavigatorPositionItem.Text = "0";
         this.bindingNavigatorPositionItem.ToolTipText = "Current position";
         // 
         // bindingNavigatorSeparator1
         // 
         this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
         this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
         // 
         // bindingNavigatorMoveNextItem
         // 
         this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
         this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
         this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
         this.bindingNavigatorMoveNextItem.Text = "Move next";
         // 
         // bindingNavigatorMoveLastItem
         // 
         this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
         this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
         this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
         this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
         this.bindingNavigatorMoveLastItem.Text = "Move last";
         // 
         // bindingNavigatorSeparator2
         // 
         this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
         this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
         // 
         // username
         // 
         this.username.AutoSize = true;
         this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.username.Location = new System.Drawing.Point(334, 114);
         this.username.Name = "username";
         this.username.Size = new System.Drawing.Size(135, 25);
         this.username.TabIndex = 2;
         this.username.Text = "USER NAME:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.label2.Location = new System.Drawing.Point(334, 172);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(136, 25);
         this.label2.TabIndex = 3;
         this.label2.Text = "PASSWORD:";
         // 
         // txtUsername
         // 
         this.txtUsername.Location = new System.Drawing.Point(492, 114);
         this.txtUsername.Name = "txtUsername";
         this.txtUsername.Size = new System.Drawing.Size(239, 22);
         this.txtUsername.TabIndex = 4;
         // 
         // txtPassword
         // 
         this.txtPassword.Location = new System.Drawing.Point(492, 172);
         this.txtPassword.Name = "txtPassword";
         this.txtPassword.Size = new System.Drawing.Size(239, 22);
         this.txtPassword.TabIndex = 5;
         // 
         // btnLogin
         // 
         this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.btnLogin.Location = new System.Drawing.Point(524, 215);
         this.btnLogin.Name = "btnLogin";
         this.btnLogin.Size = new System.Drawing.Size(100, 54);
         this.btnLogin.TabIndex = 6;
         this.btnLogin.Text = "Login";
         this.btnLogin.UseVisualStyleBackColor = true;
         this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
         // 
         // buttonExit
         // 
         this.buttonExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.buttonExit.Location = new System.Drawing.Point(630, 215);
         this.buttonExit.Name = "buttonExit";
         this.buttonExit.Size = new System.Drawing.Size(101, 54);
         this.buttonExit.TabIndex = 6;
         this.buttonExit.Text = "Exit";
         this.buttonExit.UseVisualStyleBackColor = true;
         this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.Color.DarkOliveGreen;
         this.panel1.Controls.Add(this.linkLabel1);
         this.panel1.Controls.Add(this.label3);
         this.panel1.Controls.Add(this.label5);
         this.panel1.Controls.Add(this.label4);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Location = new System.Drawing.Point(12, 44);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(289, 362);
         this.panel1.TabIndex = 7;
         // 
         // linkLabel1
         // 
         this.linkLabel1.AutoSize = true;
         this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.linkLabel1.LinkColor = System.Drawing.Color.Aqua;
         this.linkLabel1.Location = new System.Drawing.Point(105, 217);
         this.linkLabel1.Name = "linkLabel1";
         this.linkLabel1.Size = new System.Drawing.Size(72, 20);
         this.linkLabel1.TabIndex = 2;
         this.linkLabel1.TabStop = true;
         this.linkLabel1.Text = "Register";
         this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.label3.ForeColor = System.Drawing.Color.White;
         this.label3.Location = new System.Drawing.Point(54, 63);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(164, 29);
         this.label3.TabIndex = 1;
         this.label3.Text = "TicTacToe5!";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.label5.ForeColor = System.Drawing.Color.White;
         this.label5.Location = new System.Drawing.Point(54, 140);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(163, 29);
         this.label5.TabIndex = 0;
         this.label5.Text = "New Player ?";
         this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.label4.ForeColor = System.Drawing.Color.White;
         this.label4.Location = new System.Drawing.Point(25, 179);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(245, 29);
         this.label4.TabIndex = 0;
         this.label4.Text = "Join Our Community";
         this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
         this.label1.ForeColor = System.Drawing.Color.White;
         this.label1.Location = new System.Drawing.Point(13, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(148, 29);
         this.label1.TabIndex = 0;
         this.label1.Text = "Welcome to";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.CadetBlue;
         this.ClientSize = new System.Drawing.Size(799, 418);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.buttonExit);
         this.Controls.Add(this.btnLogin);
         this.Controls.Add(this.txtPassword);
         this.Controls.Add(this.txtUsername);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.username);
         this.Controls.Add(this.TblBindingNavigator);
         this.Name = "Form1";
         this.Text = "Tic Tac Toe 5!";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.TblBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.TblBindingNavigator)).EndInit();
         this.TblBindingNavigator.ResumeLayout(false);
         this.TblBindingNavigator.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.BindingSource TblBindingSource;
      private System.Windows.Forms.BindingNavigator TblBindingNavigator;
      private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
      private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
      private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
      private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
      private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
      private System.Windows.Forms.Label username;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtUsername;
      private System.Windows.Forms.TextBox txtPassword;
      private System.Windows.Forms.Button btnLogin;
      private System.Windows.Forms.Button buttonExit;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.LinkLabel linkLabel1;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
   }
}

