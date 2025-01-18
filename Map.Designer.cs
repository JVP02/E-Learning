namespace TheGameProject
{
    partial class Map
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
            this.MapPan = new System.Windows.Forms.Panel();
            this.quizBtn = new System.Windows.Forms.PictureBox();
            this.gachaBtn = new System.Windows.Forms.PictureBox();
            this.levelInfo = new System.Windows.Forms.Panel();
            this.cancelMapBtn = new System.Windows.Forms.Button();
            this.levelPrev = new System.Windows.Forms.PictureBox();
            this.levelDesc = new System.Windows.Forms.Label();
            this.levelNo = new System.Windows.Forms.Label();
            this.startMapBtn = new System.Windows.Forms.Button();
            this.lvl10 = new System.Windows.Forms.PictureBox();
            this.lvl9 = new System.Windows.Forms.PictureBox();
            this.lvl8 = new System.Windows.Forms.PictureBox();
            this.lvl7 = new System.Windows.Forms.PictureBox();
            this.lvl6 = new System.Windows.Forms.PictureBox();
            this.lvl5 = new System.Windows.Forms.PictureBox();
            this.lvl4 = new System.Windows.Forms.PictureBox();
            this.lvl3 = new System.Windows.Forms.PictureBox();
            this.lvl2 = new System.Windows.Forms.PictureBox();
            this.lvl1 = new System.Windows.Forms.PictureBox();
            this.setMapBtn = new System.Windows.Forms.PictureBox();
            this.invMapBtn = new System.Windows.Forms.PictureBox();
            this.backMenuBtn = new System.Windows.Forms.PictureBox();
            this.MapPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quizBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gachaBtn)).BeginInit();
            this.levelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setMapBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invMapBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backMenuBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // MapPan
            // 
            this.MapPan.AutoScroll = true;
            this.MapPan.BackgroundImage = global::TheGameProject.Properties.Resources.Ph1500x500;
            this.MapPan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MapPan.Controls.Add(this.quizBtn);
            this.MapPan.Controls.Add(this.gachaBtn);
            this.MapPan.Controls.Add(this.levelInfo);
            this.MapPan.Controls.Add(this.lvl10);
            this.MapPan.Controls.Add(this.lvl9);
            this.MapPan.Controls.Add(this.lvl8);
            this.MapPan.Controls.Add(this.lvl7);
            this.MapPan.Controls.Add(this.lvl6);
            this.MapPan.Controls.Add(this.lvl5);
            this.MapPan.Controls.Add(this.lvl4);
            this.MapPan.Controls.Add(this.lvl3);
            this.MapPan.Controls.Add(this.lvl2);
            this.MapPan.Controls.Add(this.lvl1);
            this.MapPan.Controls.Add(this.setMapBtn);
            this.MapPan.Controls.Add(this.invMapBtn);
            this.MapPan.Controls.Add(this.backMenuBtn);
            this.MapPan.Location = new System.Drawing.Point(0, -2);
            this.MapPan.Name = "MapPan";
            this.MapPan.Size = new System.Drawing.Size(804, 457);
            this.MapPan.TabIndex = 1;
            // 
            // quizBtn
            // 
            this.quizBtn.BackColor = System.Drawing.Color.Transparent;
            this.quizBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.quizBtn.Location = new System.Drawing.Point(0, 148);
            this.quizBtn.Name = "quizBtn";
            this.quizBtn.Size = new System.Drawing.Size(35, 35);
            this.quizBtn.TabIndex = 28;
            this.quizBtn.TabStop = false;
            this.quizBtn.Click += new System.EventHandler(this.quizBtn_Click);
            // 
            // gachaBtn
            // 
            this.gachaBtn.BackColor = System.Drawing.Color.Transparent;
            this.gachaBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gachaBtn.Location = new System.Drawing.Point(0, 110);
            this.gachaBtn.Name = "gachaBtn";
            this.gachaBtn.Size = new System.Drawing.Size(35, 35);
            this.gachaBtn.TabIndex = 27;
            this.gachaBtn.TabStop = false;
            this.gachaBtn.Click += new System.EventHandler(this.gachaBtn_Click);
            // 
            // levelInfo
            // 
            this.levelInfo.BackgroundImage = global::TheGameProject.Properties.Resources.LevelInfoWood;
            this.levelInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.levelInfo.Controls.Add(this.cancelMapBtn);
            this.levelInfo.Controls.Add(this.levelPrev);
            this.levelInfo.Controls.Add(this.levelDesc);
            this.levelInfo.Controls.Add(this.levelNo);
            this.levelInfo.Controls.Add(this.startMapBtn);
            this.levelInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.levelInfo.Location = new System.Drawing.Point(652, 3);
            this.levelInfo.Name = "levelInfo";
            this.levelInfo.Size = new System.Drawing.Size(149, 449);
            this.levelInfo.TabIndex = 5;
            this.levelInfo.Visible = false;
            // 
            // cancelMapBtn
            // 
            this.cancelMapBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelMapBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelMapBtn.Location = new System.Drawing.Point(13, 401);
            this.cancelMapBtn.Name = "cancelMapBtn";
            this.cancelMapBtn.Size = new System.Drawing.Size(122, 23);
            this.cancelMapBtn.TabIndex = 4;
            this.cancelMapBtn.Text = "Cancel";
            this.cancelMapBtn.UseVisualStyleBackColor = true;
            this.cancelMapBtn.Click += new System.EventHandler(this.cancelMapBtn_Click);
            // 
            // levelPrev
            // 
            this.levelPrev.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.levelPrev.Location = new System.Drawing.Point(8, 11);
            this.levelPrev.Name = "levelPrev";
            this.levelPrev.Size = new System.Drawing.Size(131, 120);
            this.levelPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.levelPrev.TabIndex = 2;
            this.levelPrev.TabStop = false;
            // 
            // levelDesc
            // 
            this.levelDesc.AutoSize = true;
            this.levelDesc.BackColor = System.Drawing.Color.Transparent;
            this.levelDesc.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelDesc.ForeColor = System.Drawing.Color.White;
            this.levelDesc.Location = new System.Drawing.Point(8, 184);
            this.levelDesc.MaximumSize = new System.Drawing.Size(210, 3000);
            this.levelDesc.Name = "levelDesc";
            this.levelDesc.Size = new System.Drawing.Size(39, 19);
            this.levelDesc.TabIndex = 1;
            this.levelDesc.Text = "Desc";
            // 
            // levelNo
            // 
            this.levelNo.AutoSize = true;
            this.levelNo.BackColor = System.Drawing.Color.Transparent;
            this.levelNo.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelNo.ForeColor = System.Drawing.SystemColors.Control;
            this.levelNo.Location = new System.Drawing.Point(65, 149);
            this.levelNo.Name = "levelNo";
            this.levelNo.Size = new System.Drawing.Size(17, 19);
            this.levelNo.TabIndex = 0;
            this.levelNo.Text = "[]";
            this.levelNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // startMapBtn
            // 
            this.startMapBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startMapBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startMapBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startMapBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startMapBtn.Location = new System.Drawing.Point(16, 351);
            this.startMapBtn.Name = "startMapBtn";
            this.startMapBtn.Size = new System.Drawing.Size(119, 40);
            this.startMapBtn.TabIndex = 3;
            this.startMapBtn.Text = "Start";
            this.startMapBtn.UseVisualStyleBackColor = false;
            this.startMapBtn.Click += new System.EventHandler(this.startMapBtn_Click);
            // 
            // lvl10
            // 
            this.lvl10.BackColor = System.Drawing.Color.Transparent;
            this.lvl10.Location = new System.Drawing.Point(238, 42);
            this.lvl10.Name = "lvl10";
            this.lvl10.Size = new System.Drawing.Size(25, 25);
            this.lvl10.TabIndex = 26;
            this.lvl10.TabStop = false;
            // 
            // lvl9
            // 
            this.lvl9.BackColor = System.Drawing.Color.Transparent;
            this.lvl9.Location = new System.Drawing.Point(221, 113);
            this.lvl9.Name = "lvl9";
            this.lvl9.Size = new System.Drawing.Size(25, 25);
            this.lvl9.TabIndex = 25;
            this.lvl9.TabStop = false;
            // 
            // lvl8
            // 
            this.lvl8.BackColor = System.Drawing.Color.Transparent;
            this.lvl8.Location = new System.Drawing.Point(311, 113);
            this.lvl8.Name = "lvl8";
            this.lvl8.Size = new System.Drawing.Size(25, 25);
            this.lvl8.TabIndex = 24;
            this.lvl8.TabStop = false;
            // 
            // lvl7
            // 
            this.lvl7.BackColor = System.Drawing.Color.Transparent;
            this.lvl7.Location = new System.Drawing.Point(403, 113);
            this.lvl7.Name = "lvl7";
            this.lvl7.Size = new System.Drawing.Size(25, 25);
            this.lvl7.TabIndex = 23;
            this.lvl7.TabStop = false;
            // 
            // lvl6
            // 
            this.lvl6.BackColor = System.Drawing.Color.Transparent;
            this.lvl6.Location = new System.Drawing.Point(482, 133);
            this.lvl6.Name = "lvl6";
            this.lvl6.Size = new System.Drawing.Size(25, 25);
            this.lvl6.TabIndex = 22;
            this.lvl6.TabStop = false;
            // 
            // lvl5
            // 
            this.lvl5.BackColor = System.Drawing.Color.Transparent;
            this.lvl5.Location = new System.Drawing.Point(514, 202);
            this.lvl5.Name = "lvl5";
            this.lvl5.Size = new System.Drawing.Size(25, 25);
            this.lvl5.TabIndex = 21;
            this.lvl5.TabStop = false;
            // 
            // lvl4
            // 
            this.lvl4.BackColor = System.Drawing.Color.Transparent;
            this.lvl4.Location = new System.Drawing.Point(470, 259);
            this.lvl4.Name = "lvl4";
            this.lvl4.Size = new System.Drawing.Size(25, 25);
            this.lvl4.TabIndex = 20;
            this.lvl4.TabStop = false;
            // 
            // lvl3
            // 
            this.lvl3.BackColor = System.Drawing.Color.Transparent;
            this.lvl3.Location = new System.Drawing.Point(601, 283);
            this.lvl3.Name = "lvl3";
            this.lvl3.Size = new System.Drawing.Size(25, 25);
            this.lvl3.TabIndex = 19;
            this.lvl3.TabStop = false;
            // 
            // lvl2
            // 
            this.lvl2.BackColor = System.Drawing.Color.Transparent;
            this.lvl2.Location = new System.Drawing.Point(531, 323);
            this.lvl2.Name = "lvl2";
            this.lvl2.Size = new System.Drawing.Size(25, 25);
            this.lvl2.TabIndex = 18;
            this.lvl2.TabStop = false;
            // 
            // lvl1
            // 
            this.lvl1.BackColor = System.Drawing.Color.Transparent;
            this.lvl1.Location = new System.Drawing.Point(514, 363);
            this.lvl1.Name = "lvl1";
            this.lvl1.Size = new System.Drawing.Size(25, 25);
            this.lvl1.TabIndex = 17;
            this.lvl1.TabStop = false;
            // 
            // setMapBtn
            // 
            this.setMapBtn.BackColor = System.Drawing.Color.Transparent;
            this.setMapBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.setMapBtn.Location = new System.Drawing.Point(0, 72);
            this.setMapBtn.Name = "setMapBtn";
            this.setMapBtn.Size = new System.Drawing.Size(35, 35);
            this.setMapBtn.TabIndex = 16;
            this.setMapBtn.TabStop = false;
            this.setMapBtn.Click += new System.EventHandler(this.setMapBtn_Click_1);
            // 
            // invMapBtn
            // 
            this.invMapBtn.BackColor = System.Drawing.Color.Transparent;
            this.invMapBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.invMapBtn.Location = new System.Drawing.Point(0, 34);
            this.invMapBtn.Name = "invMapBtn";
            this.invMapBtn.Size = new System.Drawing.Size(35, 35);
            this.invMapBtn.TabIndex = 15;
            this.invMapBtn.TabStop = false;
            this.invMapBtn.Click += new System.EventHandler(this.invMapBtn_Click_1);
            // 
            // backMenuBtn
            // 
            this.backMenuBtn.BackColor = System.Drawing.Color.Transparent;
            this.backMenuBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.backMenuBtn.Location = new System.Drawing.Point(3, 3);
            this.backMenuBtn.Name = "backMenuBtn";
            this.backMenuBtn.Size = new System.Drawing.Size(25, 25);
            this.backMenuBtn.TabIndex = 14;
            this.backMenuBtn.TabStop = false;
            this.backMenuBtn.Click += new System.EventHandler(this.backMenuBtn_Click_1);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MapPan);
            this.Name = "Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            this.Resize += new System.EventHandler(this.Map_Resize);
            this.MapPan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quizBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gachaBtn)).EndInit();
            this.levelInfo.ResumeLayout(false);
            this.levelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setMapBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invMapBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backMenuBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MapPan;
        private System.Windows.Forms.Panel levelInfo;
        private System.Windows.Forms.Label levelNo;
        private System.Windows.Forms.PictureBox levelPrev;
        private System.Windows.Forms.Label levelDesc;
        private System.Windows.Forms.Button cancelMapBtn;
        private System.Windows.Forms.Button startMapBtn;
        private System.Windows.Forms.PictureBox backMenuBtn;
        private System.Windows.Forms.PictureBox setMapBtn;
        private System.Windows.Forms.PictureBox invMapBtn;
        private System.Windows.Forms.PictureBox lvl10;
        private System.Windows.Forms.PictureBox lvl9;
        private System.Windows.Forms.PictureBox lvl8;
        private System.Windows.Forms.PictureBox lvl7;
        private System.Windows.Forms.PictureBox lvl6;
        private System.Windows.Forms.PictureBox lvl5;
        private System.Windows.Forms.PictureBox lvl4;
        private System.Windows.Forms.PictureBox lvl3;
        private System.Windows.Forms.PictureBox lvl2;
        private System.Windows.Forms.PictureBox lvl1;
        private System.Windows.Forms.PictureBox gachaBtn;
        private System.Windows.Forms.PictureBox quizBtn;
    }
}