using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;

namespace TheGameProject
{
    public partial class Combat : Form
    {

        private int selectedLevel;
        //private Timer storyTimer;
        private Timer storyTimer = new Timer(); // Timer for hiding animation and starting combat
        private SoundPlayer soundPlayer;
        private Timer narrationTimer;
        private Timer hideAnimTimer = new Timer(); // Timer to hide ultimate animation
        private Timer attackImageTimer = new Timer();
        private int charIndex; // Holds the index of the character whose skill was activated
        private int currentTurnIndex = 0; // Keeps track of the current turn
        private bool playerTurn = true; // Indicates if it's the player's turn
        private int totalPlayerUnits = 3; // Total number of player turn
        private Random random = new Random(); // Random generator for selecting targets

        private Rectangle backMapBtnRec, mapComPanRec, controlPanRec, originalFormSize, notifCombatRec, storyDisplayRec;
        private Rectangle levelCombatRec, animComRec, pUnit1Rec, pUnit2Rec, pUnit3Rec;
        private Rectangle eUnit1Rec, eUnit2Rec, eUnit3Rec, eUnit1HpRec, eUnit2HpRec, eUnit3HpRec, eTurnIconRec;
        private Rectangle eUnit1DefRec, eUnit2DefRec, eUnit3DefRec;
        private Rectangle pUnit1IconRec, pUnit2IconRec, pUnit3IconRec;
        private Rectangle pUnit1SkillRec, pUnit2SkillRec, pUnit3SkillRec;
        private Rectangle pUnit1HpRec, pUnit2HpRec, pUnit3HpRec;
        private Rectangle p1HpLabelRec, p2HpLabelRec, p3HpLabelRec, e1HpLabelRec, e2HpLabelRec, e3HpLabelRec;
        private Rectangle e1HitEffRec, e2HitEffRec, e3HitEffRec;
        private Rectangle dmgCountRec, dmgCountBGRec, unitItem1Rec, unitItem2Rec, unitItem3Rec;

        string[] storyImg = SharedArray.storyImg;
        string[] storySound = SharedArray.storySound;

        string[] iImg = SharedArray.iImg;
        int[] iHP = SharedArray.iHP;
        int[] iATK = SharedArray.iATK;
        string[] iEle = SharedArray.iEle;
        int[] iHB = SharedArray.iHB;

        string[] charIconImg = SharedArray.charIconImg;
        string[] charIdleImg = SharedArray.charIdleImg;
        string[] charName = SharedArray.charName;
        int[] charHp = SharedArray.charHp;
        int[] charAtk = SharedArray.charAtk;
        int[] charHeal = SharedArray.charHeal;
        string[] charAtkImg = SharedArray.charAtkImg;
        string[] charEffImg = SharedArray.charEffImg;
        string[] charEffSound = SharedArray.charEffSound;
        string[] charSkill = SharedArray.charSkill;
        string[] charUltImg = SharedArray.charUltImg;
        string[] charUltSound = SharedArray.charUltSound;
        string[] charEle = SharedArray.charEle;
        string[] charDeathImg = SharedArray.charDeathImg;

        // Enemy Array
        string[][] enemIconImg = SharedArray.enemIconImg;
        string[][] enemIdleImg = SharedArray.enemIdleImg;
        string[][] enemAtkImg = SharedArray.enemAtkImg;
        string[][] enemEffImg = SharedArray.enemEffImg;
        string[][] enemEffSound = SharedArray.enemEffSound;
        string[][] enemDeathImg = SharedArray.enemDeathImg;
        string[][] enemame = SharedArray.enemName;
        string[][] enemElem = SharedArray.enemElem;
        int[][] enemHp = SharedArray.enemHp;
        int[][] enemAtk = SharedArray.enemAtk;
        int[][] enemDef = SharedArray.enemDef;


        // Database connection object
        DBConnection Con = new DBConnection();
        private int combatLevel;
        public Combat(int level)
        {
            InitializeComponent();
            combatLevel = level;
            selectedLevel = level;

            PlayStoryNarration();
            levelCombat.Text = $"Level {combatLevel} Combat";
            //StartCombat();

            // Initialize Timer
            hideAnimTimer.Interval = 4000; // 5 seconds
            hideAnimTimer.Tick += HideAnimTimer_Tick;

            //attackImageTimer.Interval = 2000; // 2 seconds for changing back to idle image
            //attackImageTimer.Tick += AttackImageTimer_Tick;
            // Call ShowStory to display the story and narration
            //ShowStory();
            LoadPartyCharacters();
            DisplayEnemyImages(level);

            // Add Click event handlers for the skill PictureBoxes
            pUnit1Skill.Click += Skill_Click;
            pUnit2Skill.Click += Skill_Click;
            pUnit3Skill.Click += Skill_Click;
        }

        private void Combat_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);

