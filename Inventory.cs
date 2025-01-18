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
    public partial class Inventory : Form
    {
        private Rectangle backInvRec;
        private Rectangle originalFormSize;
        private Rectangle slot1Rec, slot2Rec, slot3Rec, slot4Rec, slot5Rec, slot6Rec, slot7Rec, slot8Rec, slot9Rec, slot10Rec, slot11Rec, slot12Rec, slot13Rec, slot14Rec, slot15Rec,
                          slot16Rec, slot17Rec, slot18Rec, slot19Rec, slot20Rec, slot21Rec, slot22Rec, slot23Rec, slot24Rec, slot25Rec, slot26Rec, slot27Rec, slot28Rec, slot29Rec, slot30Rec,
                          slot31Rec, slot32Rec, slot33Rec, slot34Rec, slot35Rec, slot36Rec, slot37Rec, slot38Rec, slot39Rec, slot40Rec;



        private void fastEquip2_Click(object sender, EventArgs e)
        {

        }

        private Rectangle fastEquip1Rec, fastEquip2Rec, fastEquip3Rec;
        private Rectangle itemPrevRec, itemNameRec, itemDescRec, HPprevRec, ATKprevRec, EMprevRec, HBprevRec;
        private Rectangle invUnit1Rec, invUnit2Rec, invUnit3Rec, unit1Slot1Rec, unit1Slot2Rec, unit1Slot3Rec, unit2Slot1Rec, unit2Slot2Rec, unit2Slot3Rec, unit3Slot1Rec, unit3Slot2Rec, unit3Slot3Rec;
        private Rectangle HPtxt1Rec, HPtxt2Rec, HPtxt3Rec, ATKtxt1Rec, ATKtxt2Rec, ATKtxt3Rec, EMtxt1Rec, EMtxt2Rec, EMtxt3Rec, HBtxt1Rec, HBtxt2Rec, HBtxt3Rec;

        string[] charIconImg = { "KnightIcon", "ArcherIcon", "WhiteBeardIcon", "YujiIcon", "TanjiroIcon" };
        string[] charIdleImg = { "KnightIdle", "ArcherIdle", "WhiteBeardIdle", "YujiIdle", "TanjiroIdle" };
        string[] iImg = { "itak", "binakuko", "bicuco", "item4", "item5", "item6", "item7", "item8", "item9", "item10" };
        string[] iName = { "Itak", "Binakuko", "Bicuco", "item4", "item5", "item6", "item7", "item8", "item9", "item10" };
        string[] iDesc = { "a narrow sword used for combat and self-defense in the Tagalog regions. Like the súndang, it is also known as the \"jungle bolo\" or \"tip bolo\"",
            "one of the quick, chopping blades favored by the Moro warriors and pirates of the Southern Philippines. This surprisingly lightweight and agile blade has a wide chopping blade and a sharp thrusting tip.",
            "\r\nYou sent\r\nPurely a working tool during peace times, this sword is considered by the Filipino people as a “long knife” that can be used for slaughtering animals and preparing the meat for a feast. But the nasty design of this long knife is so well balanced, it can actually cut deep into a body very easily.",
            "item4", 
            "item5", 
            "item6", 
            "item7", 
            "item8", 
            "item9", 
            "item10" };
        int[] iHP = { 700, 850, 500, 900, 950, 700, 850, 500, 900, 950 };
        int[] iATK = { 80, 85, 50, 20, 10, 50, 80, 50, 90, 90 };
        int[] iEM = { 20, 10, 15, 20, 10,20, 25, 30, 20, 15 };
        int[] iHB = { 80, 85, 50, 20, 10, 50, 80, 50, 90, 90 };


        // Database connection object
        DBConnection Con = new DBConnection();
        public Inventory()
        {
            InitializeComponent();
        }
        private PictureBox[] slots;  // Declare slots at the class level
        private void Inventory_Load(object sender, EventArgs e)
        {
            InitializeRectangles();

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            



            // Retrieve party data
            (int party1, int party2, int party3) = GetPartyDataFromDatabase();

            // Display party data
            SetPartyImages(party1, fastEquip1, invUnit1);
            SetPartyImages(party2, fastEquip2, invUnit21);
            SetPartyImages(party3, fastEquip3, invUnit3);

            //Decomment if you remove the codeafter this
            //ItemSlots();

            // Set up the slots dynamically in an array or list for easier access
            PictureBox[] slots = { slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9, slot10,
                           slot11, slot12, slot13, slot14, slot15, slot16, slot17, slot18, slot19, slot20,
                           slot21, slot22, slot23, slot24, slot25, slot26, slot27, slot28, slot29, slot30,
                           slot31, slot32, slot33, slot34, slot35, slot36, slot37, slot38, slot39, slot40 };
            foreach (PictureBox slot in slots)
            {
                slot.MouseDown += slot_MouseDown;
                slot.Click += Slot_Click;  // Item selection functionality
            }

            //Drag and Drop ==================================================
            fastEquip1.AllowDrop = true;
            fastEquip2.AllowDrop = true;
            fastEquip3.AllowDrop = true;
            unit1Slot1.AllowDrop = true;
            unit1Slot2.AllowDrop = true;
            unit1Slot3.AllowDrop = true;
            unit2Slot1.AllowDrop = true;
            unit2Slot2.AllowDrop = true;
            unit2Slot3.AllowDrop = true;
            unit3Slot1.AllowDrop = true;
            unit3Slot2.AllowDrop = true;
            unit3Slot3.AllowDrop = true;

            unit1Slot1.DragEnter += new DragEventHandler(unitSlot_DragEnter);
            unit1Slot2.DragEnter += new DragEventHandler(unitSlot_DragEnter);
            unit1Slot3.DragEnter += new DragEventHandler(unitSlot_DragEnter);
            unit2Slot1.DragEnter += new DragEventHandler(unitSlot_DragEnter);
            unit2Slot2.DragEnter += new DragEventHandler(unitSlot_DragEnter);
            unit2Slot3.DragEnter += new DragEventHandler(unitSlot_DragEnter);
            unit3Slot1.DragEnter += new DragEventHandler(unitSlot_DragEnter);
            unit3Slot2.DragEnter += new DragEventHandler(unitSlot_DragEnter);
            unit3Slot3.DragEnter += new DragEventHandler(unitSlot_DragEnter);

            unit1Slot1.DragDrop += new DragEventHandler(unitSlot_DragDrop);
            unit1Slot2.DragDrop += new DragEventHandler(unitSlot_DragDrop);
            unit1Slot3.DragDrop += new DragEventHandler(unitSlot_DragDrop);
            unit2Slot1.DragDrop += new DragEventHandler(unitSlot_DragDrop);
            unit2Slot2.DragDrop += new DragEventHandler(unitSlot_DragDrop);
            unit2Slot3.DragDrop += new DragEventHandler(unitSlot_DragDrop);
            unit3Slot1.DragDrop += new DragEventHandler(unitSlot_DragDrop);
            unit3Slot2.DragDrop += new DragEventHandler(unitSlot_DragDrop);
            unit3Slot3.DragDrop += new DragEventHandler(unitSlot_DragDrop);


            fastEquip1.DragEnter += new DragEventHandler(fastEquip_DragEnter);
            fastEquip2.DragEnter += new DragEventHandler(fastEquip_DragEnter);
            fastEquip3.DragEnter += new DragEventHandler(fastEquip_DragEnter);

            fastEquip1.DragDrop += new DragEventHandler(fastEquip_DragDrop);
            fastEquip2.DragDrop += new DragEventHandler(fastEquip_DragDrop);
            fastEquip3.DragDrop += new DragEventHandler(fastEquip_DragDrop);
            //===================================================================

            // Get item data from the database
            List<int> itemNos = GetItemNosFromDatabase();

            // Display items in the slots based on the item numbers
            for (int i = 0; i < itemNos.Count && i < slots.Length; i++)
            {
                int itemIndex = itemNos[i];  // Get itemNo from the database

                if (itemIndex >= 0 && itemIndex < iImg.Length) // Ensure itemNo is valid
                {
                    // Assign the image from the iImg array to the corresponding slot
                    slots[i].Image = (Image)Properties.Resources.ResourceManager.GetObject(iImg[itemIndex]);
                    slots[i].SizeMode = PictureBoxSizeMode.StretchImage;

                    // Store additional item info in the Tag property for later use
                    slots[i].Tag = new ItemInfo
                    {
                        Img = iImg[itemIndex],
                        Name = iName[itemIndex],
                        Description = iDesc[itemIndex]
                    };
                }
            }
        }
        private void InitializeRectangles()
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            //add any components here -jvp
            backInvRec = new Rectangle(backInvBtn.Location.X, backInvBtn.Location.Y, backInvBtn.Width, backInvBtn.Height);
            slot1Rec = new Rectangle(slot1.Location.X, slot1.Location.Y, slot1.Width, slot1.Height);
            slot2Rec = new Rectangle(slot2.Location.X, slot2.Location.Y, slot2.Width, slot2.Height);
            slot3Rec = new Rectangle(slot3.Location.X, slot3.Location.Y, slot3.Width, slot3.Height);
            slot4Rec = new Rectangle(slot4.Location.X, slot4.Location.Y, slot4.Width, slot4.Height);
            slot5Rec = new Rectangle(slot5.Location.X, slot5.Location.Y, slot5.Width, slot5.Height);
            slot6Rec = new Rectangle(slot6.Location.X, slot6.Location.Y, slot6.Width, slot6.Height);
            slot7Rec = new Rectangle(slot7.Location.X, slot7.Location.Y, slot7.Width, slot7.Height);
            slot8Rec = new Rectangle(slot8.Location.X, slot8.Location.Y, slot8.Width, slot8.Height);
            slot9Rec = new Rectangle(slot9.Location.X, slot9.Location.Y, slot9.Width, slot9.Height);
            slot10Rec = new Rectangle(slot10.Location.X, slot10.Location.Y, slot10.Width, slot10.Height);
            slot11Rec = new Rectangle(slot11.Location.X, slot11.Location.Y, slot11.Width, slot11.Height);
            slot12Rec = new Rectangle(slot12.Location.X, slot12.Location.Y, slot12.Width, slot12.Height);
            slot13Rec = new Rectangle(slot13.Location.X, slot13.Location.Y, slot13.Width, slot13.Height);
            slot14Rec = new Rectangle(slot14.Location.X, slot14.Location.Y, slot14.Width, slot14.Height);
            slot15Rec = new Rectangle(slot15.Location.X, slot15.Location.Y, slot15.Width, slot15.Height);
            slot16Rec = new Rectangle(slot16.Location.X, slot16.Location.Y, slot16.Width, slot16.Height);
            slot17Rec = new Rectangle(slot17.Location.X, slot17.Location.Y, slot17.Width, slot17.Height);
            slot18Rec = new Rectangle(slot18.Location.X, slot18.Location.Y, slot18.Width, slot18.Height);
            slot19Rec = new Rectangle(slot19.Location.X, slot19.Location.Y, slot19.Width, slot19.Height);
            slot20Rec = new Rectangle(slot20.Location.X, slot20.Location.Y, slot20.Width, slot20.Height);
            slot21Rec = new Rectangle(slot21.Location.X, slot21.Location.Y, slot21.Width, slot21.Height);
            slot22Rec = new Rectangle(slot22.Location.X, slot22.Location.Y, slot22.Width, slot22.Height);
            slot23Rec = new Rectangle(slot23.Location.X, slot23.Location.Y, slot23.Width, slot23.Height);
            slot24Rec = new Rectangle(slot24.Location.X, slot24.Location.Y, slot24.Width, slot24.Height);
            slot25Rec = new Rectangle(slot25.Location.X, slot25.Location.Y, slot25.Width, slot25.Height);
            slot26Rec = new Rectangle(slot26.Location.X, slot26.Location.Y, slot26.Width, slot26.Height);
            slot27Rec = new Rectangle(slot27.Location.X, slot27.Location.Y, slot27.Width, slot27.Height);
            slot28Rec = new Rectangle(slot28.Location.X, slot28.Location.Y, slot28.Width, slot28.Height);
            slot29Rec = new Rectangle(slot29.Location.X, slot29.Location.Y, slot29.Width, slot29.Height);
            slot30Rec = new Rectangle(slot30.Location.X, slot30.Location.Y, slot30.Width, slot30.Height);
            slot31Rec = new Rectangle(slot31.Location.X, slot31.Location.Y, slot31.Width, slot31.Height);
            slot32Rec = new Rectangle(slot32.Location.X, slot32.Location.Y, slot32.Width, slot32.Height);
            slot33Rec = new Rectangle(slot33.Location.X, slot33.Location.Y, slot33.Width, slot33.Height);
            slot34Rec = new Rectangle(slot34.Location.X, slot34.Location.Y, slot34.Width, slot34.Height);
            slot35Rec = new Rectangle(slot35.Location.X, slot35.Location.Y, slot35.Width, slot35.Height);
            slot36Rec = new Rectangle(slot36.Location.X, slot36.Location.Y, slot36.Width, slot36.Height);
            slot37Rec = new Rectangle(slot37.Location.X, slot37.Location.Y, slot37.Width, slot37.Height);
            slot38Rec = new Rectangle(slot38.Location.X, slot38.Location.Y, slot38.Width, slot38.Height);
            slot39Rec = new Rectangle(slot39.Location.X, slot39.Location.Y, slot39.Width, slot39.Height);
            slot40Rec = new Rectangle(slot40.Location.X, slot40.Location.Y, slot40.Width, slot40.Height);


            fastEquip1Rec = new Rectangle(fastEquip1.Location.X, fastEquip1.Location.Y, fastEquip1.Width, fastEquip1.Height);
            fastEquip2Rec = new Rectangle(fastEquip2.Location.X, fastEquip2.Location.Y, fastEquip2.Width, fastEquip2.Height);
            fastEquip3Rec = new Rectangle(fastEquip3.Location.X, fastEquip3.Location.Y, fastEquip3.Width, fastEquip3.Height);

            itemPrevRec = new Rectangle(itemPrev.Location.X, itemPrev.Location.Y, itemPrev.Width, itemPrev.Height);
            itemNameRec = new Rectangle(itemName.Location.X, itemName.Location.Y, itemName.Width, itemName.Height);
            itemDescRec = new Rectangle(itemDesc.Location.X, itemDesc.Location.Y, itemDesc.Width, itemDesc.Height);
            HPprevRec = new Rectangle(HPprev.Location.X, HPprev.Location.Y, HPprev.Width, HPprev.Height);
            ATKprevRec = new Rectangle(ATKprev.Location.X, ATKprev.Location.Y, ATKprev.Width, ATKprev.Height);
            EMprevRec = new Rectangle(EMprev.Location.X, EMprev.Location.Y, EMprev.Width, EMprev.Height);
            HBprevRec = new Rectangle(HBprev.Location.X, HBprev.Location.Y, HBprev.Width, HBprev.Height);

            invUnit1Rec = new Rectangle(invUnit1.Location.X, invUnit1.Location.Y, invUnit1.Width, invUnit1.Height);
            invUnit2Rec = new Rectangle(invUnit21.Location.X, invUnit21.Location.Y, invUnit21.Width, invUnit21.Height);
            invUnit3Rec = new Rectangle(invUnit3.Location.X, invUnit3.Location.Y, invUnit3.Width, invUnit3.Height);

            unit1Slot1Rec = new Rectangle(unit1Slot1.Location.X, unit1Slot1.Location.Y, unit1Slot1.Width, unit1Slot1.Height);
            unit1Slot2Rec = new Rectangle(unit1Slot2.Location.X, unit1Slot2.Location.Y, unit1Slot2.Width, unit1Slot2.Height);
            unit1Slot3Rec = new Rectangle(unit1Slot3.Location.X, unit1Slot3.Location.Y, unit1Slot3.Width, unit1Slot3.Height);
            unit2Slot1Rec = new Rectangle(unit2Slot1.Location.X, unit2Slot1.Location.Y, unit2Slot1.Width, unit2Slot1.Height);
            unit2Slot2Rec = new Rectangle(unit2Slot2.Location.X, unit2Slot2.Location.Y, unit2Slot2.Width, unit2Slot2.Height);
            unit2Slot3Rec = new Rectangle(unit2Slot3.Location.X, unit2Slot3.Location.Y, unit2Slot3.Width, unit2Slot3.Height);
            unit3Slot1Rec = new Rectangle(unit3Slot1.Location.X, unit3Slot1.Location.Y, unit3Slot1.Width, unit3Slot1.Height);
            unit3Slot2Rec = new Rectangle(unit3Slot2.Location.X, unit3Slot2.Location.Y, unit3Slot2.Width, unit3Slot2.Height);
            unit3Slot3Rec = new Rectangle(unit3Slot3.Location.X, unit3Slot3.Location.Y, unit3Slot3.Width, unit3Slot3.Height);

            HPtxt1Rec = new Rectangle(HPtxt1.Location.X, HPtxt1.Location.Y, HPtxt1.Width, HPtxt1.Height);
            HPtxt2Rec = new Rectangle(HPtxt2.Location.X, HPtxt2.Location.Y, HPtxt2.Width, HPtxt2.Height);
            HPtxt3Rec = new Rectangle(HPtxt3.Location.X, HPtxt3.Location.Y, HPtxt3.Width, HPtxt3.Height);
            ATKtxt1Rec = new Rectangle(ATKtxt1.Location.X, ATKtxt1.Location.Y, ATKtxt1.Width, ATKtxt1.Height);
            ATKtxt2Rec = new Rectangle(ATKtxt2.Location.X, ATKtxt2.Location.Y, ATKtxt2.Width, ATKtxt2.Height);
            ATKtxt3Rec = new Rectangle(ATKtxt3.Location.X, ATKtxt3.Location.Y, ATKtxt3.Width, ATKtxt3.Height);
            EMtxt1Rec = new Rectangle(EMtxt1.Location.X, EMtxt1.Location.Y, EMtxt1.Width, EMtxt1.Height);
            EMtxt2Rec = new Rectangle(EMtxt2.Location.X, EMtxt2.Location.Y, EMtxt2.Width, EMtxt2.Height);
            EMtxt3Rec = new Rectangle(EMtxt3.Location.X, EMtxt3.Location.Y, EMtxt3.Width, EMtxt3.Height);
            HBtxt1Rec = new Rectangle(HBtxt1.Location.X, HBtxt1.Location.Y, HBtxt1.Width, HBtxt1.Height);
            HBtxt2Rec = new Rectangle(HBtxt2.Location.X, HBtxt2.Location.Y, HBtxt2.Width, HBtxt2.Height);
            HBtxt3Rec = new Rectangle(HBtxt3.Location.X, HBtxt3.Location.Y, HBtxt3.Width, HBtxt3.Height);
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
        private void Inventory_Resize(object sender, EventArgs e)
        {
            //(rectangleName, componentName) -jvp
            resizeControl(backInvRec, backInvBtn);

            resizeControl(backInvRec, backInvBtn);

            resizeControl(slot1Rec,slot1);
            resizeControl(slot2Rec,slot2);
            resizeControl(slot3Rec,slot3);
            resizeControl(slot4Rec,slot4);
            resizeControl(slot5Rec,slot5);
            resizeControl(slot6Rec,slot6);
            resizeControl(slot7Rec,slot7);
            resizeControl(slot8Rec,slot8);
            resizeControl(slot9Rec,slot9);
            resizeControl(slot10Rec,slot10);
            resizeControl(slot11Rec,slot11);
            resizeControl(slot12Rec,slot12);
            resizeControl(slot13Rec,slot13);
            resizeControl(slot14Rec,slot14);
            resizeControl(slot15Rec,slot15);
            resizeControl(slot16Rec,slot16);
            resizeControl(slot17Rec,slot17);
            resizeControl(slot18Rec,slot18);
            resizeControl(slot19Rec,slot19);
            resizeControl(slot20Rec,slot20);
            resizeControl(slot21Rec,slot21);
            resizeControl(slot22Rec,slot22);
            resizeControl(slot23Rec,slot23);
            resizeControl(slot24Rec,slot24);
            resizeControl(slot25Rec,slot25);
            resizeControl(slot26Rec,slot26);
            resizeControl(slot27Rec,slot27);
            resizeControl(slot28Rec,slot28);
            resizeControl(slot29Rec,slot29);
            resizeControl(slot30Rec,slot30);
            resizeControl(slot31Rec,slot31);
            resizeControl(slot32Rec,slot32);
            resizeControl(slot33Rec,slot33);
            resizeControl(slot34Rec,slot34);
            resizeControl(slot35Rec,slot35);
            resizeControl(slot36Rec,slot36);
            resizeControl(slot37Rec,slot37);
            resizeControl(slot38Rec,slot38);
            resizeControl(slot39Rec,slot39);
            resizeControl(slot40Rec,slot40);

            resizeControl(fastEquip1Rec, fastEquip1);
            resizeControl(fastEquip2Rec, fastEquip2);
            resizeControl(fastEquip3Rec, fastEquip3);

            resizeControl(itemPrevRec, itemPrev);
            resizeControl(itemNameRec, itemName);
            resizeControl(itemDescRec, itemDesc);
            resizeControl(HPprevRec, HPprev);
            resizeControl(ATKprevRec, ATKprev);
            resizeControl(EMprevRec, EMprev);
            resizeControl(HBprevRec, HBprev);

            resizeControl(invUnit1Rec, invUnit1);
            resizeControl(invUnit2Rec, invUnit21);
            resizeControl(invUnit3Rec, invUnit3);

            resizeControl(unit1Slot1Rec, unit1Slot1);
            resizeControl(unit1Slot2Rec, unit1Slot2);
            resizeControl(unit1Slot3Rec, unit1Slot3);
            resizeControl(unit2Slot1Rec, unit2Slot1);
            resizeControl(unit2Slot2Rec, unit2Slot2);
            resizeControl(unit2Slot3Rec, unit2Slot3);
            resizeControl(unit3Slot1Rec, unit3Slot1);
            resizeControl(unit3Slot2Rec, unit3Slot2);
            resizeControl(unit3Slot3Rec, unit3Slot3);

            resizeControl(HPtxt1Rec, HPtxt1);
            resizeControl(HPtxt2Rec, HPtxt2);
            resizeControl(HPtxt3Rec, HPtxt3);
            resizeControl(ATKtxt1Rec,ATKtxt1);
            resizeControl(ATKtxt2Rec, ATKtxt2);
            resizeControl(ATKtxt3Rec, ATKtxt3);
            resizeControl(EMtxt1Rec, EMtxt1);
            resizeControl(EMtxt2Rec, EMtxt2);
            resizeControl(EMtxt3Rec, EMtxt3);
            resizeControl(HBtxt1Rec, HBtxt1);
            resizeControl(HBtxt2Rec, HBtxt2);
            resizeControl(HBtxt3Rec, HBtxt3);
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

        // Method to retrieve the party values from the PartyTbl
        private (int, int, int) GetPartyDataFromDatabase()
        {
            int party1 = 0, party2 = 0, party3 = 0;
            try
            {
                Con.Connection();
                Con.Con.Open();
                string query = "SELECT party1, party2, party3 FROM PartyTbl"; // Add conditions if necessary
                SqlCommand cmd = new SqlCommand(query, Con.Con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    party1 = reader.GetInt32(0); // Get value of party1
                    party2 = reader.GetInt32(1); // Get value of party2
                    party3 = reader.GetInt32(2); // Get value of party3
                }

                reader.Close();
                Con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading party data: {ex.Message}");
            }
            return (party1, party2, party3);
        }
        private void SetPartyImages(int partyValue, PictureBox fastEquip, PictureBox invUnit)
        {
            if (partyValue >= 0 && partyValue < charIconImg.Length)
            {
                string iconImgName = charIconImg[partyValue];
                string idleImgName = charIdleImg[partyValue];

                // Attempt to load and display images
                try
                {
                    fastEquip.SizeMode = PictureBoxSizeMode.StretchImage;
                    invUnit.SizeMode = PictureBoxSizeMode.StretchImage;
                    fastEquip.Image = (Image)Properties.Resources.ResourceManager.GetObject(iconImgName);
                    invUnit.Image = (Image)Properties.Resources.ResourceManager.GetObject(idleImgName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading images for party value {partyValue}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show($"Invalid party value: {partyValue}");
            }
        }

        // Method to retrieve the item numbers from the ItemTbl
        private List<int> GetItemNosFromDatabase()
        {
            List<int> itemNos = new List<int>();
            try
            {
                Con.Connection();
                Con.Con.Open();
                string query = "SELECT itemNo FROM ItemTbl"; // Adjust this query as necessary
                SqlCommand cmd = new SqlCommand(query, Con.Con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        itemNos.Add(reader.GetInt32(0)); // Assuming itemNo is an integer
                    }
                }

                reader.Close();
                Con.Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading item data: {ex.Message}");
            }

            return itemNos;
        }

        // Event handler for when a slot is clicked
        private void Slot_Click(object sender, EventArgs e)
        {
            PictureBox clickedSlot = (PictureBox)sender;

            if (clickedSlot.Tag is ItemInfo itemInfo)
            {
                itemName.Text = itemInfo.Name;
                itemDesc.Text = itemInfo.Description;
            }
        }
        // Class to store item information
        // Class to store item information
        private class ItemInfo
        {
            public string Img { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Index { get; set; }  // To store the index for iHP, iATK, etc.
        }

        // Saving To Database =================================================================================================================
        private void slot_MouseDown(object sender, MouseEventArgs e)
        {
            // Cast the sender to PictureBox
            PictureBox clickedSlot = (PictureBox)sender;

            // Check if the slot has valid item info in the Tag
            if (clickedSlot.Tag is ItemInfo itemInfo)
            {
                // Load the image from the resources or file path
                itemPrev.SizeMode = PictureBoxSizeMode.StretchImage;
                itemPrev.Image = (Image)Properties.Resources.ResourceManager.GetObject(itemInfo.Img); // If it's an embedded resource

                // Alternatively, if you're loading from a file path:
                // itemPrev.Image = Image.FromFile(itemInfo.Img);
                itemName.Text = itemInfo.Name;
                itemDesc.Text = itemInfo.Description;

                // Show the corresponding stats from the arrays
                HPprev.Text = $"HP: +{iHP[itemInfo.Index]}";
                ATKprev.Text = $"ATK: +{iATK[itemInfo.Index]}";
                EMprev.Text = $"EM: +{iEM[itemInfo.Index]}";
                HBprev.Text = $"HB: +{iHB[itemInfo.Index]}";


                // Proceed with drag-and-drop functionality
                DoDragDrop(itemInfo, DragDropEffects.Move);
            }
        }
        private void fastEquip_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemInfo)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void fastEquip_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox fastEquip = sender as PictureBox;
            if (fastEquip != null && e.Data.GetData(typeof(ItemInfo)) is ItemInfo itemInfo)
            {
                // Display the item in the fastEquip slot
                fastEquip.Image = (Image)Properties.Resources.ResourceManager.GetObject(itemInfo.Img);
                fastEquip.SizeMode = PictureBoxSizeMode.StretchImage;

                // Save to the database
                SaveItemToDatabase(fastEquip, itemInfo);
            }
        }

        private void SaveItemToDatabase(PictureBox fastEquip, ItemInfo itemInfo)
        {
            int itemIndex = Array.IndexOf(iImg, itemInfo.Img);  // Get the index of the item

            if (itemIndex == -1)
            {
                MessageBox.Show("Error finding item index.");
                return;
            }

            string columnName = "";
            string query = "";

            // Determine which fastEquip the item was dropped into and find the first available column
            if (fastEquip == fastEquip1)
            {
                columnName = GetAvailableUnitEquipColumn(1); // Get available column for unit1
            }
            else if (fastEquip == fastEquip2)
            {
                columnName = GetAvailableUnitEquipColumn(2); // Get available column for unit2
            }
            else if (fastEquip == fastEquip3)
            {
                columnName = GetAvailableUnitEquipColumn(3); // Get available column for unit3
            }

            if (!string.IsNullOrEmpty(columnName))
            {
                // Update the database with the item index in the available column
                try
                {
                    Con.Connection();
                    Con.Con.Open();
                    query = $"UPDATE UnitItemTbl SET {columnName} = @itemIndex WHERE UnitID = @unitID"; // Adjust @unitID accordingly
                    SqlCommand cmd = new SqlCommand(query, Con.Con);
                    cmd.Parameters.AddWithValue("@itemIndex", itemIndex);
                    cmd.Parameters.AddWithValue("@unitID", 1); // Adjust this to the correct UnitID
                    cmd.ExecuteNonQuery();
                    Con.Con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving item to database: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No available slot found for this unit.");
            }
        }

        private string GetAvailableUnitEquipColumn(int unitNumber)
        {
            string[] equipColumns = { $"unit{unitNumber}equip1", $"unit{unitNumber}equip2", $"unit{unitNumber}equip3" };

            try
            {
                Con.Connection();
                Con.Con.Open();
                foreach (var column in equipColumns)
                {
                    // Check if the column already has an item assigned
                    string query = $"SELECT {column} FROM UnitItemTbl WHERE UnitID = @UnitID";
                    SqlCommand cmd = new SqlCommand(query, Con.Con);
                    cmd.Parameters.AddWithValue("@UnitID", unitNumber);
                    var result = cmd.ExecuteScalar();

                    if (result == DBNull.Value || (int)result == -1)  // Assuming -1 means no item assigned
                    {
                        return column;  // Return first empty column
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking available slot: {ex.Message}");
            }
            finally
            {
                if (Con.Con.State == ConnectionState.Open)
                {
                    Con.Con.Close();
                }
            }
            return ""; // Return empty if no slot is available
        }

        // Drop directly in Unit Inventory ===================================================
        private void item_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                pb.DoDragDrop(pb.Tag, DragDropEffects.Move);
            }
        }

        private void unitSlot_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox unitSlot = sender as PictureBox;
            if (unitSlot != null && e.Data.GetData(typeof(ItemInfo)) is ItemInfo itemInfo)
            {
                // Display the item in the unit slot
                unitSlot.Image = (Image)Properties.Resources.ResourceManager.GetObject(itemInfo.Img);
                unitSlot.SizeMode = PictureBoxSizeMode.StretchImage;

                // Save to the database
                SaveItemToUnitSlot(unitSlot, itemInfo);
            }
        }

        private void SaveItemToUnitSlot(PictureBox fastEquip, ItemInfo itemInfo)
        {
            int itemIndex = Array.IndexOf(iImg, itemInfo.Img); // Get the index of the item

            if (itemIndex == -1)
            {
                MessageBox.Show("Error finding item index.");
                return;
            }

            // Determine the unit number and equipment column based on the fast equip slot
            string columnName = "";
            if (fastEquip == fastEquip1)
            {
                columnName = GetAvailableUnitEquipColumn(1); // Get available column for unit1
            }
            else if (fastEquip == fastEquip2)
            {
                columnName = GetAvailableUnitEquipColumn(2); // Get available column for unit2
            }
            else if (fastEquip == fastEquip3)
            {
                columnName = GetAvailableUnitEquipColumn(3); // Get available column for unit3
            }

            // If column name is empty, show error
            if (string.IsNullOrEmpty(columnName))
            {
                MessageBox.Show("No available slot for this unit.");
                return;
            }

            try
            {
                // Open the connection
                Con.Connection();
                Con.Con.Open();

                // Define query with the dynamic column name
                string query = $"UPDATE UnitItemTbl SET {columnName} = @ItemIndex WHERE UnitID = @UnitID";
                using (SqlCommand cmd = new SqlCommand(query, Con.Con))
                {
                    // Map parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@ItemIndex", itemIndex);
                    cmd.Parameters.AddWithValue("@UnitID", 1); // Update with the correct unit ID, if it changes

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item saved successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to save item.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving item to database: {ex.Message}");
            }
            finally
            {
                // Ensure the connection is closed
                if (Con.Con.State == ConnectionState.Open)
                {
                    Con.Con.Close();
                }
            }
        }

        private void unitSlot_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ItemInfo)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void saveItemsBtn_Click(object sender, EventArgs e)
        {
            // Define the mapping between each slot and the respective column in the database
            var slotToColumnMapping = new Dictionary<PictureBox, string>
    {
        { unit1Slot1, "unit1equip1" },
        { unit1Slot2, "unit1equip2" },
        { unit1Slot3, "unit1equip3" },
        { unit2Slot1, "unit2equip1" },
        { unit2Slot2, "unit2equip2" },
        { unit2Slot3, "unit2equip3" },
        { unit3Slot1, "unit3equip1" },
        { unit3Slot2, "unit3equip2" },
        { unit3Slot3, "unit3equip3" }
    };

            // Iterate through each slot and save the corresponding item index to the database
            foreach (var kvp in slotToColumnMapping)
            {
                PictureBox slot = kvp.Key;
                string columnName = kvp.Value;

                // Get the index of the item in the slot, or set to -1 if no item is present
                int itemIndex = (slot.Tag is ItemInfo itemInfo) ? itemInfo.Index : -1;

                // Save the item index to the appropriate column in the database
                SaveItemToDatabase(columnName, itemIndex);
            }
        }
        // Method to save the item index to the database
        private void SaveItemToDatabase(string columnName, int itemIndex)
        {
            Con.Connection();
            Con.Con.Open();
            string query = $"UPDATE UnitItemTbl SET {columnName} = @ItemIndex WHERE UnitID = @UnitID";

                using (var command = new SqlCommand(query, Con.Con))
                {
                    command.Parameters.AddWithValue("@ItemIndex", itemIndex);
                    command.Parameters.AddWithValue("@UnitID", 1); // Replace with the actual UnitID if needed

                    command.ExecuteNonQuery();
                }
            
        }
    }
}
