namespace TheGameProject
{
    partial class Level
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
            this.lvlMapPrev = new System.Windows.Forms.PictureBox();
            this.levelNo = new System.Windows.Forms.Label();
            this.lvlDesc = new System.Windows.Forms.Label();
            this.rewardListFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.lvlClearBtn = new System.Windows.Forms.PictureBox();
            this.lvlCancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lvlMapPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvlClearBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // lvlMapPrev
            // 
            this.lvlMapPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lvlMapPrev.Location = new System.Drawing.Point(21, 256);
            this.lvlMapPrev.Name = "lvlMapPrev";
            this.lvlMapPrev.Size = new System.Drawing.Size(50, 74);
            this.lvlMapPrev.TabIndex = 0;
            this.lvlMapPrev.TabStop = false;
            this.lvlMapPrev.Visible = false;
            // 
            // levelNo
            // 
            this.levelNo.AutoSize = true;
            this.levelNo.BackColor = System.Drawing.Color.Transparent;
            this.levelNo.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelNo.Location = new System.Drawing.Point(369, 97);
            this.levelNo.Name = "levelNo";
            this.levelNo.Size = new System.Drawing.Size(74, 86);
            this.levelNo.TabIndex = 1;
            this.levelNo.Text = "0";
            // 
            // lvlDesc
            // 
            this.lvlDesc.AutoSize = true;
            this.lvlDesc.BackColor = System.Drawing.Color.Transparent;
            this.lvlDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlDesc.ForeColor = System.Drawing.SystemColors.Control;
            this.lvlDesc.Location = new System.Drawing.Point(372, 177);
            this.lvlDesc.Name = "lvlDesc";
            this.lvlDesc.Size = new System.Drawing.Size(65, 17);
            this.lvlDesc.TabIndex = 2;
            this.lvlDesc.Text = "Obtained";
            // 
            // rewardListFLP
            // 
            this.rewardListFLP.BackColor = System.Drawing.Color.DimGray;
            this.rewardListFLP.Location = new System.Drawing.Point(227, 198);
            this.rewardListFLP.Name = "rewardListFLP";
            this.rewardListFLP.Size = new System.Drawing.Size(345, 50);
            this.rewardListFLP.TabIndex = 5;
            this.rewardListFLP.Paint += new System.Windows.Forms.PaintEventHandler(this.rewardListFLP_Paint);
            // 
            // lvlClearBtn
            // 
            this.lvlClearBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lvlClearBtn.BackgroundImage = global::TheGameProject.Properties.Resources.ConfirmIcon;
            this.lvlClearBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lvlClearBtn.Location = new System.Drawing.Point(253, 321);
            this.lvlClearBtn.Name = "lvlClearBtn";
            this.lvlClearBtn.Size = new System.Drawing.Size(300, 40);
            this.lvlClearBtn.TabIndex = 6;
            this.lvlClearBtn.TabStop = false;
            this.lvlClearBtn.Click += new System.EventHandler(this.lvlClearBtn_Click);
            // 
            // lvlCancelBtn
            // 
            this.lvlCancelBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lvlCancelBtn.FlatAppearance.BorderSize = 0;
            this.lvlCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lvlCancelBtn.Location = new System.Drawing.Point(21, 336);
            this.lvlCancelBtn.Name = "lvlCancelBtn";
            this.lvlCancelBtn.Size = new System.Drawing.Size(50, 40);
            this.lvlCancelBtn.TabIndex = 4;
            this.lvlCancelBtn.Text = "button2";
            this.lvlCancelBtn.UseVisualStyleBackColor = false;
            this.lvlCancelBtn.Visible = false;
            // 
            // Level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::TheGameProject.Properties.Resources.LevelWood;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.lvlClearBtn);
            this.Controls.Add(this.rewardListFLP);
            this.Controls.Add(this.lvlCancelBtn);
            this.Controls.Add(this.lvlDesc);
            this.Controls.Add(this.levelNo);
            this.Controls.Add(this.lvlMapPrev);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Level";
            this.Text = "Level";
            this.Load += new System.EventHandler(this.Level_Load);
            this.Resize += new System.EventHandler(this.Level_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.lvlMapPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvlClearBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox lvlMapPrev;
        public System.Windows.Forms.Label levelNo;
        private System.Windows.Forms.Label lvlDesc;
        private System.Windows.Forms.FlowLayoutPanel rewardListFLP;
        private System.Windows.Forms.PictureBox lvlClearBtn;
        private System.Windows.Forms.Button lvlCancelBtn;
    }
}