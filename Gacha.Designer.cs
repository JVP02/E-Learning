namespace TheGameProject
{
    partial class Gacha
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
            this.backBtn = new System.Windows.Forms.Button();
            this.ticketAmount = new System.Windows.Forms.Label();
            this.pullResultPan = new System.Windows.Forms.Panel();
            this.resultDoneBtn = new System.Windows.Forms.PictureBox();
            this.rewardtxt = new System.Windows.Forms.Label();
            this.pullRewardFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.shopBtn = new System.Windows.Forms.PictureBox();
            this.ticketIcon = new System.Windows.Forms.PictureBox();
            this.itemBanner = new System.Windows.Forms.PictureBox();
            this.charBanner = new System.Windows.Forms.PictureBox();
            this.pull1Btn = new System.Windows.Forms.PictureBox();
            this.pull10Btn = new System.Windows.Forms.PictureBox();
            this.mainBanner = new System.Windows.Forms.PictureBox();
            this.pullAnim = new System.Windows.Forms.PictureBox();
            this.pullResultPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDoneBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pull1Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pull10Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pullAnim)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Red;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.ForeColor = System.Drawing.Color.Crimson;
            this.backBtn.Location = new System.Drawing.Point(2, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(25, 25);
            this.backBtn.TabIndex = 5;
            this.backBtn.UseVisualStyleBackColor = false;
            // 
            // ticketAmount
            // 
            this.ticketAmount.AutoSize = true;
            this.ticketAmount.Location = new System.Drawing.Point(723, 23);
            this.ticketAmount.Name = "ticketAmount";
            this.ticketAmount.Size = new System.Drawing.Size(16, 13);
            this.ticketAmount.TabIndex = 6;
            this.ticketAmount.Text = "[ ]";
            // 
            // pullResultPan
            // 
            this.pullResultPan.Controls.Add(this.resultDoneBtn);
            this.pullResultPan.Controls.Add(this.rewardtxt);
            this.pullResultPan.Controls.Add(this.pullRewardFLP);
            this.pullResultPan.Location = new System.Drawing.Point(2, 0);
            this.pullResultPan.Name = "pullResultPan";
            this.pullResultPan.Size = new System.Drawing.Size(800, 449);
            this.pullResultPan.TabIndex = 9;
            // 
            // resultDoneBtn
            // 
            this.resultDoneBtn.Location = new System.Drawing.Point(339, 352);
            this.resultDoneBtn.Name = "resultDoneBtn";
            this.resultDoneBtn.Size = new System.Drawing.Size(100, 25);
            this.resultDoneBtn.TabIndex = 2;
            this.resultDoneBtn.TabStop = false;
            // 
            // rewardtxt
            // 
            this.rewardtxt.AutoSize = true;
            this.rewardtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rewardtxt.Location = new System.Drawing.Point(355, 56);
            this.rewardtxt.Name = "rewardtxt";
            this.rewardtxt.Size = new System.Drawing.Size(91, 25);
            this.rewardtxt.TabIndex = 1;
            this.rewardtxt.Text = "Obtained";
            // 
            // pullRewardFLP
            // 
            this.pullRewardFLP.Location = new System.Drawing.Point(101, 100);
            this.pullRewardFLP.Name = "pullRewardFLP";
            this.pullRewardFLP.Size = new System.Drawing.Size(600, 150);
            this.pullRewardFLP.TabIndex = 0;
            // 
            // shopBtn
            // 
            this.shopBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.shopBtn.Location = new System.Drawing.Point(11, 388);
            this.shopBtn.Name = "shopBtn";
            this.shopBtn.Size = new System.Drawing.Size(50, 50);
            this.shopBtn.TabIndex = 8;
            this.shopBtn.TabStop = false;
            // 
            // ticketIcon
            // 
            this.ticketIcon.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ticketIcon.Location = new System.Drawing.Point(703, 21);
            this.ticketIcon.Name = "ticketIcon";
            this.ticketIcon.Size = new System.Drawing.Size(20, 20);
            this.ticketIcon.TabIndex = 7;
            this.ticketIcon.TabStop = false;
            // 
            // itemBanner
            // 
            this.itemBanner.BackColor = System.Drawing.Color.RosyBrown;
            this.itemBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.itemBanner.Location = new System.Drawing.Point(11, 128);
            this.itemBanner.Name = "itemBanner";
            this.itemBanner.Size = new System.Drawing.Size(100, 60);
            this.itemBanner.TabIndex = 4;
            this.itemBanner.TabStop = false;
            this.itemBanner.Click += new System.EventHandler(this.itemBanner_Click);
            // 
            // charBanner
            // 
            this.charBanner.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.charBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.charBanner.Location = new System.Drawing.Point(11, 62);
            this.charBanner.Name = "charBanner";
            this.charBanner.Size = new System.Drawing.Size(100, 60);
            this.charBanner.TabIndex = 3;
            this.charBanner.TabStop = false;
            this.charBanner.Click += new System.EventHandler(this.charBanner_Click);
            // 
            // pull1Btn
            // 
            this.pull1Btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pull1Btn.Location = new System.Drawing.Point(469, 395);
            this.pull1Btn.Name = "pull1Btn";
            this.pull1Btn.Size = new System.Drawing.Size(150, 30);
            this.pull1Btn.TabIndex = 2;
            this.pull1Btn.TabStop = false;
            this.pull1Btn.Click += new System.EventHandler(this.pull1Btn_Click);
            // 
            // pull10Btn
            // 
            this.pull10Btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pull10Btn.Location = new System.Drawing.Point(638, 395);
            this.pull10Btn.Name = "pull10Btn";
            this.pull10Btn.Size = new System.Drawing.Size(150, 30);
            this.pull10Btn.TabIndex = 1;
            this.pull10Btn.TabStop = false;
            // 
            // mainBanner
            // 
            this.mainBanner.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.mainBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainBanner.Location = new System.Drawing.Point(117, 62);
            this.mainBanner.Name = "mainBanner";
            this.mainBanner.Size = new System.Drawing.Size(650, 300);
            this.mainBanner.TabIndex = 0;
            this.mainBanner.TabStop = false;
            // 
            // pullAnim
            // 
            this.pullAnim.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pullAnim.Location = new System.Drawing.Point(2, 0);
            this.pullAnim.Name = "pullAnim";
            this.pullAnim.Size = new System.Drawing.Size(797, 449);
            this.pullAnim.TabIndex = 10;
            this.pullAnim.TabStop = false;
            // 
            // Gacha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 450);
            this.Controls.Add(this.shopBtn);
            this.Controls.Add(this.ticketIcon);
            this.Controls.Add(this.ticketAmount);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.itemBanner);
            this.Controls.Add(this.charBanner);
            this.Controls.Add(this.pull1Btn);
            this.Controls.Add(this.pull10Btn);
            this.Controls.Add(this.mainBanner);
            this.Controls.Add(this.pullAnim);
            this.Controls.Add(this.pullResultPan);
            this.Name = "Gacha";
            this.Text = "Gacha";
            this.Load += new System.EventHandler(this.Gacha_Load);
            this.Resize += new System.EventHandler(this.Gacha_Resize);
            this.pullResultPan.ResumeLayout(false);
            this.pullResultPan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDoneBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pull1Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pull10Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pullAnim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainBanner;
        private System.Windows.Forms.PictureBox pull10Btn;
        private System.Windows.Forms.PictureBox pull1Btn;
        private System.Windows.Forms.PictureBox charBanner;
        private System.Windows.Forms.PictureBox itemBanner;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label ticketAmount;
        private System.Windows.Forms.PictureBox ticketIcon;
        private System.Windows.Forms.PictureBox shopBtn;
        private System.Windows.Forms.Panel pullResultPan;
        private System.Windows.Forms.Label rewardtxt;
        private System.Windows.Forms.FlowLayoutPanel pullRewardFLP;
        private System.Windows.Forms.PictureBox resultDoneBtn;
        private System.Windows.Forms.PictureBox pullAnim;
    }
}