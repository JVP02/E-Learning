using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TheGameProject
{
    public partial class Collection : Form
    {
        private Rectangle backMapRec;
        private Rectangle originalFormSize, itemCollRec, enemyCollRec, dataListRec, collImg1PbRec, collNameLblRec, collDesc1LblRec, collDesc2LblRec, collImg2PbRec, collImg3PbRec;
        private Rectangle pageNoRec, infoPanRec;

        // Access the centralized array
        string[] iImg = SharedArray.icollIcon;
        string[] eImg = SharedArray.ecollIcon;
        
        string[] icollImg1 = SharedArray.icollImg1;
        string[] icollImg2 = SharedArray.icollImg2;
        string[] icollName = SharedArray.icollName;
        string[] icollDesc1 = SharedArray.icollDesc1;
        string[] icollDesc2 = SharedArray.icollDesc2;

        string[] ecollImg1 = SharedArray.ecollImg1;
        string[] ecollImg2 = SharedArray.ecollImg2;
        string[] ecollImg3 = SharedArray.ecollImg3;
        string[] ecollName = SharedArray.ecollName;
        string[] ecollDesc1 = SharedArray.ecollDesc1;
        string[] ecollDesc2 = SharedArray.ecollDesc2;


        // Database connection object
        DBConnection Con = new DBConnection();
        public Collection()
        {
            InitializeComponent();
            // Add event handlers
            itemColl.Click += itemColl_Click;
            enemyColl.Click += enemyColl_Click;
        }

        private void Collection_Load(object sender, EventArgs e)
        {
            InitializeRectangles();

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            backMapBtn.Image = Properties.Resources.BackIcon; // Replace <ImageName> with the actual resource image name
            backMapBtn.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox

            // Display item collection as default
            DisplayImages(iImg, "item");

            // Preselect the first item
            if (dataList.Controls.Count > 0)
            {
                var firstControl = dataList.Controls[0];
                Image_Click(firstControl, EventArgs.Empty, iImg[0], "item");
            }
        }

        private void collImg1Pb_Click(object sender, EventArgs e)
        {

        }

        private void InitializeRectangles()
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            //add any components here -jvp
            backMapRec = new Rectangle(backMapBtn.Location.X, backMapBtn.Location.Y, backMapBtn.Width, backMapBtn.Height);
            itemCollRec = new Rectangle(itemColl.Location.X, itemColl.Location.Y, itemColl.Width, itemColl.Height);
            enemyCollRec = new Rectangle(enemyColl.Location.X, enemyColl.Location.Y, enemyColl.Width, enemyColl.Height);
            infoPanRec = new Rectangle(infoPan.Location.X, infoPan.Location.Y, infoPan.Width, infoPan.Height);

            dataListRec = new Rectangle(dataList.Location.X, dataList.Location.Y, dataList.Width, dataList.Height);
            collImg1PbRec = new Rectangle(collImg1Pb.Location.X, collImg1Pb.Location.Y, collImg1Pb.Width, collImg1Pb.Height);
            //collImg3PbRec = new Rectangle(collImg3Pb.Location.X, collImg3Pb.Location.Y, collImg3Pb.Width, collImg3Pb.Height);
            collNameLblRec = new Rectangle(collNameLbl.Location.X, collNameLbl.Location.Y, collNameLbl.Width, collNameLbl.Height);
            collDesc1LblRec = new Rectangle(collDesc1Lbl.Location.X, collDesc1Lbl.Location.Y, collDesc1Lbl.Width, collDesc1Lbl.Height);
            collDesc2LblRec = new Rectangle(collDesc2Lbl.Location.X, collDesc2Lbl.Location.Y, collDesc2Lbl.Width, collDesc2Lbl.Height);
            collImg2PbRec = new Rectangle(collImg2Pb.Location.X, collImg2Pb.Location.Y, collImg2Pb.Width, collImg2Pb.Height);
            pageNoRec = new Rectangle(pageNo.Location.X, pageNo.Location.Y, pageNo.Width, pageNo.Height);

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
        private void Collection_Resize(object sender, EventArgs e)
        {
            resizeControl(backMapRec, backMapBtn);
            resizeControl(itemCollRec, itemColl);
            resizeControl(infoPanRec, infoPan);
            resizeControl(enemyCollRec, enemyColl);
            resizeControl(dataListRec, dataList);
            resizeControl(collImg1PbRec, collImg1Pb);
            resizeControl(collNameLblRec, collNameLbl);
            resizeControl(collDesc1LblRec, collDesc1Lbl);

            resizeControl(collDesc2LblRec, collDesc2Lbl);
            resizeControl(collImg2PbRec, collImg2Pb);
            //resizeControl(collImg3PbRec, collImg3Pb);
            resizeControl(pageNoRec, pageNo);

        }

        private void itemColl_Click(object sender, EventArgs e)
        {
            DisplayImages(iImg, "item");

        }

        private void enemyColl_Click(object sender, EventArgs e)
        {
            DisplayImages(eImg, "enemy");
        }
        private void DisplayImages(string[] images, string type)
        {
            // Clear existing items in the FlowLayoutPanel
            dataList.Controls.Clear();

            foreach (var imageName in images)
            {
                PictureBox pb = new PictureBox
                {
                    Size = new Size(75, 75),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName)
                };

                // Add to FlowLayoutPanel with the correct type
                pb.Click += (sender, e) => Image_Click(sender, e, imageName, type);
                dataList.Controls.Add(pb);
            }
        }

        private void Image_Click(object sender, EventArgs e, string imageName, string type)
        {
            //// Get the index of the image based on the type
            //int index = Array.IndexOf(type == "item" ? icollImg1 : ecollImg1, imageName);

            //// Update infoPan based on the type (item or enemy)
            //if (type == "item")
            //{
            //    collNameLbl.Text = icollName[index];
            //    collDesc1Lbl.Text = icollDesc1[index];
            //    collDesc2Lbl.Text = icollDesc2[index];
            //    collImg1Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(icollImg1[index]);
            //    collImg2Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(icollImg2[index]);
            //}
            //else if (type == "enemy")
            //{
            //    collNameLbl.Text = ecollName[index];
            //    collDesc1Lbl.Text = ecollDesc1[index];
            //    collDesc2Lbl.Text = ecollDesc2[index];
            //    collImg1Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(ecollImg1[index]);
            //    collImg2Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(ecollImg2[index]);
            //}
            //collImg1Pb.SizeMode = PictureBoxSizeMode.StretchImage; // Replace <ImageName> with the actual resource image name
            //collImg2Pb.SizeMode = PictureBoxSizeMode.StretchImage; // Use Zoom to maintain aspect ratio and fit within the PictureBox

            // Get the index of the clicked PictureBox in the dataList
            int index = dataList.Controls.IndexOf((Control)sender);

            if (index >= 0)
            {
                if (type == "item")
                {
                    collNameLbl.Text = icollName[index];
                    collDesc1Lbl.Text = icollDesc1[index];
                    collDesc2Lbl.Text = icollDesc2[index];
                    collImg1Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(icollImg1[index]);
                    collImg2Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(icollImg2[index]);
                }
                else if (type == "enemy")
                {
                    collNameLbl.Text = ecollName[index];
                    collDesc1Lbl.Text = ecollDesc1[index];
                    collDesc2Lbl.Text = ecollDesc2[index];
                    collImg1Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(ecollImg1[index]);
                    collImg2Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(ecollImg2[index]);
                    //collImg3Pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(ecollImg3[index]);
                }

                // Ensure the images maintain aspect ratio
                collImg1Pb.SizeMode = PictureBoxSizeMode.StretchImage;
                collImg2Pb.SizeMode = PictureBoxSizeMode.StretchImage;
                //if (type == "enemy") collImg3Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void backMapBtn_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            map.Show();
            this.Hide();
        }
    }
}
