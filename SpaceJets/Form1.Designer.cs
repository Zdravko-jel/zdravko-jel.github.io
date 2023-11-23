namespace SpaceJets
{
    partial class GameWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.BackgroundMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.LeftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.UpMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.DownMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.MunitionMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.EnemyMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemyMunitionTimer = new System.Windows.Forms.Timer(this.components);
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ReplayBtn = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.scorelbl = new System.Windows.Forms.Label();
            this.levellbl = new System.Windows.Forms.Label();
            this.scoretext = new System.Windows.Forms.Label();
            this.leveltext = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundMoveTimer
            // 
            this.BackgroundMoveTimer.Enabled = true;
            this.BackgroundMoveTimer.Interval = 10;
            this.BackgroundMoveTimer.Tick += new System.EventHandler(this.BackgroundMoveTimer_Tick);
            // 
            // LeftMoveTimer
            // 
            this.LeftMoveTimer.Enabled = true;
            this.LeftMoveTimer.Interval = 5;
            this.LeftMoveTimer.Tick += new System.EventHandler(this.LeftMoveTimer_Tick);
            // 
            // RightMoveTimer
            // 
            this.RightMoveTimer.Enabled = true;
            this.RightMoveTimer.Interval = 5;
            this.RightMoveTimer.Tick += new System.EventHandler(this.RightMoveTimer_Tick);
            // 
            // UpMoveTimer
            // 
            this.UpMoveTimer.Enabled = true;
            this.UpMoveTimer.Interval = 5;
            this.UpMoveTimer.Tick += new System.EventHandler(this.UpMoveTimer_Tick);
            // 
            // DownMoveTimer
            // 
            this.DownMoveTimer.Enabled = true;
            this.DownMoveTimer.Interval = 5;
            this.DownMoveTimer.Tick += new System.EventHandler(this.DownMoveTimer_Tick);
            // 
            // MunitionMoveTimer
            // 
            this.MunitionMoveTimer.Enabled = true;
            this.MunitionMoveTimer.Interval = 20;
            this.MunitionMoveTimer.Tick += new System.EventHandler(this.MunitionMoveTimer_Tick);
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(260, 400);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(50, 50);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // EnemyMoveTimer
            // 
            this.EnemyMoveTimer.Enabled = true;
            this.EnemyMoveTimer.Tick += new System.EventHandler(this.EnemyMoveTimer_Tick);
            // 
            // EnemyMunitionTimer
            // 
            this.EnemyMunitionTimer.Enabled = true;
            this.EnemyMunitionTimer.Interval = 20;
            this.EnemyMunitionTimer.Tick += new System.EventHandler(this.EnemyMunitionTimer_Tick);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Location = new System.Drawing.Point(160, 292);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(257, 54);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Visible = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ReplayBtn
            // 
            this.ReplayBtn.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReplayBtn.Location = new System.Drawing.Point(160, 223);
            this.ReplayBtn.Name = "ReplayBtn";
            this.ReplayBtn.Size = new System.Drawing.Size(257, 54);
            this.ReplayBtn.TabIndex = 2;
            this.ReplayBtn.Text = "Replay";
            this.ReplayBtn.UseVisualStyleBackColor = true;
            this.ReplayBtn.Visible = false;
            this.ReplayBtn.Click += new System.EventHandler(this.ReplayBtn_Click);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Algerian", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.name.Location = new System.Drawing.Point(119, 103);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(330, 54);
            this.name.TabIndex = 3;
            this.name.Text = "label1";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name.Visible = false;
            // 
            // scorelbl
            // 
            this.scorelbl.AutoSize = true;
            this.scorelbl.Font = new System.Drawing.Font("Engravers MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorelbl.ForeColor = System.Drawing.Color.Red;
            this.scorelbl.Location = new System.Drawing.Point(109, 9);
            this.scorelbl.Name = "scorelbl";
            this.scorelbl.Size = new System.Drawing.Size(20, 19);
            this.scorelbl.TabIndex = 4;
            this.scorelbl.Text = "0";
            this.scorelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // levellbl
            // 
            this.levellbl.AutoSize = true;
            this.levellbl.Font = new System.Drawing.Font("Engravers MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levellbl.ForeColor = System.Drawing.Color.Red;
            this.levellbl.Location = new System.Drawing.Point(552, 9);
            this.levellbl.Name = "levellbl";
            this.levellbl.Size = new System.Drawing.Size(20, 19);
            this.levellbl.TabIndex = 5;
            this.levellbl.Text = "1";
            this.levellbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoretext
            // 
            this.scoretext.AutoSize = true;
            this.scoretext.Font = new System.Drawing.Font("Engravers MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoretext.ForeColor = System.Drawing.Color.Red;
            this.scoretext.Location = new System.Drawing.Point(12, 9);
            this.scoretext.Name = "scoretext";
            this.scoretext.Size = new System.Drawing.Size(91, 19);
            this.scoretext.TabIndex = 6;
            this.scoretext.Text = "Score:";
            // 
            // leveltext
            // 
            this.leveltext.AutoSize = true;
            this.leveltext.Font = new System.Drawing.Font("Engravers MT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leveltext.ForeColor = System.Drawing.Color.Red;
            this.leveltext.Location = new System.Drawing.Point(459, 9);
            this.leveltext.Name = "leveltext";
            this.leveltext.Size = new System.Drawing.Size(87, 19);
            this.leveltext.TabIndex = 7;
            this.leveltext.Text = "Level:";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.leveltext);
            this.Controls.Add(this.scoretext);
            this.Controls.Add(this.levellbl);
            this.Controls.Add(this.scorelbl);
            this.Controls.Add(this.name);
            this.Controls.Add(this.ReplayBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.player);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.Name = "GameWindow";
            this.Text = "Space Jets";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer BackgroundMoveTimer;
        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer MunitionMoveTimer;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer EnemyMoveTimer;
        private System.Windows.Forms.Timer EnemyMunitionTimer;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ReplayBtn;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label scorelbl;
        private System.Windows.Forms.Label levellbl;
        private System.Windows.Forms.Label scoretext;
        private System.Windows.Forms.Label leveltext;
    }
}

