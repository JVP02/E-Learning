using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TheGameProject
{
    public partial class Level : Form
    {
        private Rectangle lvlMapPrevRec;
        private Rectangle levelNoRec;
        private Rectangle lvlDescRec;
        private Rectangle lvlStartBtnRec;
        private Rectangle lvlCancelBtnRec, rewardListFLPRec;
        private Rectangle originalFormSize;

        string[] iImg = SharedArray.iImg;
        string[] coinImg = SharedArray.coinImg;
        int[] coinVal = SharedArray.coinVal;
        string[] gemImg = SharedArray.gemImg;
        int[] gemVal = SharedArray.gemVal;



        DBConnection Con = new DBConnection();

        public int selectedLevel { get; set; } // Property to hold the level
        public Level()
        {
            InitializeComponent();

        }

        private void Level_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            //add any components here -jvp
            lvlMapPrevRec = new Rectangle(lvlMapPrev.Location.X, lvlMapPrev.Location.Y, lvlMapPrev.Width, lvlMapPrev.Height);
            levelNoRec = new Rectangle(levelNo.Location.X, levelNo.Location.Y, levelNo.Width, levelNo.Height);
            lvlDescRec = new Rectangle(lvlDesc.Location.X, lvlDesc.Location.Y, lvlDesc.Width, lvlDesc.Height);
            lvlStartBtnRec = new Rectangle(lvlClearBtn.Location.X, lvlClearBtn.Location.Y, lvlClearBtn.Width, lvlClearBtn.Height);
            lvlCancelBtnRec = new Rectangle(lvlCancelBtn.Location.X, lvlCancelBtn.Location.Y, lvlCancelBtn.Width, lvlCancelBtn.Height);
            rewardListFLPRec = new Rectangle(rewardListFLP.Location.X, rewardListFLP.Location.Y, rewardListFLP.Width, rewardListFLP.Height);

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Level_Resize(object sender, EventArgs e)
        {
            //(rectangleName, componentName) -jvp
            resizeControl(lvlMapPrevRec, lvlMapPrev);
            resizeControl(levelNoRec, levelNo);
            resizeControl(lvlDescRec, lvlDesc);
            resizeControl(lvlStartBtnRec, lvlClearBtn);
            resizeControl(lvlCancelBtnRec, lvlCancelBtn);
            resizeControl(rewardListFLPRec, rewardListFLP);

        }

        private void lvlClearBtn_Click(object sender, EventArgs e)
        {
            // Adjust the level index (if levels start at 1, subtract 1)
            int levelIndex = selectedLevel - 1;

            // Update the database with the current level's data
            UpdateCurrencyAndItems(levelIndex);

            try
            {
                Con.Connection();
                Con.Con.Open();

                // Query to get the current lvlClear value
                string selectQuery = "SELECT lvlClear FROM LevelTbl WHERE lvlNo = 1";
                SqlCommand selectCmd = new SqlCommand(selectQuery, Con.Con);
                int currentLvlClear = Convert.ToInt32(selectCmd.ExecuteScalar());

                // Get the current level from the form
                int currentLevel = selectedLevel; // Use the selectedLevel variable

                if (currentLevel >= currentLvlClear)
                {
                    // Increment the level if the condition is met
                    int newLvlClear = currentLevel + 1;

                    // Update the database
                    string updateQuery = "UPDATE LevelTbl SET lvlClear = @lvlClear WHERE lvlNo = 1";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, Con.Con);
                    updateCmd.Parameters.AddWithValue("@lvlClear", newLvlClear);
                    updateCmd.ExecuteNonQuery();

                    //MessageBox.Show($"Level cleared! lvlClear updated to {newLvlClear}.");
                }
                else
                {
                    //MessageBox.Show("Current level is already cleared or higher.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (Con.Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Con.Close();
                }
                Map map = new Map();
                map.Show();
                this.Hide();
            }
        }


        // Public method to set the level number
        public void SetLevelNumber(int level)
        {
            selectedLevel = level;
            levelNo.Text = $"{selectedLevel}"; // Display the level in the label

            // Populate the rewards based on the level
            PopulateRewards(selectedLevel - 1); // Adjusting index since levels might start at 1
        }


        // Rewards ===========================================================================================================================
        private void PopulateRewards(int levelIndex)
        {
            // Clear any existing controls in the FlowLayoutPanel
            rewardListFLP.Controls.Clear();

            // Ensure the level index is within bounds
            if (levelIndex < 0 || levelIndex >= iImg.Length)
            {
                MessageBox.Show("Invalid level index for rewards.");
                return;
            }

            // Create PictureBox for item image
            PictureBox itemPictureBox = new PictureBox
            {
                Image = (Image)Properties.Resources.ResourceManager.GetObject(iImg[levelIndex]),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(75, 75)
            };
            rewardListFLP.Controls.Add(itemPictureBox);

            // Create PictureBox for coin image
            PictureBox coinPictureBox = new PictureBox
            {
                Image = (Image)Properties.Resources.ResourceManager.GetObject(coinImg[levelIndex]),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(75,75)
            };
            rewardListFLP.Controls.Add(coinPictureBox);

            // Add label for coin value below the coin image
            //Label coinValueLabel = new Label
            //{
            //    Text = coinVal[levelIndex].ToString(),
            //    AutoSize = true,
            //    TextAlign = ContentAlignment.MiddleCenter
            //};
            //rewardListFLP.Controls.Add(coinValueLabel);

            // Create PictureBox for gem image
            PictureBox gemPictureBox = new PictureBox
            {
                Image = (Image)Properties.Resources.ResourceManager.GetObject(gemImg[levelIndex]),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(75,75)
            };
            rewardListFLP.Controls.Add(gemPictureBox);

            // Add label for gem value below the gem image
            //Label gemValueLabel = new Label
            //{
            //    Text = gemVal[levelIndex].ToString(),
            //    AutoSize = true,
            //    TextAlign = ContentAlignment.MiddleCenter
            //};
            //rewardListFLP.Controls.Add(gemValueLabel);
        }

        private void rewardListFLP_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateCurrencyAndItems(int levelIndex)
        {
            if (levelIndex < 0 || levelIndex >= iImg.Length)
            {
                MessageBox.Show("Invalid level index for database update.");
                return;
            }

            try
            {
                Con.Connection();
                Con.Con.Open();

                // Update CurrencyTbl by summing existing values
                string updateCurrencyQuery = @"
                UPDATE CurrencyTbl
                SET 
                    coin = coin + @coinValue,
                    gem = gem + @gemValue
                WHERE CurrID = 1"; // Assuming a single row; update this condition as needed.

                using (SqlCommand cmd = new SqlCommand(updateCurrencyQuery, Con.Con))
                {
                    cmd.Parameters.AddWithValue("@coinValue", coinVal[levelIndex]);
                    cmd.Parameters.AddWithValue("@gemValue", gemVal[levelIndex]);
                    cmd.ExecuteNonQuery();
                }

                // Check if the item already exists in ItemTbl
                string checkItemQuery = @"
                SELECT itemAm 
                FROM ItemTbl
                WHERE itemNo = @itemIndex";

                object result;
                using (SqlCommand cmd = new SqlCommand(checkItemQuery, Con.Con))
                {
                    cmd.Parameters.AddWithValue("@itemIndex", levelIndex);
                    result = cmd.ExecuteScalar();
                }

                if (result != null && result != DBNull.Value)
                {
                    // Item exists, increment the itemAm column
                    string updateItemQuery = @"
                    UPDATE ItemTbl
                    SET itemAm = itemAm + 1
                    WHERE itemNo = @itemIndex";

                    using (SqlCommand cmd = new SqlCommand(updateItemQuery, Con.Con))
                    {
                        cmd.Parameters.AddWithValue("@itemIndex", levelIndex);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Item does not exist, insert a new row
                    string insertItemQuery = @"
                    INSERT INTO ItemTbl (itemNo, itemAm)
                    VALUES (@itemIndex, 1)";

                    using (SqlCommand cmd = new SqlCommand(insertItemQuery, Con.Con))
                    {
                        cmd.Parameters.AddWithValue("@itemIndex", levelIndex);
                        cmd.ExecuteNonQuery();
                    }
                }

                //MessageBox.Show("Currency updated and item processed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
