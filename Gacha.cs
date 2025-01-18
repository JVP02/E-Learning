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

namespace TheGameProject
{
    public partial class Gacha : Form
    {
        private Rectangle originalFormSize, backBtnRec, charBannerRec, itemBannerRec, mainBannerRec, ticketIconRec, ticketAmountRec;
        private Rectangle shopBtnRec, pull1BtnRec, pull10BtnRec, pullResultPanRec, rewardtxtRec, pullRewardFLPRec, resultDoneBtnRec, pullAnimRec;

        string[] coinImg = { "g100", "g200", "g300", "g400", "g500" };
        int[] coinVal = { 100, 200, 300, 400, 500 };
        double[] coinRate = { 0.60, 0.50, 0.40, 0.30, 0.20 };

        string[] charImg = { "char1", "char2", "char3", "char4", "char5" };
        double[] charRate = { 0.10, 0.10, 0.10, 0.10, 0.10 };
        string[] itemImg = { "item1", "item2", "item3", "itme4", "item5" };
        double[] itemRate = { 0.10, 0.10, 0.10, 0.10, 0.10 };

        // Timer instance
        private Timer pullTimer;
        DBConnection Con = new DBConnection();
        public Gacha()
        {
            InitializeComponent();
        }

        private void Gacha_Load(object sender, EventArgs e)
        {
            InitializeRectangles();
            // Initialize the timer
            pullTimer = new Timer();
            pullTimer.Interval = 5000; // 5 seconds
            pullTimer.Tick += PullTimer_Tick;

            // Initially hide pullResultPan
            pullResultPan.Visible = false;
            // Set the initial image in mainBanner
            mainBanner.Image = Properties.Resources.CBMain;

            // Set the images for charBanner and itemBanner
            charBanner.SizeMode = PictureBoxSizeMode.StretchImage;
            itemBanner.SizeMode = PictureBoxSizeMode.StretchImage;
            mainBanner.SizeMode = PictureBoxSizeMode.StretchImage;
            charBanner.Image = Properties.Resources.CBMini;
            itemBanner.Image = Properties.Resources.IBMini;
        }
        private void InitializeRectangles()
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            //add any components here -jvp
            backBtnRec = new Rectangle(backBtn.Location.X, backBtn.Location.Y, backBtn.Width, backBtn.Height);
            charBannerRec = new Rectangle(charBanner.Location.X, charBanner.Location.Y, charBanner.Width, charBanner.Height);
            itemBannerRec = new Rectangle(itemBanner.Location.X, itemBanner.Location.Y, itemBanner.Width, itemBanner.Height);
            mainBannerRec = new Rectangle(mainBanner.Location.X, mainBanner.Location.Y, mainBanner.Width, mainBanner.Height);
            ticketIconRec = new Rectangle(ticketIcon.Location.X, ticketIcon.Location.Y, ticketIcon.Width, ticketIcon.Height);
            ticketAmountRec = new Rectangle(ticketAmount.Location.X, ticketAmount.Location.Y, ticketAmount.Width, ticketAmount.Height);
            shopBtnRec = new Rectangle(shopBtn.Location.X, shopBtn.Location.Y, shopBtn.Width, shopBtn.Height);
            pull1BtnRec = new Rectangle(pull1Btn.Location.X, pull1Btn.Location.Y, pull1Btn.Width, pull1Btn.Height);
            pull10BtnRec = new Rectangle(pull10Btn.Location.X, pull10Btn.Location.Y, pull10Btn.Width, pull10Btn.Height);
            pullAnimRec = new Rectangle(pullAnim.Location.X, pullAnim.Location.Y, pullAnim.Width, pullAnim.Height);


            pullResultPanRec = new Rectangle(pullResultPan.Location.X, pullResultPan.Location.Y, pullResultPan.Width, pullResultPan.Height);
            rewardtxtRec = new Rectangle(rewardtxt.Location.X, rewardtxt.Location.Y, rewardtxt.Width, rewardtxt.Height);
            pullRewardFLPRec = new Rectangle(pullRewardFLP.Location.X, pullRewardFLP.Location.Y, pullRewardFLP.Width, pullRewardFLP.Height);
            resultDoneBtnRec = new Rectangle(resultDoneBtn.Location.X, resultDoneBtn.Location.Y, resultDoneBtn.Width, resultDoneBtn.Height);


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

