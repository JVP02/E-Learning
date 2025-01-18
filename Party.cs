using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TheGameProject
{
    public partial class Party : Form
    {
        private Rectangle backMapBtnRec;
        private Rectangle originalFormSize;
        private Rectangle partyBGRec;
        private Rectangle savePartyBtnRec, NamelblRec, HPlblRec, ATKlblRec, HEALlblRec;

        private Rectangle charListFLPRec;
        private Rectangle char1Rec;
        private Rectangle char2Rec;
        private Rectangle char3Rec;

        string[] charIconImg = SharedArray.charIconImg;
        string[] charIdleImg = SharedArray.charIdleImg;
        string[] charName = SharedArray.charName;
        int[] charHp = SharedArray.charHp;
        int[] charAtk = SharedArray.charAtk;
        int[] charHeal = SharedArray.charHeal;
        string[] charSkill = SharedArray.charSkill;
        string[] charEle = SharedArray.charEle;

        // Database connection object
        DBConnection Con = new DBConnection();

        public Party()
        {
            InitializeComponent();
            DisplayCharacterImages();
            //InitializePartySlots();
        }

        private void Party_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);

            //partyBGRec = new Rectangle(partyBG.Location.X, partyBG.Location.Y, partyBG.Width, partyBG.Height);
            backMapBtnRec = new Rectangle(backMapBtn.Location.X, backMapBtn.Location.Y, backMapBtn.Width, backMapBtn.Height);
            savePartyBtnRec = new Rectangle(savePartyBtn.Location.X, savePartyBtn.Location.Y, savePartyBtn.Width, savePartyBtn.Height);
            NamelblRec = new Rectangle(Namelbl.Location.X, Namelbl.Location.Y, Namelbl.Width, Namelbl.Height);
            HPlblRec = new Rectangle(HPlbl.Location.X, HPlbl.Location.Y, HPlbl.Width, HPlbl.Height);
            ATKlblRec = new Rectangle(ATKlbl.Location.X, ATKlbl.Location.Y, ATKlbl.Width, ATKlbl.Height);
            HEALlblRec = new Rectangle(HEALlbl.Location.X, HEALlbl.Location.Y, HEALlbl.Width, HEALlbl.Height);

            charListFLPRec = new Rectangle(charListFLP.Location.X, charListFLP.Location.Y, charListFLP.Width, charListFLP.Height);
            char1Rec = new Rectangle(char1.Location.X, char1.Location.Y, char1.Width, char1.Height);
            char2Rec = new Rectangle(char2.Location.X, char2.Location.Y, char2.Width, char2.Height);
            char3Rec = new Rectangle(char3.Location.X, char3.Location.Y, char3.Width, char3.Height);

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadSavedPartyData();

            backMapBtn.Image = Properties.Resources.BackIcon;
            backMapBtn.SizeMode = PictureBoxSizeMode.StretchImage;

            savePartyBtn.Image = Properties.Resources.SaveIcon;
            savePartyBtn.SizeMode = PictureBoxSizeMode.StretchImage;

            char1.DoubleClick += PartyChar_DoubleClick;
            char2.DoubleClick += PartyChar_DoubleClick;
            char3.DoubleClick += PartyChar_DoubleClick;

            char1.Click += CharacterPictureBox_Click;
            char2.Click += CharacterPictureBox_Click;
            char3.Click += CharacterPictureBox_Click;

            // Preselect the first valid slot index after loading data
            SelectFirstAvailableCharacter();
        }
        private void SelectFirstAvailableCharacter()
        {
            if (char1.Tag != null)
            {
                CharacterPictureBox_Click(char1, EventArgs.Empty);
            }
            else if (char2.Tag != null)
            {
                CharacterPictureBox_Click(char2, EventArgs.Empty);
            }
            else if (char3.Tag != null)
            {
                CharacterPictureBox_Click(char3, EventArgs.Empty);
            }
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

        private void Party_Resize(object sender, EventArgs e)
        {
            resizeControl(backMapBtnRec, backMapBtn);
            //resizeControl(partyBGRec, partyBG);
            resizeControl(charListFLPRec, charListFLP);
            resizeControl(savePartyBtnRec, savePartyBtn);
            resizeControl(NamelblRec, Namelbl);
            resizeControl(HPlblRec, HPlbl);
            resizeControl(ATKlblRec, ATKlbl);
            resizeControl(HEALlblRec, HEALlbl);

            resizeControl(char1Rec, char1);
            resizeControl(char2Rec, char2);
            resizeControl(char3Rec, char3);
        }

        private void backMapBtn_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            map.Show();
            this.Hide();
        }

        // Load PartySetup
        private void LoadSavedPartyData()
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

                    SetPartyCharacterImage(char1, party1Index);
                    SetPartyCharacterImage(char2, party2Index);
                    SetPartyCharacterImage(char3, party3Index);
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
                targetPictureBox.Image = (Image)Properties.Resources.charPlaceholder;
                targetPictureBox.Tag = null;
            }
        }

        private void DisplayCharacterImages()
        {
            try
            {
                Con.Connection();
                Con.Con.Open();

                SqlCommand cmd = new SqlCommand("SELECT charNo FROM CharTbl", Con.Con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int charNo = Convert.ToInt32(reader["charNo"]);
                    if (charNo >= 1 && charNo <= charIconImg.Length)
                    {
                        AddCharacterToFLP(charNo - 1);
                    }
                }

                reader.Close();
                Con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching character data: {ex.Message}");
            }
        }

        private void AddCharacterToFLP(int index)
        {
            PictureBox charPic = new PictureBox
            {
                Image = (Image)Properties.Resources.ResourceManager.GetObject(charIconImg[index]),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(75, 75),
                Tag = index
            };

            charPic.DoubleClick += CharPic_DoubleClick;
            charListFLP.Controls.Add(charPic);
        }

        private void CharPic_DoubleClick(object sender, EventArgs e)
        {
            PictureBox selectedChar = sender as PictureBox;
            if (selectedChar == null || selectedChar.Tag == null) return;

            int charIndex = (int)selectedChar.Tag;

            // Validation: Check if the character is already in the party
            if (IsCharacterInParty(charIndex))
            {
                MessageBox.Show("This character is already in your party!", "Duplicate Character", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Assign to the first available slot or overwrite char1 if all slots are occupied
            if (char1.Tag == null)
            {
                SetPartyCharacterImage(char1, charIndex);
            }
            else if (char2.Tag == null)
            {
                SetPartyCharacterImage(char2, charIndex);
            }
            else if (char3.Tag == null)
            {
                SetPartyCharacterImage(char3, charIndex);
            }
            else
            {
                SetPartyCharacterImage(char1, charIndex);
            }
        }
        // Remove Charracter to Party
        private void PartyChar_DoubleClick(object sender, EventArgs e)
        {
            PictureBox partySlot = sender as PictureBox;
            if (partySlot == null || partySlot.Tag == null) return;

            // Remove character from the party
            partySlot.Image = (Image)Properties.Resources.charPlaceholder;
            partySlot.Tag = null;
        }

        private void CharacterPictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag != null)
            {
                int charIndex = (int)pictureBox.Tag;

                // Display character data
                //lblCharacterData.Text = $"Name: {charNames[charIndex]}\n" +
                //                        $"HP: {charHP[charIndex]}\n" +
                //                        $"ATK: {charATK[charIndex]}\n" +
                //                        $"Description: {charDescriptions[charIndex]}";
                Namelbl.Text = $"Name: {charName[charIndex]}";
                HPlbl.Text = $"HP: {charHp[charIndex]}";
                ATKlbl.Text = $"ATK: {charAtk[charIndex]}";
                HEALlbl.Text = $"HEAL: {charHeal[charIndex]}";
            }
        }

        // Helper method to check if a character is already in the party
        private bool IsCharacterInParty(int charIndex)
        {
            return (char1.Tag != null && (int)char1.Tag == charIndex) ||
                   (char2.Tag != null && (int)char2.Tag == charIndex) ||
                   (char3.Tag != null && (int)char3.Tag == charIndex);
        }
        // Helper method to assign character image and tag to a party slot
        private void SetPartyCharacterImage(PictureBox partySlot, int charIndex)
        {
            partySlot.Image = (Image)Properties.Resources.ResourceManager.GetObject(charIdleImg[charIndex]); // Assign character image
            partySlot.Tag = charIndex; // Assign character index as tag
        }
        private void savePartyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int? index1 = char1.Tag as int?;
                int? index2 = char2.Tag as int?;
                int? index3 = char3.Tag as int?;

                if (index1 == null || index2 == null || index3 == null)
                {
                    MessageBox.Show("Please assign characters to all party slots before saving.");
                    return;
                }

                Con.Connection();
                Con.Con.Open();

                // Check if a row already exists in the database
                string checkQuery = "SELECT COUNT(*) FROM PartyTbl";
                SqlCommand checkCmd = new SqlCommand(checkQuery, Con.Con);
                int count = (int)checkCmd.ExecuteScalar();

                SqlCommand cmd;

                if (count == 0)
                {
                    // No rows exist, insert a new row
                    string insertQuery = "INSERT INTO PartyTbl (party1, party2, party3) VALUES (@party1, @party2, @party3)";
                    cmd = new SqlCommand(insertQuery, Con.Con);
                }
                else
                {
                    // Update existing data
                    string updateQuery = "UPDATE PartyTbl SET party1 = @party1, party2 = @party2, party3 = @party3";
                    cmd = new SqlCommand(updateQuery, Con.Con);
                }

                cmd.Parameters.AddWithValue("@party1", index1);
                cmd.Parameters.AddWithValue("@party2", index2);
                cmd.Parameters.AddWithValue("@party3", index3);

                cmd.ExecuteNonQuery();
                Con.Con.Close();

                //MessageBox.Show("Party saved successfully!");

                Loading load = new Loading();
                load.Show();
                Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(2000);
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Hide();
                        load.Hide();
                        Map map = new Map();
                        map.Show();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving party: {ex.Message}");
            }
        }
    }
}
