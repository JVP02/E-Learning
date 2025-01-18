namespace TheGameProject
{
    partial class DevSettings
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
            this.backDevBtn = new System.Windows.Forms.Button();
            this.addCharTb = new System.Windows.Forms.TextBox();
            this.addCharBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.addItemTb = new System.Windows.Forms.TextBox();
            this.resetCharBtn = new System.Windows.Forms.Button();
            this.resetItemBtn = new System.Windows.Forms.Button();
            this.debugBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backDevBtn
            // 
            this.backDevBtn.Location = new System.Drawing.Point(12, 12);
            this.backDevBtn.Name = "backDevBtn";
            this.backDevBtn.Size = new System.Drawing.Size(65, 23);
            this.backDevBtn.TabIndex = 0;
            this.backDevBtn.Text = "button1";
            this.backDevBtn.UseVisualStyleBackColor = true;
            // 
            // addCharTb
            // 
            this.addCharTb.Location = new System.Drawing.Point(12, 89);
            this.addCharTb.Name = "addCharTb";
            this.addCharTb.Size = new System.Drawing.Size(117, 20);
            this.addCharTb.TabIndex = 1;
            // 
            // addCharBtn
            // 
            this.addCharBtn.Location = new System.Drawing.Point(135, 89);
            this.addCharBtn.Name = "addCharBtn";
            this.addCharBtn.Size = new System.Drawing.Size(75, 23);
            this.addCharBtn.TabIndex = 2;
            this.addCharBtn.Text = "ADD";
            this.addCharBtn.UseVisualStyleBackColor = true;
            this.addCharBtn.Click += new System.EventHandler(this.addCharBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Add Character";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Add Item";
            // 
            // addItemBtn
            // 
            this.addItemBtn.Location = new System.Drawing.Point(135, 145);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(75, 23);
            this.addItemBtn.TabIndex = 5;
            this.addItemBtn.Text = "ADD";
            this.addItemBtn.UseVisualStyleBackColor = true;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // addItemTb
            // 
            this.addItemTb.Location = new System.Drawing.Point(12, 145);
            this.addItemTb.Name = "addItemTb";
            this.addItemTb.Size = new System.Drawing.Size(117, 20);
            this.addItemTb.TabIndex = 4;
            // 
            // resetCharBtn
            // 
            this.resetCharBtn.Location = new System.Drawing.Point(12, 189);
            this.resetCharBtn.Name = "resetCharBtn";
            this.resetCharBtn.Size = new System.Drawing.Size(117, 23);
            this.resetCharBtn.TabIndex = 7;
            this.resetCharBtn.Text = "Reset CHAR";
            this.resetCharBtn.UseVisualStyleBackColor = true;
            this.resetCharBtn.Click += new System.EventHandler(this.resetCharBtn_Click);
            // 
            // resetItemBtn
            // 
            this.resetItemBtn.Location = new System.Drawing.Point(12, 218);
            this.resetItemBtn.Name = "resetItemBtn";
            this.resetItemBtn.Size = new System.Drawing.Size(117, 23);
            this.resetItemBtn.TabIndex = 8;
            this.resetItemBtn.Text = "Reset ITEM";
            this.resetItemBtn.UseVisualStyleBackColor = true;
            this.resetItemBtn.Click += new System.EventHandler(this.resetItemBtn_Click);
            // 
            // debugBtn
            // 
            this.debugBtn.Location = new System.Drawing.Point(459, 25);
            this.debugBtn.Name = "debugBtn";
            this.debugBtn.Size = new System.Drawing.Size(117, 100);
            this.debugBtn.TabIndex = 9;
            this.debugBtn.Text = "DEBUG";
            this.debugBtn.UseVisualStyleBackColor = true;
            this.debugBtn.Click += new System.EventHandler(this.debugBtn_Click);
            // 
            // DevSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.debugBtn);
            this.Controls.Add(this.resetItemBtn);
            this.Controls.Add(this.resetCharBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addItemBtn);
            this.Controls.Add(this.addItemTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addCharBtn);
            this.Controls.Add(this.addCharTb);
            this.Controls.Add(this.backDevBtn);
            this.Name = "DevSettings";
            this.Text = "DevSettings";
            this.Load += new System.EventHandler(this.DevSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backDevBtn;
        private System.Windows.Forms.TextBox addCharTb;
        private System.Windows.Forms.Button addCharBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addItemBtn;
        private System.Windows.Forms.TextBox addItemTb;
        private System.Windows.Forms.Button resetCharBtn;
        private System.Windows.Forms.Button resetItemBtn;
        private System.Windows.Forms.Button debugBtn;
    }
}