namespace TheGameProject
{
    partial class Loading
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
            this.loadBack = new System.Windows.Forms.Panel();
            this.loadbar = new System.Windows.Forms.Panel();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.loadIcon = new System.Windows.Forms.PictureBox();
            this.loadBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // loadBack
            // 
            this.loadBack.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.loadBack.Controls.Add(this.loadbar);
            this.loadBack.Location = new System.Drawing.Point(300, 288);
            this.loadBack.Name = "loadBack";
            this.loadBack.Size = new System.Drawing.Size(200, 10);
            this.loadBack.TabIndex = 0;
            // 
            // loadbar
            // 
            this.loadbar.BackColor = System.Drawing.Color.BlueViolet;
            this.loadbar.Location = new System.Drawing.Point(3, 2);
            this.loadbar.Name = "loadbar";
            this.loadbar.Size = new System.Drawing.Size(10, 5);
            this.loadbar.TabIndex = 1;
            // 
            // loadingTimer
            // 
            this.loadingTimer.Enabled = true;
            this.loadingTimer.Interval = 10;
            this.loadingTimer.Tick += new System.EventHandler(this.loadingTimer_Tick);
            // 
            // loadIcon
            // 
            this.loadIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadIcon.Image = global::TheGameProject.Properties.Resources.Loading;
            this.loadIcon.Location = new System.Drawing.Point(2, 2);
            this.loadIcon.Name = "loadIcon";
            this.loadIcon.Size = new System.Drawing.Size(797, 452);
            this.loadIcon.TabIndex = 1;
            this.loadIcon.TabStop = false;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheGameProject.Properties.Resources.Loading;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadIcon);
            this.Controls.Add(this.loadBack);
            this.Name = "Loading";
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.Loading_Load);
            this.Resize += new System.EventHandler(this.Loading_Resize);
            this.loadBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loadBack;
        private System.Windows.Forms.Panel loadbar;
        private System.Windows.Forms.Timer loadingTimer;
        private System.Windows.Forms.PictureBox loadIcon;
    }
}