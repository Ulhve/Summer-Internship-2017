using System.Windows.Forms;

namespace Tanks
{
    partial class GameForm
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
            this.p_Map = new System.Windows.Forms.Panel();
            this.label_GameOver = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer_Game = new System.Windows.Forms.Timer(this.components);
            this.button_NewGame = new System.Windows.Forms.Button();
            this.label_ScoreValue = new System.Windows.Forms.Label();
            this.label_ScoreText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p_Map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Map
            // 
            this.p_Map.BackColor = System.Drawing.Color.Black;
            this.p_Map.Controls.Add(this.label_GameOver);
            this.p_Map.Location = new System.Drawing.Point(12, 30);
            this.p_Map.Name = "p_Map";
            this.p_Map.Size = new System.Drawing.Size(500, 474);
            this.p_Map.TabIndex = 0;
            // 
            // label_GameOver
            // 
            this.label_GameOver.AutoSize = true;
            this.label_GameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_GameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label_GameOver.Location = new System.Drawing.Point(38, 199);
            this.label_GameOver.Name = "label_GameOver";
            this.label_GameOver.Size = new System.Drawing.Size(429, 73);
            this.label_GameOver.TabIndex = 0;
            this.label_GameOver.Text = "GAME OVER";
            this.label_GameOver.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(109, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer_Game
            // 
            this.timer_Game.Enabled = true;
            this.timer_Game.Tick += new System.EventHandler(this.Timer_Game_Tick);
            // 
            // button_NewGame
            // 
            this.button_NewGame.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.button_NewGame.CausesValidation = false;
            this.button_NewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_NewGame.Location = new System.Drawing.Point(12, 2);
            this.button_NewGame.Name = "button_NewGame";
            this.button_NewGame.Size = new System.Drawing.Size(104, 26);
            this.button_NewGame.TabIndex = 1;
            this.button_NewGame.Text = "New Game";
            this.button_NewGame.UseVisualStyleBackColor = true;
            this.button_NewGame.Click += new System.EventHandler(this.Button_NewGame_Click);
            // 
            // label_ScoreValue
            // 
            this.label_ScoreValue.AutoSize = true;
            this.label_ScoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ScoreValue.Location = new System.Drawing.Point(285, 4);
            this.label_ScoreValue.Name = "label_ScoreValue";
            this.label_ScoreValue.Size = new System.Drawing.Size(19, 20);
            this.label_ScoreValue.TabIndex = 3;
            this.label_ScoreValue.Text = "0";
            // 
            // label_ScoreText
            // 
            this.label_ScoreText.AutoSize = true;
            this.label_ScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ScoreText.Location = new System.Drawing.Point(230, 4);
            this.label_ScoreText.Name = "label_ScoreText";
            this.label_ScoreText.Size = new System.Drawing.Size(49, 17);
            this.label_ScoreText.TabIndex = 2;
            this.label_ScoreText.Text = "Score:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "handling: arrows (Rght, Left, Up, Down) - for movement; Space -  for shot. ";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 540);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_NewGame);
            this.Controls.Add(this.label_ScoreValue);
            this.Controls.Add(this.label_ScoreText);
            this.Controls.Add(this.p_Map);
            this.KeyPreview = true;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PackMan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.p_Map.ResumeLayout(false);
            this.p_Map.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel p_Map;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer_Game;
        private Button button_NewGame;
        private Label label_ScoreValue;
        private Label label_GameOver;
        private Label label_ScoreText;
        private Label label1;
    }
}

