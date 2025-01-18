namespace TheGameProject
{
    partial class Party
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
            this.backMapBtn = new System.Windows.Forms.PictureBox();
            this.savePartyBtn = new System.Windows.Forms.PictureBox();
            this.char1 = new System.Windows.Forms.PictureBox();
            this.charListFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.char2 = new System.Windows.Forms.PictureBox();
            this.char3 = new System.Windows.Forms.PictureBox();
            this.Namelbl = new System.Windows.Forms.Label();
            this.HPlbl = new System.Windows.Forms.Label();
            this.ATKlbl = new System.Windows.Forms.Label();
            this.HEALlbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backMapBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savePartyBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.char1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.char2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.char3)).BeginInit();
            this.SuspendLayout();
            // 
            // backMapBtn
            // 
            this.backMapBtn.Location = new System.Drawing.Point(1, 0);
            this.backMapBtn.Name = "backMapBtn";
            this.backMapBtn.Size = new System.Drawing.Size(25, 25);
            this.backMapBtn.TabIndex = 6;
            this.backMapBtn.TabStop = false;
            this.backMapBtn.Click += new System.EventHandler(this.backMapBtn_Click);
            // 
            // savePartyBtn
            // 
            this.savePartyBtn.BackColor = System.Drawing.Color.Transparent;
            this.savePartyBtn.Location = new System.Drawing.Point(492, 389);
            this.savePartyBtn.Name = "savePartyBtn";
            this.savePartyBtn.Size = new System.Drawing.Size(100, 40);
            this.savePartyBtn.TabIndex = 5;
            this.savePartyBtn.TabStop = false;
            this.savePartyBtn.Click += new System.EventHandler(this.savePartyBtn_Click);
            // 
            // char1
            // 
            this.char1.BackColor = System.Drawing.Color.Transparent;
            this.char1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.char1.Location = new System.Drawing.Point(124, 124);
            this.char1.Name = "char1";
            this.char1.Size = new System.Drawing.Size(100, 200);
            this.char1.TabIndex = 0;
            this.char1.TabStop = false;
            // 
            // charListFLP
            // 
            this.charListFLP.AutoScroll = true;
            this.charListFLP.BackColor = System.Drawing.Color.Transparent;
            this.charListFLP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.charListFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.charListFLP.Location = new System.Drawing.Point(18, 48);
            this.charListFLP.Name = "charListFLP";
            this.charListFLP.Size = new System.Drawing.Size(49, 381);
            this.charListFLP.TabIndex = 3;
            // 
            // char2
            // 
            this.char2.BackColor = System.Drawing.Color.Transparent;
            this.char2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.char2.Location = new System.Drawing.Point(296, 124);
            this.char2.Name = "char2";
            this.char2.Size = new System.Drawing.Size(100, 200);
            this.char2.TabIndex = 1;
            this.char2.TabStop = false;
            // 
            // char3
            // 
            this.char3.BackColor = System.Drawing.Color.Transparent;
            this.char3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.char3.Location = new System.Drawing.Point(455, 124);
            this.char3.Name = "char3";
            this.char3.Size = new System.Drawing.Size(100, 200);
            this.char3.TabIndex = 2;
            this.char3.TabStop = false;
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.BackColor = System.Drawing.Color.Transparent;
            this.Namelbl.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.Namelbl.Location = new System.Drawing.Point(625, 46);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(83, 25);
            this.Namelbl.TabIndex = 7;
            this.Namelbl.Text = "Namelbl";
            // 
            // HPlbl
            // 
            this.HPlbl.AutoSize = true;
            this.HPlbl.BackColor = System.Drawing.Color.Transparent;
            this.HPlbl.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.HPlbl.Location = new System.Drawing.Point(625, 79);
            this.HPlbl.Name = "HPlbl";
            this.HPlbl.Size = new System.Drawing.Size(36, 25);
            this.HPlbl.TabIndex = 8;
            this.HPlbl.Text = "HP";
            // 
            // ATKlbl
            // 
            this.ATKlbl.AutoSize = true;
            this.ATKlbl.BackColor = System.Drawing.Color.Transparent;
            this.ATKlbl.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.ATKlbl.Location = new System.Drawing.Point(625, 111);
            this.ATKlbl.Name = "ATKlbl";
            this.ATKlbl.Size = new System.Drawing.Size(44, 25);
            this.ATKlbl.TabIndex = 9;
            this.ATKlbl.Text = "ATK";
            // 
            // HEALlbl
            // 
            this.HEALlbl.AutoSize = true;
            this.HEALlbl.BackColor = System.Drawing.Color.Transparent;
            this.HEALlbl.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.HEALlbl.Location = new System.Drawing.Point(624, 144);
            this.HEALlbl.Name = "HEALlbl";
            this.HEALlbl.Size = new System.Drawing.Size(56, 25);
            this.HEALlbl.TabIndex = 10;
            this.HEALlbl.Text = "HEAL";
            // 
            // Party
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheGameProject.Properties.Resources.PartyWood;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HEALlbl);
            this.Controls.Add(this.ATKlbl);
            this.Controls.Add(this.HPlbl);
            this.Controls.Add(this.Namelbl);
            this.Controls.Add(this.char3);
            this.Controls.Add(this.savePartyBtn);
            this.Controls.Add(this.backMapBtn);
            this.Controls.Add(this.char2);
            this.Controls.Add(this.char1);
            this.Controls.Add(this.charListFLP);
            this.DoubleBuffered = true;
            this.Name = "Party";
            this.Text = "Party";
            this.Load += new System.EventHandler(this.Party_Load);
            this.Resize += new System.EventHandler(this.Party_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.backMapBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savePartyBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.char1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.char2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.char3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox char1;
        private System.Windows.Forms.PictureBox char2;
        private System.Windows.Forms.PictureBox char3;
        private System.Windows.Forms.FlowLayoutPanel charListFLP;
        private System.Windows.Forms.PictureBox savePartyBtn;
        private System.Windows.Forms.PictureBox backMapBtn;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.Label HPlbl;
        private System.Windows.Forms.Label ATKlbl;
        private System.Windows.Forms.Label HEALlbl;
    }
}