namespace TheGameProject
{
    partial class Inventory2
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
            this.itemListFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.charListInvFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.invUnitImg = new System.Windows.Forms.PictureBox();
            this.invUnitItem = new System.Windows.Forms.PictureBox();
            this.itemDesc = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.Label();
            this.itemPrev = new System.Windows.Forms.PictureBox();
            this.equipItemBtn = new System.Windows.Forms.PictureBox();
            this.itemIcon = new System.Windows.Forms.PictureBox();
            this.skillDesc = new System.Windows.Forms.Label();
            this.backInvBtn = new System.Windows.Forms.PictureBox();
            this.itemHptxt = new System.Windows.Forms.Label();
            this.itemAtktxt = new System.Windows.Forms.Label();
            this.itemHealtxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.invUnitImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invUnitItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipItemBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backInvBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // itemListFLP
            // 
            this.itemListFLP.BackColor = System.Drawing.Color.Transparent;
            this.itemListFLP.Location = new System.Drawing.Point(110, 243);
            this.itemListFLP.Name = "itemListFLP";
            this.itemListFLP.Size = new System.Drawing.Size(419, 155);
            this.itemListFLP.TabIndex = 0;
            // 
            // charListInvFLP
            // 
            this.charListInvFLP.AutoScroll = true;
            this.charListInvFLP.BackColor = System.Drawing.Color.Transparent;
            this.charListInvFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.charListInvFLP.Location = new System.Drawing.Point(18, 47);
            this.charListInvFLP.Name = "charListInvFLP";
            this.charListInvFLP.Size = new System.Drawing.Size(50, 382);
            this.charListInvFLP.TabIndex = 1;
            // 
            // invUnitImg
            // 
            this.invUnitImg.BackColor = System.Drawing.Color.Transparent;
            this.invUnitImg.Location = new System.Drawing.Point(110, 64);
            this.invUnitImg.Name = "invUnitImg";
            this.invUnitImg.Size = new System.Drawing.Size(92, 145);
            this.invUnitImg.TabIndex = 2;
            this.invUnitImg.TabStop = false;
            // 
            // invUnitItem
            // 
            this.invUnitItem.BackColor = System.Drawing.Color.Transparent;
            this.invUnitItem.Location = new System.Drawing.Point(208, 149);
            this.invUnitItem.Name = "invUnitItem";
            this.invUnitItem.Size = new System.Drawing.Size(125, 75);
            this.invUnitItem.TabIndex = 3;
            this.invUnitItem.TabStop = false;
            // 
            // itemDesc
            // 
            this.itemDesc.AutoSize = true;
            this.itemDesc.BackColor = System.Drawing.Color.Transparent;
            this.itemDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDesc.Location = new System.Drawing.Point(593, 272);
            this.itemDesc.MaximumSize = new System.Drawing.Size(300, 0);
            this.itemDesc.Name = "itemDesc";
            this.itemDesc.Size = new System.Drawing.Size(24, 21);
            this.itemDesc.TabIndex = 85;
            this.itemDesc.Text = "[ ]";
            // 
            // itemName
            // 
            this.itemName.AutoSize = true;
            this.itemName.BackColor = System.Drawing.Color.Transparent;
            this.itemName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.itemName.Location = new System.Drawing.Point(591, 77);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(44, 21);
            this.itemName.TabIndex = 84;
            this.itemName.Text = "Item";
            // 
            // itemPrev
            // 
            this.itemPrev.BackColor = System.Drawing.Color.Transparent;
            this.itemPrev.Location = new System.Drawing.Point(724, 50);
            this.itemPrev.Name = "itemPrev";
            this.itemPrev.Size = new System.Drawing.Size(62, 65);
            this.itemPrev.TabIndex = 86;
            this.itemPrev.TabStop = false;
            // 
            // equipItemBtn
            // 
            this.equipItemBtn.BackColor = System.Drawing.Color.Transparent;
            this.equipItemBtn.Location = new System.Drawing.Point(443, 421);
            this.equipItemBtn.Name = "equipItemBtn";
            this.equipItemBtn.Size = new System.Drawing.Size(94, 25);
            this.equipItemBtn.TabIndex = 88;
            this.equipItemBtn.TabStop = false;
            this.equipItemBtn.Click += new System.EventHandler(this.equipItemBtn_Click);
            // 
            // itemIcon
            // 
            this.itemIcon.BackColor = System.Drawing.Color.Transparent;
            this.itemIcon.Location = new System.Drawing.Point(230, 64);
            this.itemIcon.Name = "itemIcon";
            this.itemIcon.Size = new System.Drawing.Size(78, 73);
            this.itemIcon.TabIndex = 90;
            this.itemIcon.TabStop = false;
            this.itemIcon.DoubleClick += new System.EventHandler(this.itemIcon_DoubleClick);
            // 
            // skillDesc
            // 
            this.skillDesc.AutoSize = true;
            this.skillDesc.BackColor = System.Drawing.Color.Transparent;
            this.skillDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skillDesc.Location = new System.Drawing.Point(340, 64);
            this.skillDesc.MaximumSize = new System.Drawing.Size(320, 0);
            this.skillDesc.Name = "skillDesc";
            this.skillDesc.Size = new System.Drawing.Size(24, 21);
            this.skillDesc.TabIndex = 91;
            this.skillDesc.Text = "[ ]";
            // 
            // backInvBtn
            // 
            this.backInvBtn.BackColor = System.Drawing.Color.Transparent;
            this.backInvBtn.Location = new System.Drawing.Point(2, 2);
            this.backInvBtn.Name = "backInvBtn";
            this.backInvBtn.Size = new System.Drawing.Size(25, 25);
            this.backInvBtn.TabIndex = 92;
            this.backInvBtn.TabStop = false;
            this.backInvBtn.Click += new System.EventHandler(this.backInvBtn_Click);
            // 
            // itemHptxt
            // 
            this.itemHptxt.AutoSize = true;
            this.itemHptxt.BackColor = System.Drawing.Color.Transparent;
            this.itemHptxt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemHptxt.Location = new System.Drawing.Point(591, 135);
            this.itemHptxt.MaximumSize = new System.Drawing.Size(250, 0);
            this.itemHptxt.Name = "itemHptxt";
            this.itemHptxt.Size = new System.Drawing.Size(29, 25);
            this.itemHptxt.TabIndex = 93;
            this.itemHptxt.Text = "[ ]";
            // 
            // itemAtktxt
            // 
            this.itemAtktxt.AutoSize = true;
            this.itemAtktxt.BackColor = System.Drawing.Color.Transparent;
            this.itemAtktxt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemAtktxt.Location = new System.Drawing.Point(591, 168);
            this.itemAtktxt.MaximumSize = new System.Drawing.Size(250, 0);
            this.itemAtktxt.Name = "itemAtktxt";
            this.itemAtktxt.Size = new System.Drawing.Size(29, 25);
            this.itemAtktxt.TabIndex = 94;
            this.itemAtktxt.Text = "[ ]";
            // 
            // itemHealtxt
            // 
            this.itemHealtxt.AutoSize = true;
            this.itemHealtxt.BackColor = System.Drawing.Color.Transparent;
            this.itemHealtxt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemHealtxt.Location = new System.Drawing.Point(591, 199);
            this.itemHealtxt.MaximumSize = new System.Drawing.Size(250, 0);
            this.itemHealtxt.Name = "itemHealtxt";
            this.itemHealtxt.Size = new System.Drawing.Size(29, 25);
            this.itemHealtxt.TabIndex = 95;
            this.itemHealtxt.Text = "[ ]";
            // 
            // Inventory2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheGameProject.Properties.Resources.invWood;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.itemHealtxt);
            this.Controls.Add(this.itemAtktxt);
            this.Controls.Add(this.itemHptxt);
            this.Controls.Add(this.charListInvFLP);
            this.Controls.Add(this.backInvBtn);
            this.Controls.Add(this.skillDesc);
            this.Controls.Add(this.itemIcon);
            this.Controls.Add(this.equipItemBtn);
            this.Controls.Add(this.itemPrev);
            this.Controls.Add(this.itemDesc);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.invUnitItem);
            this.Controls.Add(this.invUnitImg);
            this.Controls.Add(this.itemListFLP);
            this.DoubleBuffered = true;
            this.Name = "Inventory2";
            this.Text = "Inventory2";
            this.Load += new System.EventHandler(this.Inventory2_Load);
            this.Resize += new System.EventHandler(this.Inventory2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.invUnitImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invUnitItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipItemBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backInvBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel itemListFLP;
        private System.Windows.Forms.FlowLayoutPanel charListInvFLP;
        private System.Windows.Forms.PictureBox invUnitImg;
        private System.Windows.Forms.PictureBox invUnitItem;
        public System.Windows.Forms.Label itemDesc;
        private System.Windows.Forms.Label itemName;
        private System.Windows.Forms.PictureBox itemPrev;
        private System.Windows.Forms.PictureBox equipItemBtn;
        private System.Windows.Forms.PictureBox itemIcon;
        public System.Windows.Forms.Label skillDesc;
        private System.Windows.Forms.PictureBox backInvBtn;
        public System.Windows.Forms.Label itemHptxt;
        public System.Windows.Forms.Label itemAtktxt;
        public System.Windows.Forms.Label itemHealtxt;
    }
}