        private void Gacha_Resize(object sender, EventArgs e)
        {
            resizeControl(backBtnRec, backBtn);

            resizeControl(charBannerRec, charBanner);
            resizeControl(itemBannerRec, itemBanner);
            resizeControl(mainBannerRec, mainBanner);
            resizeControl(ticketIconRec, ticketIcon);
            resizeControl(ticketAmountRec, ticketAmount);
            resizeControl(shopBtnRec, shopBtn);
            resizeControl(pull1BtnRec, pull1Btn);
            resizeControl(pull10BtnRec, pull10Btn);
            resizeControl(pullAnimRec, pullAnim);


            resizeControl(pullResultPanRec, pullResultPan);
            resizeControl(rewardtxtRec, rewardtxt);
            resizeControl(pullRewardFLPRec, pullRewardFLP);
            resizeControl(resultDoneBtnRec, resultDoneBtn);
        }

        private void charBanner_Click(object sender, EventArgs e)
        {
            // Change the image of mainBanner to the main image for charBanner
            mainBanner.Image = Properties.Resources.CBMain;
        }

        private void itemBanner_Click(object sender, EventArgs e)
        {
            // Change the image of mainBanner to the main image for itemBanner
            mainBanner.Image = Properties.Resources.IBMain;
        }

        // Wishing ========================================================================================================================================

        private void pull1Btn_Click(object sender, EventArgs e)
        {
            // Bring pullAnim to the front and show animation
            pullAnim.Image = Properties.Resources.pullAnimation;
            pullAnim.BringToFront();
            pullAnim.Visible = true;

            // Start the timer for 5 seconds
            pullTimer.Start();
        }
        private void PullTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            pullTimer.Stop();

            // Hide pullAnim
            pullAnim.Visible = false;

            // Bring pullResultPan to the front and show it
            pullResultPan.BringToFront();
            pullResultPan.Visible = true;

            // Perform the Gacha pull and update the results
            PerformGachaPull();
        }

        // Tracking for pity system
        private List<int> lastTenPulls = new List<int>(); // Store rarity values of the last 10 pulls
        private bool guaranteeNextPull = false; // To ensure the next pull is guaranteed

        private void PerformGachaPull()
        {
            string mainBannerImage = mainBanner.Image.Tag?.ToString() ?? "CBMain"; // Default to "CBMain" if tag is null
            string[] rewardPool = mainBannerImage == "CBMain" ? charImg : itemImg;
            double[] rewardRates = mainBannerImage == "CBMain" ? charRate : itemRate;

            string obtainedReward = ""; // Default value to avoid unassigned error
            int recordIndex = -1;       // Default value to avoid unassigned error
            int rarity;

            Random random = new Random();
            double roll = random.NextDouble();

            // Pull from the main pool (charImg or itemImg)
            if (guaranteeNextPull || TryGetReward(rewardPool, rewardRates, roll, out obtainedReward, out recordIndex))
            {
                guaranteeNextPull = false; // Reset guarantee flag
                rarity = 5; // Character or Item rarity
            }
            else
            {
                // Pull from coinImg if main pool failed
                TryGetReward(coinImg, coinRate, roll, out obtainedReward, out recordIndex);
                rarity = 1; // Coin rarity
            }

            // Add reward to flow layout panel
            PictureBox rewardBox = new PictureBox
            {
                Image = (Image)Properties.Resources.ResourceManager.GetObject(obtainedReward),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(50, 50)
            };
            pullRewardFLP.Controls.Add(rewardBox);

            // Record reward in the database
            SaveGachaResult(recordIndex, rarity);

            // Update lastTenPulls for pity system
            UpdatePitySystem(rarity);
        }

        private bool TryGetReward(string[] pool, double[] rates, double roll, out string reward, out int index)
        {
            double cumulative = 0;

            for (int i = 0; i < rates.Length; i++)
            {
                cumulative += rates[i];
                if (roll <= cumulative)
                {
                    reward = pool[i];
                    index = i;
                    return true;
                }
            }

            reward = "g100"; // Default fallback for safety
            index = 0;       // Default fallback index
            return false;
        }

        private void SaveGachaResult(int record, int rarity)
        {
            Con.Connection();
            Con.Con.Open();
            string query = "INSERT INTO GachaTbl (record, rarity) VALUES (@record, @rarity)";
            using (SqlCommand command = new SqlCommand(query, Con.Con))
            {
                command.Parameters.AddWithValue("@record", record);
                command.Parameters.AddWithValue("@rarity", rarity);
                command.ExecuteNonQuery();
            }


        }

        private void UpdatePitySystem(int rarity)
        {
            // Add current pull rarity to the list
            lastTenPulls.Add(rarity);

            // Keep only the last 10 pulls
            if (lastTenPulls.Count > 10)
                lastTenPulls.RemoveAt(0);

            // Check if any 5 rarity exists in the last 10 pulls
            if (!lastTenPulls.Contains(5) && lastTenPulls.Count == 10)
            {
                guaranteeNextPull = true; // Enable guarantee for the next pull
            }
        }
    }
}
