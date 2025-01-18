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
    public partial class Map : Form
    {
        private int selectedLevel;

        private Rectangle mapPanRec, backMenuRec, invMapRec, quizBtnRec, setMapBtnRec, gachaBtnRec, originalFormSize;
        private Rectangle levelInfoRec, infoPBRec, startMapRec, cancelMapRec, levelPrevRec, levelNoRec, levelDescRec;
        private Rectangle lvl1Rec, lvl2Rec, lvl3Rec, lvl4Rec, lvl5Rec, lvl6Rec, lvl7Rec, lvl8Rec, lvl9Rec, lvl10Rec;


        private bool isPanelVisible = false;

        //
        // Hardcoded arrays as a "database"
        int[] lvlNum = SharedArray.lvlNum;
        string[] lvlDesc = SharedArray.lvlDesc;
        //string[] lvlImagePath = { "C:\\Users\\liam\\Documents\\...The Game Img\\TheGame\\SplashArt1.jpg", "C:\\Users\\liam\\Documents\\...The Game Img\\TheGame\\SplashArt1.jpg", "C:\\Users\\liam\\Documents\\...The Game Img\\TheGame\\SplashArt1.jpg", "C:\\Users\\liam\\Documents\\...The Game Img\\TheGame\\SplashArt1.jpg "};

        //Resize -end

        //Database
        DBConnection Con = new DBConnection();
        public Map()
        {
            InitializeComponent();
            BackgroundMusic.Instance.Play(); // Start playing background music

            levelInfo.Visible = false;

            // buttons are named button1, button2, ..., button20
            for (int i = 1; i <= 20; i++)
            {
                PictureBox levelPictureBox = this.Controls.Find($"lvl{i}", true).FirstOrDefault() as PictureBox;
                if (levelPictureBox != null)
                {
                    levelPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Or adjust according to your preference
                    levelPictureBox.Tag = i; // Store level number in Tag
                    levelPictureBox.Click += new EventHandler(LevelButton_Click);
                }
            }
            // Load current level from the database
            LoadCurrentLevel();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            //add any components here -jvp
            mapPanRec = new Rectangle(MapPan.Location.X, MapPan.Location.Y, MapPan.Width, MapPan.Height);
            backMenuRec = new Rectangle(backMenuBtn.Location.X, backMenuBtn.Location.Y, backMenuBtn.Width, backMenuBtn.Height);
            invMapRec = new Rectangle(invMapBtn.Location.X, invMapBtn.Location.Y, invMapBtn.Width, invMapBtn.Height);
            quizBtnRec = new Rectangle(quizBtn.Location.X, quizBtn.Location.Y, quizBtn.Width, quizBtn.Height);
            setMapBtnRec = new Rectangle(setMapBtn.Location.X, setMapBtn.Location.Y, setMapBtn.Width, setMapBtn.Height);
            gachaBtnRec = new Rectangle(gachaBtn.Location.X, gachaBtn.Location.Y, gachaBtn.Width, gachaBtn.Height);

            // Level Rectangle
            levelInfoRec = new Rectangle(levelInfo.Location.X, levelInfo.Location.Y, levelInfo.Width, levelInfo.Height);
            //infoPBRec = new Rectangle(infoPB.Location.X, infoPB.Location.Y, infoPB.Width, infoPB.Height);
            levelPrevRec = new Rectangle(levelPrev.Location.X, levelPrev.Location.Y, levelPrev.Width, levelPrev.Height);
            levelNoRec = new Rectangle(levelNo.Location.X, levelNo.Location.Y, levelNo.Width, levelNo.Height);
            levelDescRec = new Rectangle(levelDesc.Location.X, levelDesc.Location.Y, levelDesc.Width, levelDesc.Height);
            startMapRec = new Rectangle(startMapBtn.Location.X, startMapBtn.Location.Y, startMapBtn.Width, startMapBtn.Height);
            cancelMapRec = new Rectangle(cancelMapBtn.Location.X, cancelMapBtn.Location.Y, cancelMapBtn.Width, cancelMapBtn.Height);

            lvl1Rec = new Rectangle(lvl1.Location.X, lvl1.Location.Y, lvl1.Width, lvl1.Height);
            lvl2Rec = new Rectangle(lvl2.Location.X, lvl2.Location.Y, lvl2.Width, lvl2.Height);
            lvl3Rec = new Rectangle(lvl3.Location.X, lvl3.Location.Y, lvl3.Width, lvl3.Height);
            lvl4Rec = new Rectangle(lvl4.Location.X, lvl4.Location.Y, lvl4.Width, lvl4.Height);
            lvl5Rec = new Rectangle(lvl5.Location.X, lvl5.Location.Y, lvl5.Width, lvl5.Height);
            lvl6Rec = new Rectangle(lvl6.Location.X, lvl6.Location.Y, lvl6.Width, lvl6.Height);
            lvl7Rec = new Rectangle(lvl7.Location.X, lvl7.Location.Y, lvl7.Width, lvl7.Height);
            lvl8Rec = new Rectangle(lvl8.Location.X, lvl8.Location.Y, lvl8.Width, lvl8.Height);
            lvl9Rec = new Rectangle(lvl9.Location.X, lvl9.Location.Y, lvl9.Width, lvl9.Height);
            lvl10Rec = new Rectangle(lvl10.Location.X, lvl10.Location.Y, lvl10.Width, lvl10.Height);

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set the image for devMenuBtn (which is now a PictureBox)
            backMenuBtn.Image = Properties.Resources.BackIcon; // Replace <ImageName> with the actual resource image name
            backMenuBtn.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox
            invMapBtn.Image = Properties.Resources.InvIcon; // Replace <ImageName> with the actual resource image name
            invMapBtn.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox // Set the image for devMenuBtn (which is now a PictureBox)
            setMapBtn.Image = Properties.Resources.PartyIcon; // Replace <ImageName> with the actual resource image name
            setMapBtn.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox
            gachaBtn.Image = Properties.Resources.ArchIcon; // Replace <ImageName> with the actual resource image name
            gachaBtn.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox
            quizBtn.Image = Properties.Resources.QuizIcon; // Replace <ImageName> with the actual resource image name
            quizBtn.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox


            //infoPB.Image = Properties.Resources.PartySetupIcon; // Replace <ImageName> with the actual resource image name
            // Set the SizeMode to properly fit the image
            //infoPB.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox
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
        private void Map_Resize(object sender, EventArgs e)
        {
            //(rectangleName, componentName) -jvp
            resizeControl(mapPanRec, MapPan);
            resizeControl(backMenuRec, backMenuBtn);
            resizeControl(invMapRec, invMapBtn);
            resizeControl(setMapBtnRec, setMapBtn);
            resizeControl(gachaBtnRec, gachaBtn);
            resizeControl(quizBtnRec, quizBtn);

            //Level ResizeContr
            resizeControl(levelInfoRec, levelInfo);
            //resizeControl(infoPBRec, infoPB);
            resizeControl(levelPrevRec, levelPrev);
            resizeControl(levelNoRec, levelNo);
            resizeControl(levelDescRec, levelDesc);
            resizeControl(startMapRec, startMapBtn);
            resizeControl(cancelMapRec, cancelMapBtn);
            resizeControl(lvl1Rec, lvl1);
            resizeControl(lvl2Rec, lvl2);
            resizeControl(lvl3Rec, lvl3);
            resizeControl(lvl4Rec, lvl4);
            resizeControl(lvl5Rec, lvl5);
            resizeControl(lvl6Rec, lvl6);
            resizeControl(lvl7Rec, lvl7);
            resizeControl(lvl8Rec, lvl8);
            resizeControl(lvl9Rec, lvl9);
            resizeControl(lvl10Rec, lvl10);

        }


        private void backMenuBtn_Click_1(object sender, EventArgs e)
        {
            Loading load = new Loading();
            load.Show();
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    load.Hide();
                    Menu menu = new Menu();
                    menu.Show();
                });
            });
        }
        private void invMapBtn_Click_1(object sender, EventArgs e)
        {
            Loading load = new Loading();
            load.Show();
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    load.Hide();
                    Inventory2 inv = new Inventory2();
                    inv.Show();
                });
            });
        }
        private void setMapBtn_Click_1(object sender, EventArgs e)
        {
            Party party = new Party();
            party.Show();
            this.Hide();
        }
        private void gachaBtn_Click(object sender, EventArgs e)
        {
            Loading load = new Loading();
            load.Show();
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    load.Hide();
                    Collection inv = new Collection();
                    inv.Show();
                });
            });
        }
        private void quizBtn_Click(object sender, EventArgs e)
        {
            Loading load = new Loading();
            load.Show();
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    load.Hide();
                    Quiz inv = new Quiz();
                    inv.Show();
                });
            });
        }
        private void startMapBtn_Click(object sender, EventArgs e)
        {
            Loading load = new Loading();
            load.Show();
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    load.Hide();
                    Combat com = new Combat(selectedLevel);  // Pass the selected level to Combat
                    com.SetLevelImage(GetLevelImage(selectedLevel));  // Set the level image
                    com.Show();
                });
            });
        }

        //Level Panel
        // Current Level
        private void LoadCurrentLevel()
        {
            try
            {
                // Open the database connection
                Con.Connection();
                Con.Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT lvlClear FROM LevelTbl", Con.Con);

                // Use ExecuteScalar() to get the current level from the database
                int currentLevel = Convert.ToInt32(cmd.ExecuteScalar());

                // Loop through all level PictureBoxes to set their state based on the current level
                for (int i = 1; i <= 20; i++)
                {
                    PictureBox levelPictureBox = this.Controls.Find($"lvl{i}", true).FirstOrDefault() as PictureBox;
                    if (levelPictureBox != null)
                    {
                        if (i <= currentLevel)
                        {
                            // Enable PictureBoxes for levels up to the current level
                            levelPictureBox.Enabled = true;
                            levelPictureBox.Image = Properties.Resources.OpenWaypoint; // Image for enabled levels
                        }
                        else
                        {
                            // Disable PictureBoxes for levels above the current level and set their image to closed waypoint
                            levelPictureBox.Enabled = false;
                            levelPictureBox.Image = Properties.Resources.ClosedWaypoint;
                        }
                    }
                }

                Con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading current level: {ex.Message}");
            }
        }


        //Level Info
        string[] levelDescriptions = new string[]
{
    // Add descriptions for each level up to Level 20
    "Level 1: Welcome to the journey!, A villager visits you in your house seeking for your help",
    "Level 2: Not too long before you have encountered another creature",
    "Level 3: You made your way to the sea shore to find a safe place to rest",
    "Level 4: A dark forest looms ahead.",
    "Level 5: A dark forest looms ahead.",
    "Level 6: A dark forest looms ahead.",
    "Level 7: A dark forest looms ahead.",
    "Level 8: A dark forest looms ahead.",
    "Level 9: A dark forest looms ahead.",
    "Level 10: A dark forest looms ahead.",
    "Level 11: A dark forest looms ahead.",
    "Level 12: A dark forest looms ahead.",
    "Level 13 A dark forest looms ahead.",
    "Level 14: A dark forest looms ahead.",
    "Level 15: A dark forest looms ahead.",
    "Level 16: A dark forest looms ahead.",
    "Level 17: A dark forest looms ahead.",
    "Level 18: A dark forest looms ahead.",
    "Level 19: A dark forest looms ahead.",
    "Level 20: The final challenge awaits!"
};
        private void LevelButton_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            // Update the level info display
            selectedLevel = Convert.ToInt32(clickedPictureBox.Tag);
            if (selectedLevel >= 1 && selectedLevel <= levelDescriptions.Length)
            {
                // Show the levelInfo panel
                levelInfo.Visible = true;

                // Update the level description
                levelNo.Text = $"{selectedLevel}";
                levelDesc.Text = levelDescriptions[selectedLevel - 1];  // Adjust index for 0-based array
            }

            // Determine which image to use for the level preview
            try
            {
                object imgObj = null;

                if (selectedLevel >= 1 && selectedLevel <= 1)
                {
                    imgObj = Properties.Resources.ResourceManager.GetObject("LevelGroup1"); // Use the same image for levels 1 to 5
                }
                else if (selectedLevel >= 2 && selectedLevel <= 2)
                {
                    imgObj = Properties.Resources.ResourceManager.GetObject("LevelGroup2"); // Use the same image for levels 6 to 10
                }
                else if (selectedLevel >= 3 && selectedLevel <= 3)
                {
                    imgObj = Properties.Resources.ResourceManager.GetObject("LevelGroup3"); // Use the same image for levels 11 to 15
                }
                else if (selectedLevel >= 4 && selectedLevel <= 4)
                {
                    imgObj = Properties.Resources.ResourceManager.GetObject("LevelGroup4"); // Use the same image for levels 16 to 20
                }

                // Ensure that the image exists in resources
                if (imgObj != null)
                {
                    levelPrev.Image = (Image)imgObj;
                }
                else
                {
                    MessageBox.Show($"Image for Level Group not found in resources.");
                    levelPrev.Image = null;  // Clear the PictureBox if the image is not found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image for Level {selectedLevel}: {ex.Message}");
                levelPrev.Image = null;  // Clear the PictureBox if there's an error
            }
        }
        //Send LevelPrev info to Combat
        public Image GetLevelImage(int level)
        {
            if (level >= 1 && level <= 1)
            {
                return Properties.Resources.LevelGroup1;
            }
            else if (level >= 2 && level <= 2)
            {
                return Properties.Resources.LevelGroup2;
            }
            else if (level >= 3 && level <= 3)
            {
                return Properties.Resources.LevelGroup3;
            }
            else if (level >= 4 && level <= 4)
            {
                return Properties.Resources.LevelGroup4;
            }
            else if (level >= 5 && level <= 5)
            {
                return Properties.Resources.LevelGroup1;
            }
            else if (level >= 6 && level <= 6)
            {
                return Properties.Resources.LevelGroup2;
            }
            else if (level >= 7 && level <= 7)
            {
                return Properties.Resources.LevelGroup3;
            }
            else if (level >= 8 && level <= 8)
            {
                return Properties.Resources.LevelGroup4;
            }
            else if (level >= 9 && level <= 9)
            {
                return Properties.Resources.LevelGroup1;
            }
            else if (level >= 10 && level <= 10)
            {
                return Properties.Resources.LevelGroup2;
            }
            return null; // Default if not found
        }

        private void cancelMapBtn_Click(object sender, EventArgs e)
        {
            levelInfo.Visible = false;
        }
    }
}
