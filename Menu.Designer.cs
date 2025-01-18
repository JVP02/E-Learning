namespace TheGameProject
{
    partial class Menu
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
            this.devMenuBtn = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.PictureBox();
            this.exitBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.devMenuBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // devMenuBtn
            // 
            this.devMenuBtn.BackColor = System.Drawing.Color.Transparent;
            this.devMenuBtn.Location = new System.Drawing.Point(772, 413);
            this.devMenuBtn.Name = "devMenuBtn";
            this.devMenuBtn.Size = new System.Drawing.Size(25, 25);
            this.devMenuBtn.TabIndex = 4;
            this.devMenuBtn.TabStop = false;
            this.devMenuBtn.Click += new System.EventHandler(this.devMenuPB_Click);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Transparent;
            this.startBtn.Location = new System.Drawing.Point(259, 332);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(300, 75);
            this.startBtn.TabIndex = 5;
            this.startBtn.TabStop = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.Location = new System.Drawing.Point(358, 408);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(100, 30);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.TabStop = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::TheGameProject.Properties.Resources.SplashArt1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.devMenuBtn);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.devMenuBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox devMenuBtn;
        private System.Windows.Forms.PictureBox startBtn;
        private System.Windows.Forms.PictureBox exitBtn;
    }
}

