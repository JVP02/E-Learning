namespace TheGameProject
{
    partial class Collection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Collection));
            this.dataList = new System.Windows.Forms.FlowLayoutPanel();
            this.infoPan = new System.Windows.Forms.Panel();
            this.pageNo = new System.Windows.Forms.Label();
            this.collDesc2Lbl = new System.Windows.Forms.Label();
            this.collDesc1Lbl = new System.Windows.Forms.Label();
            this.collNameLbl = new System.Windows.Forms.Label();
            this.collImg2Pb = new System.Windows.Forms.PictureBox();
            this.collImg1Pb = new System.Windows.Forms.PictureBox();
            this.enemyColl = new System.Windows.Forms.PictureBox();
            this.itemColl = new System.Windows.Forms.PictureBox();
            this.backMapBtn = new System.Windows.Forms.PictureBox();
            this.infoPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collImg2Pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collImg1Pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyColl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemColl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backMapBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // dataList
            // 
            this.dataList.BackColor = System.Drawing.Color.Transparent;
            this.dataList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.dataList.Location = new System.Drawing.Point(149, 47);
            this.dataList.Name = "dataList";
            this.dataList.Size = new System.Drawing.Size(50, 382);
            this.dataList.TabIndex = 18;
            // 
            // infoPan
            // 
            this.infoPan.AutoScroll = true;
            this.infoPan.BackColor = System.Drawing.Color.Transparent;
            this.infoPan.BackgroundImage = global::TheGameProject.Properties.Resources.NewspaperBG2;
            this.infoPan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoPan.Controls.Add(this.pageNo);
            this.infoPan.Controls.Add(this.collDesc2Lbl);
            this.infoPan.Controls.Add(this.collDesc1Lbl);
            this.infoPan.Controls.Add(this.collNameLbl);
            this.infoPan.Controls.Add(this.collImg2Pb);
            this.infoPan.Controls.Add(this.collImg1Pb);
            this.infoPan.Location = new System.Drawing.Point(229, 47);
            this.infoPan.Name = "infoPan";
            this.infoPan.Size = new System.Drawing.Size(541, 382);
            this.infoPan.TabIndex = 19;
            // 
            // pageNo
            // 
            this.pageNo.AutoSize = true;
            this.pageNo.Location = new System.Drawing.Point(480, 822);
            this.pageNo.Name = "pageNo";
            this.pageNo.Size = new System.Drawing.Size(41, 13);
            this.pageNo.TabIndex = 5;
            this.pageNo.Text = "Page 1";
            // 
            // collDesc2Lbl
            // 
            this.collDesc2Lbl.AutoSize = true;
            this.collDesc2Lbl.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.collDesc2Lbl.Location = new System.Drawing.Point(277, 512);
            this.collDesc2Lbl.MaximumSize = new System.Drawing.Size(340, 0);
            this.collDesc2Lbl.Name = "collDesc2Lbl";
            this.collDesc2Lbl.Size = new System.Drawing.Size(339, 551);
            this.collDesc2Lbl.TabIndex = 4;
            this.collDesc2Lbl.Text = resources.GetString("collDesc2Lbl.Text");
            // 
            // collDesc1Lbl
            // 
            this.collDesc1Lbl.AutoSize = true;
            this.collDesc1Lbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collDesc1Lbl.Location = new System.Drawing.Point(54, 343);
            this.collDesc1Lbl.MaximumSize = new System.Drawing.Size(700, 0);
            this.collDesc1Lbl.Name = "collDesc1Lbl";
            this.collDesc1Lbl.Size = new System.Drawing.Size(23, 19);
            this.collDesc1Lbl.TabIndex = 3;
            this.collDesc1Lbl.Text = "[ ]";
            // 
            // collNameLbl
            // 
            this.collNameLbl.AutoSize = true;
            this.collNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.collNameLbl.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collNameLbl.Location = new System.Drawing.Point(51, 287);
            this.collNameLbl.MaximumSize = new System.Drawing.Size(486, 0);
            this.collNameLbl.Name = "collNameLbl";
            this.collNameLbl.Size = new System.Drawing.Size(113, 42);
            this.collNameLbl.TabIndex = 2;
            this.collNameLbl.Text = "label1";
            // 
            // collImg2Pb
            // 
            this.collImg2Pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.collImg2Pb.Location = new System.Drawing.Point(48, 512);
            this.collImg2Pb.Name = "collImg2Pb";
            this.collImg2Pb.Size = new System.Drawing.Size(214, 240);
            this.collImg2Pb.TabIndex = 1;
            this.collImg2Pb.TabStop = false;
            this.collImg2Pb.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // collImg1Pb
            // 
            this.collImg1Pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.collImg1Pb.Location = new System.Drawing.Point(51, 138);
            this.collImg1Pb.Name = "collImg1Pb";
            this.collImg1Pb.Size = new System.Drawing.Size(428, 136);
            this.collImg1Pb.TabIndex = 0;
            this.collImg1Pb.TabStop = false;
            this.collImg1Pb.Click += new System.EventHandler(this.collImg1Pb_Click);
            // 
            // enemyColl
            // 
            this.enemyColl.BackColor = System.Drawing.Color.RosyBrown;
            this.enemyColl.BackgroundImage = global::TheGameProject.Properties.Resources.CreatureSelectCollection;
            this.enemyColl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enemyColl.Location = new System.Drawing.Point(13, 171);
            this.enemyColl.Name = "enemyColl";
            this.enemyColl.Size = new System.Drawing.Size(113, 88);
            this.enemyColl.TabIndex = 17;
            this.enemyColl.TabStop = false;
            this.enemyColl.Click += new System.EventHandler(this.enemyColl_Click);
            // 
            // itemColl
            // 
            this.itemColl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.itemColl.BackgroundImage = global::TheGameProject.Properties.Resources.ItemSelectCollection;
            this.itemColl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.itemColl.Location = new System.Drawing.Point(13, 47);
            this.itemColl.Name = "itemColl";
            this.itemColl.Size = new System.Drawing.Size(113, 88);
            this.itemColl.TabIndex = 16;
            this.itemColl.TabStop = false;
            this.itemColl.Click += new System.EventHandler(this.itemColl_Click);
            // 
            // backMapBtn
            // 
            this.backMapBtn.BackColor = System.Drawing.Color.Transparent;
            this.backMapBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.backMapBtn.Location = new System.Drawing.Point(1, 0);
            this.backMapBtn.Name = "backMapBtn";
            this.backMapBtn.Size = new System.Drawing.Size(25, 25);
            this.backMapBtn.TabIndex = 15;
            this.backMapBtn.TabStop = false;
            this.backMapBtn.Click += new System.EventHandler(this.backMapBtn_Click);
            // 
            // Collection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheGameProject.Properties.Resources.CollWood;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.infoPan);
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.enemyColl);
            this.Controls.Add(this.itemColl);
            this.Controls.Add(this.backMapBtn);
            this.DoubleBuffered = true;
            this.Name = "Collection";
            this.Text = "Collection";
            this.Load += new System.EventHandler(this.Collection_Load);
            this.Resize += new System.EventHandler(this.Collection_Resize);
            this.infoPan.ResumeLayout(false);
            this.infoPan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collImg2Pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collImg1Pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyColl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemColl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backMapBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backMapBtn;
        private System.Windows.Forms.PictureBox enemyColl;
        private System.Windows.Forms.PictureBox itemColl;
        private System.Windows.Forms.FlowLayoutPanel dataList;
        private System.Windows.Forms.Panel infoPan;
        private System.Windows.Forms.Label collNameLbl;
        private System.Windows.Forms.PictureBox collImg2Pb;
        private System.Windows.Forms.PictureBox collImg1Pb;
        private System.Windows.Forms.Label collDesc2Lbl;
        private System.Windows.Forms.Label collDesc1Lbl;
        private System.Windows.Forms.Label pageNo;
    }
}