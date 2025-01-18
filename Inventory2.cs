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
    public partial class Inventory2 : Form
    {
        private Rectangle backInvRec;
        private Rectangle originalFormSize, itemListFLPRec, charListInvFLPRec, invUnitItemRec, invUnitImgRec, itemPrevRec, itemNameRec, itemDescRec, itemIconRec, skillDescRec;
        private Rectangle equipItemBtnRec, itemHptxtRec, itemAtktxtRec, itemHealtxtRec;


        string[] charIconImg = SharedArray.charIconImg;
        string[] charIdleImg = SharedArray.charIdleImg;
        string[] iImg = SharedArray.iImg;
        string[] irlImg = SharedArray.irlImg;
        string[] iName = SharedArray.iName;
        string[] iDesc = SharedArray.iDesc;
        int[] iHP = SharedArray.iHP;
        int[] iATK = SharedArray.iATK;
        string[] iEle = SharedArray.iEle;
        int[] iHB = SharedArray.iHB;

        private int selectedCharIndex = -1;
        private int selectedItemIndex = -1;

        // Database connection object
        DBConnection Con = new DBConnection();

        public Inventory2()
        {
            InitializeComponent();
            LoadItems();  
            LoadCharacters();
            PopulateItemList();
        }

        private void Inventory2_Load(object sender, EventArgs e)
        {
            InitializeRectangles();

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            backInvBtn.Image = Properties.Resources.BackIcon; // Replace <ImageName> with the actual resource image name
            // Set the SizeMode to properly fit the image
            backInvBtn.SizeMode = PictureBoxSizeMode.StretchImage; // Use Zoom to maintain aspect ratio and fit within the PictureBox

            equipItemBtn.Image = Properties.Resources.EquipIcon; // Replace <ImageName> with the actual resource image name
            equipItemBtn.SizeMode = PictureBoxSizeMode.StretchImage; // Use Zoom to maintain aspect ratio and fit within the PictureBox

            // Default to the first character (index 0)
            if (charIconImg.Length > 0)
            {
                selectedCharIndex = 0;
                DisplayCharacterData(selectedCharIndex); // Display character data
            }

            // Default to the first item (index 0)
            if (iImg.Length > 0)
            {
                selectedItemIndex = 0;
                DisplayItemData(selectedItemIndex); // Display item data
            }

        }
        private void DisplayCharacterData(int charIndex)
        {
            if (charIndex >= 0 && charIndex < charIconImg.Length)
            {
                selectedCharIndex = charIndex;
                invUnitImg.Image = (Image)Properties.Resources.ResourceManager.GetObject(charIdleImg[charIndex]);
                invUnitImg.SizeMode = PictureBoxSizeMode.StretchImage;

                // Load item icon for the selected character
                LoadItemIconForCharacter(charIndex);

            }
        }
        private void DisplayItemData(int itemIndex)
        {
            // Validate and store selected item index
            if (itemIndex >= 0 && itemIndex < iImg.Length)
            {
                selectedItemIndex = itemIndex;
                itemPrev.Image = (Image)Properties.Resources.ResourceManager.GetObject(iImg[itemIndex]);
                itemPrev.SizeMode = PictureBoxSizeMode.StretchImage;

                // Optionally, update item name and description
                itemName.Text = iName[itemIndex];
                itemHptxt.Text = "HITPOINT  :  " + iHP[itemIndex].ToString(); // Convert int to string
                itemAtktxt.Text = "ATTACK  :  " + iATK[itemIndex].ToString(); // Convert int to string
                itemHealtxt.Text = "HEAL  :  " + iHB[itemIndex].ToString(); // Convert int to string
                itemDesc.Text = iDesc[itemIndex];
            }
        }

        private void InitializeRectangles()
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            //add any components here -jvp
            backInvRec = new Rectangle(backInvBtn.Location.X, backInvBtn.Location.Y, backInvBtn.Width, backInvBtn.Height);
            itemListFLPRec = new Rectangle(itemListFLP.Location.X, itemListFLP.Location.Y, itemListFLP.Width, itemListFLP.Height);
            charListInvFLPRec = new Rectangle(charListInvFLP.Location.X, charListInvFLP.Location.Y, charListInvFLP.Width, charListInvFLP.Height);
            invUnitItemRec = new Rectangle(invUnitItem.Location.X, invUnitItem.Location.Y, invUnitItem.Width, invUnitItem.Height);
            invUnitImgRec = new Rectangle(invUnitImg.Location.X, invUnitImg.Location.Y, invUnitImg.Width, invUnitImg.Height);
            itemPrevRec = new Rectangle(itemPrev.Location.X, itemPrev.Location.Y, itemPrev.Width, itemPrev.Height);
            itemNameRec = new Rectangle(itemName.Location.X, itemName.Location.Y, itemName.Width, itemName.Height);
            itemDescRec = new Rectangle(itemDesc.Location.X, itemDesc.Location.Y, itemDesc.Width, itemDesc.Height);
            itemIconRec = new Rectangle(itemIcon.Location.X, itemIcon.Location.Y, itemIcon.Width, itemIcon.Height);
            skillDescRec = new Rectangle(skillDesc.Location.X, skillDesc.Location.Y, skillDesc.Width, skillDesc.Height);
            equipItemBtnRec = new Rectangle(equipItemBtn.Location.X, equipItemBtn.Location.Y, equipItemBtn.Width, equipItemBtn.Height);
            itemHptxtRec = new Rectangle(itemHptxt.Location.X, itemHptxt.Location.Y, itemHptxt.Width, itemHptxt.Height);
            itemAtktxtRec = new Rectangle(itemAtktxt.Location.X, itemAtktxt.Location.Y, itemAtktxt.Width, itemAtktxt.Height);
            itemHealtxtRec = new Rectangle(itemHealtxt.Location.X, itemHealtxt.Location.Y, itemHealtxt.Width, itemHealtxt.Height);

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
        private void Inventory2_Resize(object sender, EventArgs e)
        {
            resizeControl(backInvRec, backInvBtn);

            resizeControl(itemListFLPRec, itemListFLP);
            resizeControl(charListInvFLPRec, charListInvFLP);
            resizeControl(invUnitItemRec, invUnitItem);
            resizeControl(invUnitImgRec, invUnitImg);
            resizeControl(itemPrevRec, itemPrev);
            resizeControl(itemNameRec, itemName);
            resizeControl(itemDescRec, itemDesc);
            resizeControl(itemIconRec, itemIcon);
            resizeControl(skillDescRec, skillDesc);
            resizeControl(equipItemBtnRec, equipItemBtn);
            resizeControl(itemHptxtRec, itemHptxt);
            resizeControl(itemAtktxtRec, itemAtktxt);
            resizeControl(itemHealtxtRec, itemHealtxt);

        }

        private void itemIcon_DoubleClick(object sender, EventArgs e)
        {
            if (selectedCharIndex == -1)
            {
                MessageBox.Show("Please select a character first.");
                return;
            }

            try
            {
                Con.Connection();
                Con.Con.Open();

                // Query to unequip the item for the selected character
                string query = "UPDATE CharTbl SET itemNo = NULL WHERE charNo = @charNo";
                SqlCommand cmd = new SqlCommand(query, Con.Con);
                cmd.Parameters.AddWithValue("@charNo", selectedCharIndex);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Item unequipped successfully!");

                    // Reset itemIcon and update UI
                    itemIcon.Image = null;
                    itemName.Text = string.Empty;
                    itemDesc.Text = string.Empty;

                    // Optionally, refresh character list or item list
                    LoadItemIconForCharacter(selectedCharIndex);
                    PopulateItemList();
                }
                else
                {
                    MessageBox.Show("Failed to unequip item.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error unequipping item: {ex.Message}");
            }
            finally
            {
                if (Con.Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Con.Close();
                }
            }
        }

        private void equipItemBtn_Click(object sender, EventArgs e)
        {
            if (selectedCharIndex < 0 || selectedItemIndex < 0) // Handle index 0
            {
                MessageBox.Show("Please select a character and an item first.");
                return;
            }

            try
            {
                Con.Connection();
                Con.Con.Open();

                // Get the maximum amount of the selected item
                string getItemAmQuery = "SELECT itemAm FROM ItemTbl WHERE itemNo = @itemNo";
                SqlCommand getItemAmCmd = new SqlCommand(getItemAmQuery, Con.Con);
                getItemAmCmd.Parameters.AddWithValue("@itemNo", selectedItemIndex);

                object itemAmResult = getItemAmCmd.ExecuteScalar();

                if (itemAmResult == null || !int.TryParse(itemAmResult.ToString(), out int maxItemAmount))
                {
                    MessageBox.Show("Failed to retrieve item data.");
                    return;
                }

                // Get the count of characters already equipped with this item
                string getEquippedCountQuery = "SELECT COUNT(*) FROM CharTbl WHERE itemNo = @itemNo";
                SqlCommand getEquippedCountCmd = new SqlCommand(getEquippedCountQuery, Con.Con);
                getEquippedCountCmd.Parameters.AddWithValue("@itemNo", selectedItemIndex);

                int equippedCount = (int)getEquippedCountCmd.ExecuteScalar();

                if (equippedCount >= maxItemAmount)
                {
                    MessageBox.Show("This item has reached its maximum equipped capacity.");
                    return;
                }

                // Update the database to equip the item to the selected character
                string equipItemQuery = "UPDATE CharTbl SET itemNo = @itemNo WHERE charNo = @charNo";
                SqlCommand equipItemCmd = new SqlCommand(equipItemQuery, Con.Con);
                equipItemCmd.Parameters.AddWithValue("@itemNo", selectedItemIndex);
                equipItemCmd.Parameters.AddWithValue("@charNo", selectedCharIndex);

                int rowsAffected = equipItemCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Refresh the item icon for the selected character
                    LoadItemIconForCharacter(selectedCharIndex);
                }
                else
                {
                    MessageBox.Show("Failed to equip item.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error equipping item: {ex.Message}");
            }
            finally
            {
                if (Con.Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Con.Close();
                }
            }
        }

        private void backInvBtn_Click(object sender, EventArgs e)
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
                    Map map = new Map();
                    map.Show();
                });
            });


        }

        private void LoadItems()
        {
            try
            {
                Con.Connection();
                Con.Con.Open();

                // Query to get items with itemAm > 0
                string query = "SELECT itemNo, itemAm FROM ItemTbl WHERE itemAm > 0";
                SqlCommand cmd = new SqlCommand(query, Con.Con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    itemListFLP.Controls.Clear(); // Clear existing controls

                    while (reader.Read())
                    {
                        int itemNo = reader.GetInt32(0);
                        int itemAm = reader.GetInt32(1);

                        // Validate itemNo
                        if (itemNo >= 0 && itemNo < iImg.Length)
                        {
                            // Create a Panel to hold the item image and label
                            Panel itemPanel = new Panel
                            {
                                Size = new Size(75, 90), // Adjusted to accommodate the label
                                Tag = itemNo // Store the item index
                            };

                            // Create PictureBox for the item image
                            PictureBox itemPicBox = new PictureBox
                            {
                                Size = new Size(75, 75),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Image = (Image)Properties.Resources.ResourceManager.GetObject(iImg[itemNo]),
                                Tag = itemNo // Store the item index
                            };

                            itemPicBox.Click += ItemPicBox_Click; // Attach Click event

                            // Create Label for itemAm
                            Label itemAmLabel = new Label
                            {
                                Text = itemAm.ToString(),
                                ForeColor = Color.Black,
                                Font = new Font("Arial", 9, FontStyle.Bold),
                                BackColor = Color.Transparent,
                                TextAlign = ContentAlignment.MiddleRight,
                                Size = new Size(75, 15),
                                Location = new Point(0, 75) // Positioned below the PictureBox
                            };

                            // Add PictureBox and Label to the Panel
                            itemPanel.Controls.Add(itemPicBox);
                            itemPanel.Controls.Add(itemAmLabel);

                            // Add Panel to the FlowLayoutPanel
                            itemListFLP.Controls.Add(itemPanel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}");
            }
            finally
            {
                if (Con.Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Con.Close();
                }
            }
        }
        private void ItemPicBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPicBox && clickedPicBox.Tag is int itemIndex)
            {
                // Validate and store selected item index
                if (itemIndex >= 0 && itemIndex < iImg.Length)
                {
                    selectedItemIndex = itemIndex;
                    itemPrev.Image = (Image)Properties.Resources.ResourceManager.GetObject(iImg[itemIndex]);
                    itemPrev.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Optionally, update item name and description
                    itemName.Text = iName[itemIndex];
                    itemHptxt.Text = "HITPOINT  :  " + iHP[itemIndex].ToString(); // Convert int to string
                    itemAtktxt.Text = "ATTACK  :  " + iATK[itemIndex].ToString(); // Convert int to string
                    itemHealtxt.Text = "HEAL  :  " + iHB[itemIndex].ToString(); // Convert int to string
                    itemDesc.Text = iDesc[itemIndex];
                }
            }
        }


        private void LoadCharacters()
        {
            try
            {
                Con.Connection();
                Con.Con.Open();

                SqlCommand cmd = new SqlCommand("SELECT charNo FROM CharTbl", Con.Con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int charIndex = Convert.ToInt32(reader["charNo"]);
                    if (charIndex >= 0 && charIndex < charIconImg.Length) // Include index 0
                    {
                        AddCharacterToFLP(charIndex -1);
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

        private void AddCharacterToFLP(int charIndex)
        {
            if (charIndex < 0 || charIndex >= charIconImg.Length)
                return; // Ensure valid index

            // Create PictureBox
            PictureBox charPicBox = new PictureBox
            {
                Size = new Size(75, 75),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = (Image)Properties.Resources.ResourceManager.GetObject(charIconImg[charIndex]),
                Tag = charIndex // Store the index
            };

            // Attach click event
            charPicBox.Click += CharPicBox_Click;

            // Add to FlowLayoutPanel
            charListInvFLP.Controls.Add(charPicBox);
        }


        private void CharPicBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPicBox && clickedPicBox.Tag is int charIndex)
            {
                // Validate and store selected character index
                if (charIndex >= 0 && charIndex < charIdleImg.Length)
                {
                    selectedCharIndex = charIndex;
                    invUnitImg.Image = (Image)Properties.Resources.ResourceManager.GetObject(charIdleImg[charIndex]);
                    invUnitImg.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Load item icon for the selected character
                    LoadItemIconForCharacter(charIndex);
                }
            }
        }
        private void LoadItemIconForCharacter(int charIndex)
        {
            try
            {
                Con.Connection();
                Con.Con.Open();

                // Query to get the itemNo for the selected character
                string query = "SELECT itemNo FROM CharTbl WHERE charNo = @charNo";
                SqlCommand cmd = new SqlCommand(query, Con.Con);
                cmd.Parameters.AddWithValue("@charNo", charIndex);

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int itemNo))
                {
                    // Validate itemNo
                    if (itemNo >= 0 && itemNo < iImg.Length)
                    {
                        string imgName = iImg[itemNo];
                        var imgObj = Properties.Resources.ResourceManager.GetObject(imgName);

                        if (imgObj != null)
                        {
                            itemIcon.Image = (Image)imgObj;
                            itemIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                            skillDesc.Text = iDesc[charIndex];
                        }
                        else
                        {
                            itemIcon.Image = null; // Default to no image if resource not found
                        }
                    }
                    else
                    {
                        itemIcon.Image = null; // Default to no image if itemNo is out of bounds
                    }
                }
                else
                {
                    itemIcon.Image = null; // Default to no image if no itemNo found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading item icon: {ex.Message}");
            }
            finally
            {
                if (Con.Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Con.Close();
                }
            }
        }

        private void PopulateItemList()
        {
            itemListFLP.Controls.Clear();

            // Retrieve data from database, including itemAm
            DataTable itemData = GetDataTable("SELECT itemNo, itemAm FROM ItemTbl WHERE itemAm > 0");
            DataTable charData = GetDataTable("SELECT charNo, itemNo FROM CharTbl");

            // Create a dictionary to map itemNo to charNo
            Dictionary<int, int> itemToCharMap = new Dictionary<int, int>();
            foreach (DataRow row in charData.Rows)
            {
                if (row["itemNo"] != DBNull.Value)
                {
                    int itemNo = Convert.ToInt32(row["itemNo"]);
                    int charNo = Convert.ToInt32(row["charNo"]);
                    itemToCharMap[itemNo] = charNo;
                }
            }

            // Create item icons with item amount labels
            foreach (DataRow row in itemData.Rows)
            {
                int itemNo = Convert.ToInt32(row["itemNo"]);
                int itemAm = Convert.ToInt32(row["itemAm"]);

                // Create a Panel to hold the item image and label
                Panel itemPanel = new Panel
                {
                    Size = new Size(75, 90), // Adjusted to fit both PictureBox and Label
                    Tag = itemNo // Store the item index
                };

                // Get item image from resources
                Image itemImage = (Image)Properties.Resources.ResourceManager.GetObject(iImg[itemNo]);

                // Create PictureBox for the item image
                PictureBox itemPicBox = new PictureBox
                {
                    Size = new Size(75, 75),
                    Image = itemImage,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = itemNo // Assign item index to Tag
                };

                itemPicBox.Click += ItemPicBox_Click; // Attach Click event

                // Create Label for itemAm
                Label itemAmLabel = new Label
                {
                    Text = itemAm.ToString(),
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleRight,
                    Size = new Size(75, 15),
                    Location = new Point(0, 75) // Positioned below the PictureBox
                };

                // Add PictureBox and Label to the Panel
                itemPanel.Controls.Add(itemPicBox);
                itemPanel.Controls.Add(itemAmLabel);

                // Check if the item is equipped by any character
                if (itemToCharMap.ContainsKey(itemNo))
                {
                    int charNo = itemToCharMap[itemNo];

                    // Get unit icon image from resources
                    Image unitIconImage = (Image)Properties.Resources.ResourceManager.GetObject(charIconImg[charNo]);

                    // Add player unit icon on top-left corner of the PictureBox
                    PictureBox unitIcon = new PictureBox
                    {
                        Size = new Size(15, 15),
                        Image = unitIconImage,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Location = new Point(0, 0),
                        BackColor = Color.Transparent
                    };

                    // Add unit icon to item PictureBox
                    itemPicBox.Controls.Add(unitIcon);
                }

                // Add the Panel to the FlowLayoutPanel
                itemListFLP.Controls.Add(itemPanel);
            }
        }

        public DataTable GetDataTable(string query)
        {
            DataTable table = new DataTable();
            Con.Connection();
            Con.Con.Open();
            using (SqlCommand cmd = new SqlCommand(query, Con.Con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }
    }
}