            // Initialize rectangle sizes
            InitializeRectangles();

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            backMapBtn.Image = Properties.Resources.BackIcon; // Replace <ImageName> with the actual resource image name
            backMapBtn.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox
        }
        private void InitializeRectangles()
        {
            backMapBtnRec = new Rectangle(backMapBtn.Location.X, backMapBtn.Location.Y, backMapBtn.Width, backMapBtn.Height);
            mapComPanRec = new Rectangle(mapComPan.Location.X, mapComPan.Location.Y, mapComPan.Width, mapComPan.Height);
            controlPanRec = new Rectangle(controlPan.Location.X, controlPan.Location.Y, controlPan.Width, controlPan.Height);
            storyDisplayRec = new Rectangle(storyDisplay.Location.X, storyDisplay.Location.Y, storyDisplay.Width, storyDisplay.Height);

            levelCombatRec = new Rectangle(levelCombat.Location.X, levelCombat.Location.Y, levelCombat.Width, levelCombat.Height);
            animComRec = new Rectangle(animCom.Location.X, animCom.Location.Y, animCom.Width, animCom.Height);
            pUnit1Rec = new Rectangle(pUnit1.Location.X, pUnit1.Location.Y, pUnit1.Width, pUnit1.Height);
            pUnit2Rec = new Rectangle(pUnit2.Location.X, pUnit2.Location.Y, pUnit2.Width, pUnit2.Height);
            pUnit3Rec = new Rectangle(pUnit3.Location.X, pUnit3.Location.Y, pUnit3.Width, pUnit3.Height);
            notifCombatRec = new Rectangle(notifCombat.Location.X, notifCombat.Location.Y, notifCombat.Width, notifCombat.Height);
            eTurnIconRec = new Rectangle(eTurnIcon.Location.X, eTurnIcon.Location.Y, eTurnIcon.Width, eTurnIcon.Height);
            eUnit1Rec = new Rectangle(eUnit1.Location.X, eUnit1.Location.Y, eUnit1.Width, eUnit1.Height);
            eUnit2Rec = new Rectangle(eUnit2.Location.X, eUnit2.Location.Y, eUnit2.Width, eUnit2.Height);
            eUnit3Rec = new Rectangle(eUnit3.Location.X, eUnit3.Location.Y, eUnit3.Width, eUnit3.Height);
            eUnit1HpRec = new Rectangle(eUnit1Hp.Location.X, eUnit1Hp.Location.Y, eUnit1Hp.Width, eUnit1Hp.Height);
            eUnit2HpRec = new Rectangle(eUnit2Hp.Location.X, eUnit2Hp.Location.Y, eUnit2Hp.Width, eUnit2Hp.Height);
            eUnit3HpRec = new Rectangle(eUnit3Hp.Location.X, eUnit3Hp.Location.Y, eUnit3Hp.Width, eUnit3Hp.Height);
            eUnit1DefRec = new Rectangle(eUnit1Def.Location.X, eUnit1Def.Location.Y, eUnit1Def.Width, eUnit1Def.Height);
            eUnit2DefRec = new Rectangle(eUnit2Def.Location.X, eUnit2Def.Location.Y, eUnit2Def.Width, eUnit2Def.Height);
            eUnit3DefRec = new Rectangle(eUnit3Def.Location.X, eUnit3Def.Location.Y, eUnit3Def.Width, eUnit3Def.Height);

            //Combat Control
            pUnit1IconRec = new Rectangle(pUnit1Icon.Location.X, pUnit1Icon.Location.Y, pUnit1Icon.Width, pUnit1Icon.Height);
            pUnit2IconRec = new Rectangle(pUnit2Icon.Location.X, pUnit2Icon.Location.Y, pUnit2Icon.Width, pUnit2Icon.Height);
            pUnit3IconRec = new Rectangle(pUnit3Icon.Location.X, pUnit3Icon.Location.Y, pUnit3Icon.Width, pUnit3Icon.Height);
            pUnit1SkillRec = new Rectangle(pUnit1Skill.Location.X, pUnit1Skill.Location.Y, pUnit1Skill.Width, pUnit1Skill.Height);
            pUnit2SkillRec = new Rectangle(pUnit2Skill.Location.X, pUnit2Skill.Location.Y, pUnit2Skill.Width, pUnit2Skill.Height);
            pUnit3SkillRec = new Rectangle(pUnit3Skill.Location.X, pUnit3Skill.Location.Y, pUnit3Skill.Width, pUnit3Skill.Height);
            pUnit1HpRec = new Rectangle(pUnit1Hp.Location.X, pUnit1Hp.Location.Y, pUnit1Hp.Width, pUnit1Hp.Height);
            pUnit2HpRec = new Rectangle(pUnit2Hp.Location.X, pUnit2Hp.Location.Y, pUnit2Hp.Width, pUnit2Hp.Height);
            pUnit3HpRec = new Rectangle(pUnit3Hp.Location.X, pUnit3Hp.Location.Y, pUnit3Hp.Width, pUnit3Hp.Height);
            p1HpLabelRec = new Rectangle(p1HpLabel.Location.X, p1HpLabel.Location.Y, p1HpLabel.Width, p1HpLabel.Height);
            p2HpLabelRec = new Rectangle(p2HpLabel.Location.X, p2HpLabel.Location.Y, p2HpLabel.Width, p2HpLabel.Height);
            p3HpLabelRec = new Rectangle(p3HpLabel.Location.X, p3HpLabel.Location.Y, p3HpLabel.Width, p3HpLabel.Height);

            e1HpLabelRec = new Rectangle(e1HpLabel.Location.X, e1HpLabel.Location.Y, e1HpLabel.Width, e1HpLabel.Height);
            e2HpLabelRec = new Rectangle(e2HpLabel.Location.X, e2HpLabel.Location.Y, e2HpLabel.Width, e2HpLabel.Height);
            e3HpLabelRec = new Rectangle(e3HpLabel.Location.X, e3HpLabel.Location.Y, e3HpLabel.Width, e3HpLabel.Height);

            // Effect
            e1HitEffRec = new Rectangle(e1HitEff.Location.X, e1HitEff.Location.Y, e1HitEff.Width, e1HitEff.Height);
            e2HitEffRec = new Rectangle(e2HitEff.Location.X, e2HitEff.Location.Y, e2HitEff.Width, e2HitEff.Height);
            e3HitEffRec = new Rectangle(e3HitEff.Location.X, e3HitEff.Location.Y, e3HitEff.Width, e3HitEff.Height);

            dmgCountRec = new Rectangle(dmgCount.Location.X, dmgCount.Location.Y, dmgCount.Width, dmgCount.Height);
            //dmgCountBGRec = new Rectangle(dmgCountBG.Location.X, dmgCountBG.Location.Y, dmgCountBG.Width, dmgCountBG.Height);
            unitItem1Rec = new Rectangle(unitItem1.Location.X, unitItem1.Location.Y, unitItem1.Width, unitItem1.Height);
            unitItem2Rec = new Rectangle(unitItem2.Location.X, unitItem2.Location.Y, unitItem2.Width, unitItem2.Height);
            unitItem3Rec = new Rectangle(unitItem3.Location.X, unitItem3.Location.Y, unitItem3.Width, unitItem3.Height);
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
        private void Combat_Resize(object sender, EventArgs e)
        {
            //(rectangleName, componentName) -jvp
            resizeControl(backMapBtnRec, backMapBtn);
            resizeControl(mapComPanRec, mapComPan);
            resizeControl(controlPanRec, controlPan);
            resizeControl(storyDisplayRec, storyDisplay);

            //Level ResizeContr
            resizeControl(levelCombatRec, levelCombat);
            resizeControl(animComRec, animCom);
            resizeControl(notifCombatRec, notifCombat);
            resizeControl(pUnit1Rec, pUnit1);
            resizeControl(pUnit2Rec, pUnit2);
            resizeControl(pUnit3Rec, pUnit3);
            resizeControl(eUnit1Rec, eUnit1);
            resizeControl(eUnit2Rec, eUnit2);
            resizeControl(eUnit3Rec, eUnit3);
            resizeControl(eUnit1HpRec, eUnit1Hp);
            resizeControl(eUnit2HpRec, eUnit2Hp);
            resizeControl(eUnit3HpRec, eUnit3Hp);
            resizeControl(eUnit1DefRec, eUnit1Def);
            resizeControl(eUnit2DefRec, eUnit2Def);
            resizeControl(eUnit3DefRec, eUnit3Def);

            resizeControl(pUnit1IconRec, pUnit1Icon);
            resizeControl(pUnit2IconRec, pUnit2Icon);
            resizeControl(pUnit3IconRec, pUnit3Icon);
            resizeControl(pUnit1SkillRec, pUnit1Skill);
            resizeControl(pUnit2SkillRec, pUnit2Skill);
            resizeControl(pUnit3SkillRec, pUnit3Skill);
            resizeControl(pUnit1HpRec, pUnit1Hp);
            resizeControl(pUnit2HpRec, pUnit2Hp);
            resizeControl(pUnit3HpRec, pUnit3Hp);
            resizeControl(p1HpLabelRec, p1HpLabel);
            resizeControl(p2HpLabelRec, p2HpLabel);
            resizeControl(p3HpLabelRec, p3HpLabel);

            resizeControl(eTurnIconRec, eTurnIcon);
            resizeControl(e1HpLabelRec, e1HpLabel);
            resizeControl(e2HpLabelRec, e2HpLabel);
            resizeControl(e3HpLabelRec, e3HpLabel);

            resizeControl(e1HitEffRec, e1HitEff);
            resizeControl(e2HitEffRec, e2HitEff);
            resizeControl(e3HitEffRec, e3HitEff);

            resizeControl(dmgCountRec, dmgCount);
            //resizeControl(dmgCountBGRec, dmgCountBG);
            resizeControl(unitItem1Rec, unitItem1);
            resizeControl(unitItem2Rec, unitItem2);
            resizeControl(unitItem3Rec, unitItem3);
        }
        private void backMapBtn_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            map.Show();
            this.Hide();
        }
        public void SetLevelImage(Image levelImage)
        {
            if (levelImage != null)
            {
                mapComPan.BackgroundImage = levelImage;
                mapComPan.BackgroundImageLayout = ImageLayout.Stretch;
                mapComPan.SendToBack(); // Send the panel to the back if necessary
            }
        }
        private void LoadPartyCharacters()
        {
            try
            {
                Con.Connection();
                Con.Con.Open();

                string query = "SELECT TOP 1 party1, party2, party3 FROM PartyTbl ORDER BY PartyID DESC";
                SqlCommand cmd = new SqlCommand(query, Con.Con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int? party1Index = reader["party1"] as int?;
                    int? party2Index = reader["party2"] as int?;
                    int? party3Index = reader["party3"] as int?;

                    SetPartyCharacterImage(pUnit1, party1Index);
                    SetPartyCharacterImage(pUnit2, party2Index);
                    SetPartyCharacterImage(pUnit3, party3Index);

                    SetPartySkillImage(pUnit1Skill, party1Index);
                    SetPartySkillImage(pUnit2Skill, party2Index);
                    SetPartySkillImage(pUnit3Skill, party3Index);

                    SetUnitIconImage(pUnit1Icon, party1Index);
                    SetUnitIconImage(pUnit2Icon, party2Index);
                    SetUnitIconImage(pUnit3Icon, party3Index);

                    // Set health for units
                    SetUnitHealth(pUnit1Hp, p1HpLabel, party1Index);
                    SetUnitHealth(pUnit2Hp, p2HpLabel, party2Index);
                    SetUnitHealth(pUnit3Hp, p3HpLabel, party3Index);
                }

                reader.Close();
                Con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading party data: {ex.Message}");
            }
        }
        private void SetPartyCharacterImage(PictureBox targetPictureBox, int? charIndex)
        {
            targetPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            if (charIndex.HasValue && charIndex.Value >= 0 && charIndex.Value < charIdleImg.Length)
            {
                targetPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(charIdleImg[charIndex.Value]);
                targetPictureBox.Tag = charIndex;
            }
            else
            {
                targetPictureBox.Image = null;
                targetPictureBox.Tag = null;
            }
        }
        private void SetPartySkillImage(PictureBox targetPictureBox, int? charIndex)
        {
            targetPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            if (charIndex.HasValue && charIndex.Value >= 0 && charIndex.Value < charSkill.Length)
            {
                targetPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(charSkill[charIndex.Value]);
                targetPictureBox.Tag = charIndex;
            }
            else
            {
                targetPictureBox.Image = null;
                targetPictureBox.Tag = null;
            }
        }
        private void SetUnitIconImage(PictureBox targetPictureBox, int? charIndex)
        {
            targetPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            if (charIndex.HasValue && charIndex.Value >= 0 && charIndex.Value < charIconImg.Length)
            {
                targetPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(charIconImg[charIndex.Value]);
                targetPictureBox.Tag = charIndex;
            }
            else
            {
                targetPictureBox.Image = null;
                targetPictureBox.Tag = null;
            }
        }
        private void SetUnitHealth(ProgressBar healthBar, System.Windows.Forms.Label healthLabel, int? charIndex)
        {
            if (charIndex.HasValue && charIndex.Value >= 0 && charIndex.Value < charHp.Length)
            {
                int baseHp = charHp[charIndex.Value];
                int itemBonusHp = 0;

                try
                {
                    Con.Connection();
                    Con.Con.Open();

                    string query = "SELECT itemNo FROM CharTbl WHERE charNo = @charNo";
                    SqlCommand cmd = new SqlCommand(query, Con.Con);
                    cmd.Parameters.AddWithValue("@charNo", charIndex.Value);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        int itemNo = Convert.ToInt32(result);
                        if (itemNo >= 0 && itemNo < iHP.Length)
                        {
                            itemBonusHp = iHP[itemNo];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching item data: {ex.Message}");
                }
                finally
                {
                    Con.Con.Close();
                }

                // Calculate and update the health bar and label
                int healthValue = baseHp + itemBonusHp;
                healthBar.Maximum = healthValue;
                healthBar.Value = Math.Min(healthValue, healthBar.Maximum);
                healthLabel.Text = $"HP: {healthValue}/{healthBar.Maximum}";
            }
            else
            {
                healthBar.Value = 0;
                healthBar.Maximum = 100; // Default max value
                healthLabel.Text = "HP: N/A";
            }
        }

        // Enemy
        private void DisplayEnemyImages(int level)
        {
            // Use level - 1 as an index because levels are typically 1-based
            int index = level - 1;

            // Make sure the index is within bounds of the enemyIdleImg array
            if (index >= 0 && index < enemIdleImg.Length)
            {
                // Set images for eUnit1, eUnit2, and eUnit3 based on the selected set
                SetEnemyImage(eUnit1, enemIdleImg[index][0]);
                SetEnemyImage(eUnit2, enemIdleImg[index][1]);
                SetEnemyImage(eUnit3, enemIdleImg[index][2]);

                // Set HP values for eUnit1Hp, eUnit2Hp, eUnit3Hp
                SetEnemyHealth(eUnit1Hp, enemHp[index][0]);
                SetEnemyHealth(eUnit2Hp, enemHp[index][1]);
                SetEnemyHealth(eUnit3Hp, enemHp[index][2]);

                // Update HP labels if you have them
                UpdateHpLabel(e1HpLabel, enemHp[index][0]);
                UpdateHpLabel(e2HpLabel, enemHp[index][1]);
                UpdateHpLabel(e3HpLabel, enemHp[index][2]);

                // Set Defense values for eUnit1Def, eUnit2Def, eUnit3Def
                
                SetEnemyDefense(eUnit1Def, enemDef[index][0]);
                SetEnemyDefense(eUnit2Def, enemDef[index][1]);
                SetEnemyDefense(eUnit3Def, enemDef[index][2]);
            }
            else
            {
                // Handle the case where the level index is out of bounds
                MessageBox.Show("Invalid level index.");
            }
        }
        private void SetEnemyImage(PictureBox pictureBox, string imageName)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
        }
        private void SetEnemyHealth(ProgressBar healthBar, int healthValue)
        {
            // Set the maximum value of the ProgressBar to the unit's own health value
            healthBar.Maximum = healthValue;
            healthBar.Value = healthValue; // Ensure the ProgressBar value does not exceed the maximum
        }
        private void SetEnemyDefense(ProgressBar defenseBar, int defenseValue)
        {
            defenseBar.Maximum = defenseValue; // Set the maximum value for the ProgressBar
            defenseBar.Value = defenseValue; // Set the current value, ensuring it does not exceed the max
        }
        private void UpdateHpLabel(System.Windows.Forms.Label hpLabel, int hpValue)
        {
            hpLabel.Text = $"HP: {hpValue}";
        }
        // STORY ===============================================================================================================
        private void PlayStoryNarration()
        {
            // Ensure timer is not already running
            if (storyTimer != null)
            {
                storyTimer.Stop();
                storyTimer.Dispose();
                storyTimer = null;
            }

            // Check if the selected level has a corresponding story
            if (selectedLevel >= 1 && selectedLevel <= storyImg.Length)
            {
                string story = storyImg[selectedLevel - 1];
                string storyAudio = storySound[selectedLevel - 1];

                // Hide skill buttons
                pUnit1Skill.Visible = false;
                pUnit2Skill.Visible = false;
                pUnit3Skill.Visible = false;

                // Load and display the story image
                var imgObj = Properties.Resources.ResourceManager.GetObject(story);
                if (imgObj != null)
                {
                    storyDisplay.BringToFront();
                    storyDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
                    storyDisplay.Image = (Image)imgObj;
                    storyDisplay.Visible = true;
                }

                // Load and play the sound
                try
                {
                    Stream audioStream = Properties.Resources.ResourceManager.GetStream(storyAudio);
                    if (audioStream != null)
                    {
                        soundPlayer = new SoundPlayer(audioStream);
                        soundPlayer.Play();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing audio: {ex.Message}");
                }

                // Set up a timer to hide animCom and start combat after 10 seconds
                storyTimer = new Timer
                {
                    Interval = 10000 // 10 seconds
                };
                storyTimer.Tick += StoryTimer_Tick;
                storyTimer.Start();
            }
            else
            {
                selectedLevel = 0; // Reset or handle invalid level
                StartCombat(); // Directly start combat if no story
            }
        }
        // Placeholder for a method to calculate sound duration
        private int GetSoundDuration(Stream audioStream)
        {
            // Implementation depends on audio format
            return 10000; // Default to 10 seconds
        }
        private void StoryTimer_Tick(object sender, EventArgs e)
        {
            if (storyTimer != null)
            {
                storyTimer.Stop();
                storyTimer.Dispose();
                storyTimer = null;
            }

            // Hide the animCom PictureBox
            storyDisplay.SendToBack();
            storyDisplay.Visible = false;

            // Stop sound playback
            try
            {
                if (soundPlayer != null)
                {
                    soundPlayer.Stop();
                    soundPlayer.Dispose();
                    soundPlayer = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping audio: {ex.Message}");
            }

            // Restore skill button visibility
            pUnit1Skill.Visible = true;
            pUnit2Skill.Visible = true;
            pUnit3Skill.Visible = true;

            // Proceed to combat
            StartCombat();
        }
        // Display the story animation and narration

        // MAIN BATTLE ===================================================================================================================================
        //================================================================================================================================================
        // TODO
        // hide all buttons during unit attack


        private bool[] isEnemyDead = new bool[3]; // Assuming 3 enemies
        // Add SoundPlayer instances to your class
        private SoundPlayer charUltSoundPlayer;
        private SoundPlayer charEffSoundPlayer;
        private SoundPlayer enemyUltSoundPlayer;
        private SoundPlayer enemyEffSoundPlayer;

        private async void Skill_Click(object sender, EventArgs e)
        {
            PictureBox skillPictureBox = sender as PictureBox;
            int charIndex = (int)(skillPictureBox.Tag ?? -1);
            if (charIndex < 0) return;

            PictureBox targetUnit = GetTargetUnit(skillPictureBox);
            if (targetUnit == null) return;

            // Hide the clicked skill button and mark it as used
            skillPictureBox.Visible = false;
            //isSkillUsed[charIndex] = true;

            //currentTurnIndex++;

            // Show the ultimate animation
            animCom.BringToFront();
            animCom.SizeMode = PictureBoxSizeMode.StretchImage;
            animCom.Image = (Image)Properties.Resources.ResourceManager.GetObject(charUltImg[charIndex]);
            animCom.Visible = true;

            // Play ultimate sound
            PlayCharUltSound(charIndex);

            hideAnimTimer.Start();

            // Delay before setting the unit to the attack image
            await Task.Delay(4000);
            targetUnit.Image = (Image)Properties.Resources.ResourceManager.GetObject(charAtkImg[charIndex]);
            targetUnit.Tag = charIndex;

            // Delay before restoring the idle image
            await Task.Delay(2000);
            targetUnit.Image = (Image)Properties.Resources.ResourceManager.GetObject(charIdleImg[charIndex]);

            // Hide animation and apply skill effect
            animCom.Visible = false;
            hideAnimTimer.Stop();

            // Stop ultimate sound when animation hides
            StopCharUltSound();

            // Choose a random enemy and apply the effect
            //int targetEnemyIndex = new Random().Next(0, 3);
            //ApplySkillEffect(targetEnemyIndex, charIndex);
            int targetEnemyIndex = GetRandomAliveEnemy();
            if (targetEnemyIndex != -1) // Proceed only if there are alive enemies
            {
                // After 3 player turns, switch to enemy's turn
                ApplySkillEffect(targetEnemyIndex, charIndex);
            }

            if (AreAllEnemiesDead())
            {
                await Task.Delay(1000); // Optional delay before ending combat
                EndCombat(); // End combat if all enemies are dead
                return; // Prevent further action
            }
            NextTurn(); // Switch to enemy's turn
        }
        private int GetRandomAliveEnemy()
        {
            List<int> aliveEnemies = new List<int>();

            // Collect the indexes of alive enemies
            for (int i = 0; i < isEnemyDead.Length; i++)
            {
                if (!isEnemyDead[i]) // Only consider alive enemies
                {
                    aliveEnemies.Add(i);
                }
            }

            // If there are no alive enemies, return -1 or handle the combat victory scenario
            if (aliveEnemies.Count == 0)
            {
                Console.WriteLine("All enemies are dead. Victory!");
                EndCombat(); // This can be your combat victory logic
                return -1;
            }

            // Select a random alive enemy
            Random random = new Random();
            int selectedIndex = random.Next(aliveEnemies.Count);
            return aliveEnemies[selectedIndex];
        }

        private PictureBox GetTargetUnit(PictureBox skillPictureBox)
        {
            if (skillPictureBox == pUnit1Skill) return pUnit1;
            if (skillPictureBox == pUnit2Skill) return pUnit2;
            if (skillPictureBox == pUnit3Skill) return pUnit3;
            return null;
        }
        private void HideAnimTimer_Tick(object sender, EventArgs e)
        {
            animCom.Visible = false;
            hideAnimTimer.Stop();

            // Stop the ultimate sound when the animation is hidden
            StopCharUltSound();
        }
        // Play the ultimate sound based on character index
        private void PlayCharUltSound(int charIndex)
        {

            //try
            //string soundName = charUltSound[charIndex];
            System.Media.SoundPlayer soundName = new System.Media.SoundPlayer(Properties.Resources.ResourceManager.GetStream(charUltSound[charIndex]));
            soundName.Play();
        }
        // Stop the ultimate sound
        private void StopCharUltSound()
        {
            if (charUltSoundPlayer != null)
            {
                charUltSoundPlayer.Stop();
                charUltSoundPlayer.Dispose(); // Dispose the sound player to release resources
                charUltSoundPlayer = null;
            }
        }

        // Method to get element-based damage multiplier
        private (double damageMultiplier, double defDamageMultiplier) GetElementalMultiplier(string itemElement, string enemyElement)
        {
            if ((itemElement == "light" && enemyElement == "dark") ||
                (itemElement == "nature" && enemyElement == "earth") ||
                (itemElement == "water" && enemyElement == "fire") ||
                (itemElement == "fire" && enemyElement == "nature") ||
                (itemElement == "magic" && enemyElement == "curse") ||
                (itemElement == "curse" && (enemyElement == "magic" || enemyElement == "nature")))
            {
                return (1.2, 1.2); // +20% DMG and +20% Def DMG
            }
            else if ((itemElement == "dark" && enemyElement == "light") ||
                     (itemElement == "fire" && enemyElement == "water") ||
                     (itemElement == "nature" && enemyElement == "fire"))
            {
                return (0.9, 1.0); // -10% DMG, no change to Def DMG
            }

            return (1.0, 1.0); // No change
        }

        private async void ApplySkillEffect(int enemyIndex, int charIndex)
        {
            var (targetEnemy, enemyHpBar, enemyDefBar) = GetEnemyComponents(enemyIndex);
            if (targetEnemy == null || enemyHpBar == null || enemyDefBar == null) return;

            // Get the player components (unit, HP bar)
            var (targetPlayer, playerHpBar) = GetCharacterComponents(charIndex);
            if (targetPlayer == null || playerHpBar == null) return;


            // Skip attack if the character is a healer
            if (charHeal[charIndex] > 1)
            {
                HealOtherUnits(charIndex);
                return;
            }

            // Skip attack if the enemy is dead
            if (isEnemyDead[enemyIndex] || enemyHpBar.Value <= 0)
            {
                Console.WriteLine($"Enemy {enemyIndex + 1} is dead, cannot be attacked.");
                return;
            }

            // Enemy element
            string enemyElement = enemElem[combatLevel - 1][enemyIndex];

            // Initialize variables for item stats
            int itemBonusAtk = 0;
            string itemElement = "neutral"; // Default to "neutral" if no item is equipped

            try
            {
                Con.Connection();
                Con.Con.Open();

                string query = "SELECT itemNo FROM CharTbl WHERE charNo = @charNo";
                SqlCommand cmd = new SqlCommand(query, Con.Con);
                cmd.Parameters.AddWithValue("@charNo", charIndex);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    int itemNo = Convert.ToInt32(result);
                    if (itemNo >= 0 && itemNo < iATK.Length)
                    {
                        itemBonusAtk = iATK[itemNo];
                        itemElement = iEle[itemNo]; // Get the item's element
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching item data: {ex.Message}");
            }
            finally
            {
                Con.Con.Close();
            }

            // Get the damage multipliers based on the item's element
            var (damageMultiplier, defDamageMultiplier) = GetElementalMultiplier(itemElement, enemyElement);

            // Base stats
            int baseAttack = charAtk[charIndex];
            int totalAttack = baseAttack + itemBonusAtk;
            int damage = (int)(totalAttack * damageMultiplier);
            int defDamage = (int)(totalAttack * defDamageMultiplier);

            // Apply the effect image on the target enemy
            PictureBox effectPictureBox = GetEffectPictureBox(enemyIndex);
            if (effectPictureBox != null)
            {
                effectPictureBox.BackColor = Color.Transparent;
                effectPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                effectPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(charEffImg[charIndex]);
                effectPictureBox.Visible = true;

                // Play effect sound
                PlayCharEffSound(charIndex);

                // Timer to hide the effect after 1 second
                Timer effectTimer = new Timer { Interval = 1000 };
                effectTimer.Tick += (s, args) =>
                {
                    effectPictureBox.Visible = false;
                    effectTimer.Stop();

                    // Stop effect sound when the effect hides
                    StopCharEffSound();
                };
                effectTimer.Start();
            }

            // Deal damage to the enemy's Defense and HP bars
            if (enemyDefBar.Value > 0)
            {
                enemyDefBar.Value = Math.Max(enemyDefBar.Value - defDamage, 0);

                // If Defense Bar reaches 0, deal additional damage to HP
                if (enemyDefBar.Value == 0)
                {
                    int additionalDamage = (int)(damage * 0.15); // 15% additional damage
                    enemyHpBar.Value = Math.Max(enemyHpBar.Value - (damage + additionalDamage), 0);
                    enemyDefBar.Value = enemyDefBar.Maximum; // Reset Defense Bar

                    // Show the total damage (including additional damage)
                    ShowDamageCount(damage + additionalDamage);
                }
                else
                {
                    // Show the regular damage
                    ShowDamageCount(damage);
                }
            }
            else
            {
                // Directly apply damage to HP Bar if Defense Bar is already 0
                enemyHpBar.Value = Math.Max(enemyHpBar.Value - damage, 0);
                ShowDamageCount(damage);
            }

            // Check if the enemy's HP is 0 and hide the enemy and its related controls
            if (enemyHpBar.Value <= 0)
            {
                targetEnemy.Image = (Image)Properties.Resources.ResourceManager.GetObject(enemDeathImg[combatLevel - 1][enemyIndex]);
                await Task.Delay(1000);

                // Hide enemy and its controls
                targetEnemy.Visible = false;
                enemyHpBar.Visible = false;
                enemyDefBar.Visible = false;
                

                // Mark the enemy as "dead"
                isEnemyDead[enemyIndex] = true;
            }

            // Update the labels after modifying the HP
            UpdateEnemyHpLabels();

            // Check if the player's HP is 0 and hide the player and its related controls
            if (playerHpBar.Value <= 0)
            {
                targetPlayer.Image = (Image)Properties.Resources.ResourceManager.GetObject(charDeathImg[charIndex]);

                // Hide player and its controls
                targetPlayer.Visible = false;
                playerHpBar.Visible = false;

                // Mark the player as "dead" (could be done with a boolean array or similar)
                isPlayerUnitDead[charIndex] = true;
            }
            if (AreAllEnemiesDead())
            {
                await Task.Delay(1000); // Optional delay before ending combat
                EndCombat(); // End combat if all enemies are dead
                return; // Prevent further action
            }

            UpdateProgressBarColor(playerHpBar, isPlayerUnit: true);
            UpdateProgressBarColor(enemyHpBar, isPlayerUnit: false);
            UpdateHpBars();

            Console.WriteLine($"Dealt Damage: {damage}, Remaining HP: {enemyHpBar.Value}/{enemyHpBar.Maximum}");

        }

        private async void ApplyEnemyEffect(int enemyIndex, int charIndex)
        {
            // Get the player components (unit, HP bar)
            var (targetPlayer, playerHpBar) = GetCharacterComponents(charIndex);
            if (targetPlayer == null || playerHpBar == null) return;

            // Enemy components
            var (targetEnemy, enemyHpBar, enemyDefBar) = GetEnemyComponents(enemyIndex);
            if (targetEnemy == null || enemyHpBar == null || enemyDefBar == null) return;


            // Skip attack if the player unit is dead
            if (isPlayerUnitDead[charIndex] || playerHpBar.Value <= 0)
            {
                Console.WriteLine($"Player Unit {charIndex + 1} is dead, cannot be attacked.");
                return; // Skip applying effect if the player unit is already dead
            }

            // Apply the effect image on the target player
            PictureBox effectPictureBox = GetEffectPictureBox(charIndex);
            if (effectPictureBox != null)
            {
                effectPictureBox.BackColor = Color.Transparent;
                effectPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                effectPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(enemEffImg[combatLevel - 1][enemyIndex]);
                effectPictureBox.Visible = true;

                // Play effect sound for enemy attack
                //PlayEnemyEffSound(enemyIndex);

                // Timer to hide the effect after 2 seconds
                Timer effectTimer = new Timer { Interval = 500 }; // Changed to 2000ms for consistency
                effectTimer.Tick += (s, args) =>
                {
                    effectPictureBox.Visible = false;
                    effectTimer.Stop();

                    // Stop effect sound when the effect hides
                    StopEnemyEffSound();
                };
                effectTimer.Start();
            }

            // Deal damage to the player's HP
            int damage = enemAtk[combatLevel - 1][enemyIndex]; // Get enemy's attack value

            // Reduce the player's HP
            charHp[charIndex] = Math.Max(0, charHp[charIndex] - damage);  // Update charHp first

            // Update the ProgressBar to reflect the new HP value
            playerHpBar.Value = Math.Max(playerHpBar.Minimum, charHp[charIndex]);

            // Show the animated damage count for the damage dealt by the enemy
            ShowDamageCountForEnemy(damage);

            // Check if the player's HP is 0 and hide the player and its related controls
            if (playerHpBar.Value <= 0)
            {
                targetPlayer.Image = (Image)Properties.Resources.ResourceManager.GetObject(charDeathImg[charIndex]);

                // Hide player and its controls
                targetPlayer.Visible = false;
                playerHpBar.Visible = false;

                // Mark the player as "dead" (could be done with a boolean array or similar)
                isPlayerUnitDead[charIndex] = true;
            }


            // Check if the enemy's HP is 0 and hide the enemy and its related controls
            if (enemyHpBar.Value <= 0)
            {
                targetEnemy.Image = (Image)Properties.Resources.ResourceManager.GetObject(enemDeathImg[combatLevel - 1][enemyIndex]);
                await Task.Delay(1000);

                // Hide enemy and its controls
                targetEnemy.Visible = false;
                enemyHpBar.Visible = false;
                enemyDefBar.Visible = false;

                // Mark the enemy as "dead"
                isEnemyDead[enemyIndex] = true;
            }

            if (AreAllPlayersDead())
            {
                EndCombat(); // End combat if all player units are dead
                return; // Exit the method to prevent any further actions
            }
            // Update the labels after modifying the HP
            UpdateEnemyHpLabels();

            UpdateProgressBarColor(playerHpBar, isPlayerUnit: true);
            UpdateProgressBarColor(enemyHpBar, isPlayerUnit: false);
            UpdateHpBars();
        }
        private void HealOtherUnits(int healerIndex)
        {
            var (targetPlayer, playerHpBar) = GetCharacterComponents(charIndex);
            if (targetPlayer == null || playerHpBar == null) return;


            bool allFullHp = true;
            bool othersFullHp = true;

            for (int i = 0; i < charHp.Length; i++)
            {
                if (i != healerIndex) // Skip healer itself for now
                {
                    var (unit, healthBar) = GetCharacterComponents(i);
                    if (unit != null && healthBar != null)
                    {
                        if (healthBar.Value < healthBar.Maximum)
                        {
                            othersFullHp = false;
                            allFullHp = false;

                            // Heal this unit
                            int newHp = Math.Min(healthBar.Value + charHeal[healerIndex], healthBar.Maximum);
                            healthBar.Value = newHp;
                        }
                    }
                }
                else
                {
                    // Check healer's HP
                    var (healerUnit, healerHealthBar) = GetCharacterComponents(i);
                    if (healerUnit != null && healerHealthBar != null)
                    {
                        if (healerHealthBar.Value < healerHealthBar.Maximum)
                            allFullHp = false;
                    }
                }
            }

            if (othersFullHp)
            {
                // Heal self if all others have full HP
                var (healerUnit, healerHealthBar) = GetCharacterComponents(healerIndex);
                if (healerUnit != null && healerHealthBar != null)
                {
                    int newHp = Math.Min(healerHealthBar.Value + charHeal[healerIndex], healerHealthBar.Maximum);
                    healerHealthBar.Value = newHp;
                }
            }

            if (allFullHp)
            {
                // Convert heal into damage to the enemy
                int enemyIndex = GetRandomAliveEnemy(); // A method or logic to pick an enemy to target
                if (enemyIndex >= 0)
                {
                    var (targetEnemy, enemyHpBar, enemyDefBar) = GetEnemyComponents(enemyIndex);
                    if (targetEnemy != null && enemyHpBar != null && enemyDefBar != null)
                    {
                        int damage = charHeal[healerIndex];
                        if (enemyDefBar.Value > 0)
                        {
                            enemyDefBar.Value = Math.Max(enemyDefBar.Value - damage, 0);
                            if (enemyDefBar.Value == 0)
                            {
                                int additionalDamage = (int)(damage * 0.15);
                                enemyHpBar.Value = Math.Max(enemyHpBar.Value - additionalDamage, 0);
                                enemyDefBar.Value = enemyDefBar.Maximum; // Reset Defense Bar
                            }
                        }
                        else
                        {
                            enemyHpBar.Value = Math.Max(enemyHpBar.Value - damage, 0);
                        }
                        // Display effect using effectPictureBox
                        PictureBox effectPictureBox = GetEffectPictureBox(enemyIndex);
                        if (effectPictureBox != null)
                        {
                            effectPictureBox.BackColor = Color.Transparent;
                            effectPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            effectPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(charEffImg[healerIndex]);
                            effectPictureBox.Visible = true;

                            // Play effect sound
                            PlayCharEffSound(healerIndex);

                            // Timer to hide the effect after 1 second
                            Timer effectTimer = new Timer { Interval = 1000 };
                            effectTimer.Tick += (s, args) =>
                            {
                                effectPictureBox.Visible = false;
                                effectTimer.Stop();

                                // Stop effect sound when the effect hides
                                StopCharEffSound();
                            };
                            effectTimer.Start();
                        }

                        UpdateProgressBarColor(enemyHpBar, isPlayerUnit: false);

                    }
                }
            }

            UpdateProgressBarColor(playerHpBar, isPlayerUnit: true);
            UpdateHpBars();
        }
        // Play the effect sound based on character index
        private void PlayCharEffSound(int charIndex)
        {
            string soundName = charEffSound[charIndex];
            var soundResource = (System.IO.UnmanagedMemoryStream)Properties.Resources.ResourceManager.GetObject(soundName);
            charEffSoundPlayer = new SoundPlayer(soundResource);
            charEffSoundPlayer.Play(); // Play the sound once
        }
        // Stop the effect sound
        private void StopCharEffSound()
        {
            if (charEffSoundPlayer != null)
            {
                charEffSoundPlayer.Stop();
                charEffSoundPlayer.Dispose(); // Dispose the sound player to release resources
                charEffSoundPlayer = null;
            }
        }
        private void PlayEnemyEffSound(int enemyIndex)
        {

            // Retrieve the sound name for the specific enemy
            string soundName = enemEffSound[enemyIndex][0];

            try
            {
                // Load and play the sound from resources
                Stream audioStream = Properties.Resources.ResourceManager.GetStream(soundName);
                if (audioStream != null)
                {
                    enemyEffSoundPlayer = new SoundPlayer(audioStream);
                    enemyEffSoundPlayer.Play();
                }
                else
                {
                    MessageBox.Show($"Sound resource '{soundName}' not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing enemy sound: {ex.Message}");
            }
        }
        private void StopEnemyEffSound()
        {
            if (enemyEffSoundPlayer != null)
            {
                enemyEffSoundPlayer.Stop();
                enemyEffSoundPlayer.Dispose(); // Dispose the sound player to release resources
                enemyEffSoundPlayer = null;
            }
        }

        // Helper method to get the correct enemy components
        private (PictureBox, ProgressBar, ProgressBar) GetEnemyComponents(int enemyIndex)
        {
            switch (enemyIndex)
            {
                case 0:
                    return (eUnit1, eUnit1Hp, eUnit1Def);
                case 1:
                    return (eUnit2, eUnit2Hp, eUnit2Def);
                case 2:
                    return (eUnit3, eUnit3Hp, eUnit3Def);
                default:
                    return (null, null, null);
            }
        }

        private (PictureBox, ProgressBar) GetCharacterComponents(int charIndex)
        {
            switch (charIndex)
            {
                case 0:
                    return (pUnit1, pUnit1Hp);
                case 1:
                    return (pUnit2, pUnit2Hp);
                case 2:
                    return (pUnit3, pUnit3Hp);
                default:
                    return (null, null);
            }
        }

        // Helper method to get the correct effect PictureBox
        private PictureBox GetEffectPictureBox(int enemyIndex)
        {
            switch (enemyIndex)
            {
                case 0:
                    return e1HitEff;
                case 1:
                    return e2HitEff;
                case 2:
                    return e3HitEff;
                default:
                    return null;
            }
        }

        private void LoadUnitItems()
        {
            // Database connection
            try
            {
                Con.Connection();
                Con.Con.Open();

                string query = "SELECT itemNo FROM CharTbl ORDER BY charNo ASC"; // Assumes charNo determines order
                SqlCommand cmd = new SqlCommand(query, Con.Con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int index = 0; // To track PictureBox assignment
                    PictureBox[] unitItems = { unitItem1, unitItem2, unitItem3 };

                    while (reader.Read() && index < unitItems.Length)
                    {
                        object itemNoObj = reader["itemNo"];
                        PictureBox currentBox = unitItems[index];

                        if (itemNoObj == DBNull.Value)
                        {
                            // Set noitemicon if the value is NULL
                            currentBox.Image = Properties.Resources.noitemicon;
                        }
                        else
                        {
                            int itemNo = Convert.ToInt32(itemNoObj); // Get the itemNo from the database

                            // Ensure itemNo is within the bounds of iImg array
                            if (itemNo >= 0 && itemNo < iImg.Length)
                            {
                                string imgName = iImg[itemNo];
                                var imgObj = Properties.Resources.ResourceManager.GetObject(imgName);

                                if (imgObj != null)
                                {
                                    currentBox.Image = (Image)imgObj;
                                }
                                else
                                {
                                    currentBox.Image = Properties.Resources.noitemicon; // Fallback to noitemicon
                                }
                            }
                            else
                            {
                                currentBox.Image = Properties.Resources.noitemicon; // Fallback to noitemicon if itemNo is out of bounds
                            }
                        }

                        currentBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        index++; // Move to the next PictureBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading unit items: {ex.Message}");
            }
            finally
            {
                Con.Con.Close();
            }
        }


        //Turn Settings ======================================================================================================================
        private bool[] isSkillUsed = new bool[3]; // Track if skills for units 1, 2, and 3 have been used

        private void StartTurn()
        {
            if (playerTurn)
            {
                // Skip dead player units
                while (playerTurn && isPlayerUnitDead[currentTurnIndex])
                {
                    currentTurnIndex++;
                    if (currentTurnIndex >= totalPlayerUnits)
                    {
                        playerTurn = false;
                    }
                }

                // Display player's turn actions (e.g., enable skill buttons)
                if (playerTurn)
                {
                    eTurnIcon.Visible = false;
                    EnablePlayerTurn();
                }
                else
                {
                    // Enemy's turn if all player units are dead or turns are completed
                    EnemyTurn();
                }
            }
            else
            {
                // Enemy's turn
                EnemyTurn();
            }
        }
        private void EnablePlayerTurn()
        {
            // Show all skill buttons for the player's turn, if the unit is alive
            if (!isPlayerUnitDead[0]) pUnit1Skill.Visible = true;
            if (!isPlayerUnitDead[1]) pUnit2Skill.Visible = true;
            if (!isPlayerUnitDead[2]) pUnit3Skill.Visible = true;

        }
        private void EnemyTurn()
        {
            // Hide all skill buttons during the enemy's turn
            pUnit1Skill.Visible = false;
            pUnit2Skill.Visible = false;
            pUnit3Skill.Visible = false;

            // Calculate the enemy index based on currentTurnIndex and total player units
            int enemyIndex = currentTurnIndex - totalPlayerUnits;

            // Skip the turn if the enemy is dead
            if (isEnemyDead[enemyIndex])
            {
                NextTurn(); // Skip to the next turn if the enemy is dead
                return;
            }

            // Check if all player units are dead before proceeding
            if (AreAllPlayersDead())
            {
                EndCombat(); // End combat if all player units are dead
                return; // Exit the method to prevent any further actions
            }

            // Set the turn icon to the enemy's idle image
            eTurnIcon.Visible = true;
            eTurnIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            eTurnIcon.Image = (Image)Properties.Resources.ResourceManager.GetObject(enemIconImg[combatLevel - 1][enemyIndex]);

            // Display the attack image for the enemy
            PictureBox targetEnemy = GetEnemyUnitPictureBox(enemyIndex);
            targetEnemy.Image = (Image)Properties.Resources.ResourceManager.GetObject(enemAtkImg[combatLevel - 1][enemyIndex]);

            // Wait for a short delay before applying the enemy's attack and resetting to idle image
            Timer enemyAttackTimer = new Timer { Interval = 3000 }; // 1-second delay for the enemy attack
            enemyAttackTimer.Tick += async (s, args) =>
            {
                enemyAttackTimer.Stop();

                // Apply the effect to a random player unit
                int targetPlayerIndex = GetRandomAlivePlayer();
                if (targetPlayerIndex != -1)
                {
                    ApplyEnemyEffect(enemyIndex, targetPlayerIndex);
                }

                // Check if all player units are dead after the attack
                if (AreAllPlayersDead())
                {
                    await Task.Delay(1000); // Optional delay before ending combat
                    EndCombat(); // End combat if all player units are dead
                    return;
                }

                // Reset the enemy's image to idle
                targetEnemy.Image = (Image)Properties.Resources.ResourceManager.GetObject(enemIdleImg[combatLevel - 1][enemyIndex]);

                if (AreAllPlayersDead())
                {
                    await Task.Delay(1000); // Optional delay before ending combat
                    EndCombat(); // End combat if all player units are dead
                    return; // Prevent further action
                }

                // Move to the next turn (back to the player)
                await Task.Delay(500); // Short delay before switching back to the player's turn
                NextTurn();
            };
            enemyAttackTimer.Start();
        }

        // You need to implement this method to return a random index of an alive player unit
        private int GetRandomAlivePlayer()
        {
            List<int> alivePlayers = new List<int>();
            for (int i = 0; i < totalPlayerUnits; i++)
            {
                if (!isPlayerUnitDead[i]) // Check if the player unit is alive
                {
                    alivePlayers.Add(i);
                }
            }

            if (alivePlayers.Count > 0)
            {
                return alivePlayers[random.Next(alivePlayers.Count)]; // Return a random alive player index
            }

            return -1; // No alive players
        }

        private bool AreAllPlayersDead()
        {
            foreach (bool isDead in isPlayerUnitDead)
            {
                if (!isDead) return false; // If at least one player is alive, return false
            }
            return true; // All players are dead
        }
        private bool AreAllEnemiesDead()
        {
            foreach (bool isDead in isEnemyDead)
            {
                if (!isDead) return false;
            }
            return true; // All enemies are dead
        }

        private void ApplyEnemyAttackToRandomPlayer(int enemyIndex)
        {
            // Select a random player unit (0 to totalPlayerUnits - 1)
            int targetPlayerIndex = random.Next(0, totalPlayerUnits);

            // Apply damage to the selected player unit
            int damage = enemAtk[combatLevel - 1][enemyIndex];
            charHp[targetPlayerIndex] -= damage;

            // Update the health display of the targeted player unit (e.g., update ProgressBar, label, etc.)
            UpdatePlayerHealthDisplay(targetPlayerIndex);
        }

        private void UpdatePlayerHealthDisplay(int playerIndex)
        {
            // Implement the logic to update the health display of the player unit
            // Example: Update the ProgressBar or label to show the new health value
            switch (playerIndex)
            {
                case 0:
                    // Update health display for player unit 1
                    pUnit1Hp.Value = Math.Max(0, charHp[playerIndex]); // Assuming 'pUnit1Hp' is a ProgressBar
                    if (pUnit1Hp.Value <= 0)
                    {
                        HandlePlayerUnitDeath(0);
                    }
                    break;
                case 1:
                    // Update health display for player unit 2
                    pUnit2Hp.Value = Math.Max(0, charHp[playerIndex]);
                    if (pUnit2Hp.Value <= 0)
                    {
                        HandlePlayerUnitDeath(1);
                    }
                    break;
                case 2:
                    // Update health display for player unit 3
                    pUnit3Hp.Value = Math.Max(0, charHp[playerIndex]);
                    if (pUnit3Hp.Value <= 0)
                    {
                        HandlePlayerUnitDeath(2);
                    }
                    break;
            }


            // Add more code if there are additional visual updates needed (e.g., changing unit's image when HP <= 0)
        }
        private void HandlePlayerUnitDeath(int playerIndex)
        {
            // Hide the player's unit controls: HP bar, skill button, and unit image
            switch (playerIndex)
            {
                case 0:
                    pUnit1Hp.Visible = false;
                    pUnit1Skill.Visible = false;
                    pUnit1.Visible = false;
                    break;
                case 1:
                    pUnit2Hp.Visible = false;
                    pUnit2Skill.Visible = false;
                    pUnit2.Visible = false;
                    break;
                case 2:
                    pUnit3Hp.Visible = false;
                    pUnit3Skill.Visible = false;
                    pUnit3.Visible = false;
                    break;
            }

            // Optional: Log or show a message that the player unit has been defeated
            Console.WriteLine($"Player Unit {playerIndex + 1} has been defeated.");

            // Optional: Mark the player unit as "dead" to skip their turn
            isPlayerUnitDead[playerIndex] = true;

            //// Check if all player units are dead to end the combat
            //if (AllPlayerUnitsDead())
            //{
            //    EndCombat();
            //}
        }
        private bool[] isPlayerUnitDead = new bool[3]; // Track if player units 1, 2, and 3 are dead


        private PictureBox GetEnemyUnitPictureBox(int enemyIndex)
        {
            // Returns the corresponding PictureBox for the enemy based on its index
            switch (enemyIndex)
            {
                case 0:
                    return eUnit1;
                case 1:
                    return eUnit2;
                case 2:
                    return eUnit3;
                default:
                    return null;
            }
        }
        private void NextTurn()
        {
            // Move to the next turn
            currentTurnIndex++;

            // Check if all turns (player and enemies) are complete
            if (currentTurnIndex >= totalPlayerUnits + 3) // Assuming 3 enemies
            {
                currentTurnIndex = 0; // Reset the turn index for a new round
                //ResetSkillButtons(); // Reset skill buttons after the full turn cycle
            }

            // Determine if it's a player's turn or an enemy's turn
            playerTurn = currentTurnIndex < totalPlayerUnits;

            // Use a timer to introduce a delay before starting the enemy's turn
            if (!playerTurn)
            {
                Timer enemyTurnTimer = new Timer { Interval = 1000 }; // 500ms delay before enemy's turn
                enemyTurnTimer.Tick += (s, args) =>
                {
                    StartTurn(); // Start the enemy's turn
                    enemyTurnTimer.Stop();
                };
                enemyTurnTimer.Start();
            }
            else
            {
                // Immediately start the player's turn
                StartTurn();
            }
        }
        // Call this method to start the combat round
        public void StartCombat()
        {
            LoadUnitItems();
            //Hide End Notification
            notifCombat.Visible = false;

            currentTurnIndex = 0; // Reset the turn index at the start of combat
            playerTurn = true; // Player's turn starts first
            // Reset enemy death status
            for (int i = 0; i < isEnemyDead.Length; i++)
            {
                isEnemyDead[i] = false;
            }
            StartTurn();
        }
        private async void EndCombat()
        {

            // Check if all player units are dead
            if (AreAllPlayersDead())
            {
                // Set notification image to 'lvlFailedImg'
                notifCombat.Image = (Image)Properties.Resources.ResourceManager.GetObject("LFailedNotif");
                notifCombat.BackgroundImageLayout = ImageLayout.Stretch;
                notifCombat.BringToFront();
                notifCombat.Visible = true;

                // Delay to allow the notification to be visible for 3 seconds
                await Task.Delay(3000);

                notifCombat.Visible = false;

                // Open the failed form
                OpenFailedForm();
                return;
            }
            else
            {
                notifCombat.Image = (Image)Properties.Resources.ResourceManager.GetObject("LClearNotif");
                notifCombat.BackgroundImageLayout = ImageLayout.Stretch;
                // Display the notification PictureBox for level completion (optional)
                notifCombat.BringToFront();
                notifCombat.Visible = true;

                // Delay to allow the notification to be visible for 3 seconds
                await Task.Delay(4000);

                notifCombat.Visible = false;

                // Open the Level form
                OpenLevelForm();
            }

            //// Display the notification PictureBox for level completion (optional)
            //notifCombat.BringToFront();
            //notifCombat.Visible = true;

            //// Delay to allow the notification to be visible for 3 seconds
            //await Task.Delay(3000);

            //notifCombat.Visible = false;

            //// Open the Level form
            //OpenLevelForm();
        }

        // End Combat to Level Form
        private void OpenFailedForm()
        {
            // Pass the extracted level number to the Level form
            Map levelForm = new Map();
            levelForm.Show();
            this.Hide();
        }
        private void OpenLevelForm()
        {
            //Level levelForm = new Level();
            //levelForm.SetLevelNumber(selectedLevel); // Pass the level value
            //levelForm.Show(); // Show the Level form
            //this.Hide(); // Hide the Combat form

            // Extract the level number from the levelCombat label
            string levelText = levelCombat.Text;
            int levelNumber = 0;

            if (levelText.StartsWith("Level") && levelText.Contains("Combat"))
            {
                // Parse the number between "Level" and "Combat"
                string levelStr = levelText.Substring(6, levelText.IndexOf("Combat") - 7).Trim();
                int.TryParse(levelStr, out levelNumber);
            }

            Loading load = new Loading();
            load.Show();
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Hide();
                    load.Hide();
                    // Pass the extracted level number to the Level form
                    Level levelForm = new Level();
                    levelForm.SetLevelNumber(levelNumber);
                    levelForm.Show();
                });
            });
        }

        private void IncrementLevelClear()
        {
            try
            {
                Con.Connection();
                {
                    // Open the database connection
                    
                    Con.Con.Open();
                    string query = "UPDATE LevelTbl SET lvlClear = lvlClear + 1 WHERE levelNo = @levelNo";
                    SqlCommand command = new SqlCommand(query, Con.Con);

                    // Assuming 'combatLevel' represents the current level being cleared
                    command.Parameters.AddWithValue("@levelNo", combatLevel);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Level clear status updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No rows affected, check if the level exists in the table.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the database: " + ex.Message);
            }
        }
        // Check if all skills have been used
        private bool AllSkillsUsed()
        {
            foreach (bool skillUsed in isSkillUsed)
            {
                if (!skillUsed) return false; // If any skill has not been used, return false
            }
            return true; // All skills have been used
        }

        //Dmage Counter ====================================================================
        private Timer dmgCountTimer;
        private int currentDisplayedDamage = 0;
        private int totalDamage = 0;
        private int incrementStep = 100; // You can adjust this step size to make counting faster/slower

        private void ShowDamageCount(int damage)
        {
            totalDamage = damage;
            currentDisplayedDamage = 0;
            dmgCount.Text = "0"; // Reset the damage count display
            dmgCount.Visible = true; // Make sure the label is visible

            // Initialize the timer
            if (dmgCountTimer == null)
            {
                dmgCountTimer = new Timer();
                dmgCountTimer.Interval = 75; // Adjust interval as needed (faster counting)
                dmgCountTimer.Tick += DmgCountTimer_Tick;
            }

            dmgCountTimer.Start(); // Start counting
        }

        private void DmgCountTimer_Tick(object sender, EventArgs e)
        {
            // Increment the displayed damage
            currentDisplayedDamage += incrementStep;

            // If the current displayed damage exceeds or equals the total damage, set it to total
            if (currentDisplayedDamage >= totalDamage)
            {
                currentDisplayedDamage = totalDamage;
                dmgCountTimer.Stop(); // Stop the timer once we reach the total damage
            }

            // Update the label text
            dmgCount.Text = currentDisplayedDamage.ToString();
        }

        private Timer enemyDmgCountTimer;
        private int currentEnemyDisplayedDamage = 0;
        private int totalEnemyDamage = 0;
        private int enemyIncrementStep = 300; // You can adjust this step size to make counting faster/slower

        private void ShowDamageCountForEnemy(int damage)
        {
            totalEnemyDamage = damage;
            currentEnemyDisplayedDamage = 0;
            dmgCount.Text = "0"; // Reset the damage count display
            dmgCount.Visible = true; // Make sure the label is visible

            // Initialize the timer for enemy damage counting
            if (enemyDmgCountTimer == null)
            {
                enemyDmgCountTimer = new Timer();
                enemyDmgCountTimer.Interval = 50; // Adjust interval as needed (faster counting)
                enemyDmgCountTimer.Tick += EnemyDmgCountTimer_Tick;
            }

            enemyDmgCountTimer.Start(); // Start counting
        }

        private void EnemyDmgCountTimer_Tick(object sender, EventArgs e)
        {
            // Increment the displayed damage
            currentEnemyDisplayedDamage += enemyIncrementStep;

            // If the current displayed damage exceeds or equals the total damage, set it to total
            if (currentEnemyDisplayedDamage >= totalEnemyDamage)
            {
                currentEnemyDisplayedDamage = totalEnemyDamage;
                enemyDmgCountTimer.Stop(); // Stop the timer once we reach the total damage
            }

            // Update the label text
            dmgCount.Text = currentEnemyDisplayedDamage.ToString();

        }


        // COLOR CHANGE =====================================================================================================================================================
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const uint PBM_SETSTATE = 0x0410; // Message to set ProgressBar state
        private const int PBST_NORMAL = 1;       // Default (green for most themes)
        private const int PBST_ERROR = 2;        // Red
        private const int PBST_PAUSED = 3;       // Yellow/Orange
        private void UpdateProgressBarColor(ProgressBar progressBar, bool isPlayerUnit)
        {
            if (progressBar.Value <= 0) return; // No need to update for zero values.

            float percentage = (float)progressBar.Value / progressBar.Maximum;

            int state;
            if (percentage >= 0.5f)
                state = isPlayerUnit ? PBST_NORMAL : PBST_NORMAL; // Green (player) or Blue (enemy)
            else if (percentage >= 0.2f)
                state = PBST_PAUSED; // Orange
            else
                state = PBST_ERROR; // Red

            // Apply the color state using SendMessage
            SendMessage(progressBar.Handle, PBM_SETSTATE, (IntPtr)state, IntPtr.Zero);
        }

        private void UpdateHpBars()
        {
            // Player Units
            UpdateProgressBarColor(pUnit1Hp, isPlayerUnit: true);
            UpdateProgressBarColor(pUnit2Hp, isPlayerUnit: true);
            UpdateProgressBarColor(pUnit3Hp, isPlayerUnit: true);

            // Enemy Units
            UpdateProgressBarColor(eUnit1Hp, isPlayerUnit: false);
            UpdateProgressBarColor(eUnit2Hp, isPlayerUnit: false);
            UpdateProgressBarColor(eUnit3Hp, isPlayerUnit: false);
        }


        // LABEL HP

        private void UpdateEnemyHpLabels()
        {
            //e1HpLabel.Text = $"HP: {eUnit1Hp}";
            //e2HpLabel.Text = $"HP: {eUnit2Hp}";
            //e3HpLabel.Text = $"HP: {eUnit3Hp}";
            e1HpLabel.Text = $"HP: {eUnit1Hp.Value}/{eUnit1Hp.Maximum}";
            e2HpLabel.Text = $"HP: {eUnit2Hp.Value}/{eUnit2Hp.Maximum}";
            e3HpLabel.Text = $"HP: {eUnit3Hp.Value}/{eUnit3Hp.Maximum}";
        }
    }
}
