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
    public partial class Menu : Form
    {
        //Resize -jvp
        private Rectangle startBtnRec;
        private Rectangle exitBtnRec;
        private Rectangle devMenuBtnRec;
        private Rectangle originalFormSize;
        //Resize -end

        public Menu()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Resize += Form1_Resize;


            //BackgroundMusic.Instance.Play(); // Start playing background music

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            // Save the original form size
            //originalFormSize = this.Size;

            //add any components here -jvp
            startBtnRec = new Rectangle(startBtn.Location.X, startBtn.Location.Y, startBtn.Width, startBtn.Height);
            devMenuBtnRec = new Rectangle(devMenuBtn.Location.X, devMenuBtn.Location.Y, devMenuBtn.Width, devMenuBtn.Height);
            exitBtnRec = new Rectangle(exitBtn.Location.X, exitBtn.Location.Y, exitBtn.Width, exitBtn.Height);
            //this.Width = 1310;
            //this.Height = 746;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set the image for devMenuBtn (which is now a PictureBox)
            devMenuBtn.Image = Properties.Resources.MenuIcon; // Replace <ImageName> with the actual resource image name
            // Set the SizeMode to properly fit the image
            devMenuBtn.SizeMode = PictureBoxSizeMode.Zoom; // Use Zoom to maintain aspect ratio and fit within the PictureBox
            // Set the image for devMenuBtn (which is now a PictureBox)
            startBtn.Image = Properties.Resources.startPic; // Replace <ImageName> with the actual resource image name
            // Set the SizeMode to properly fit the image
            startBtn.SizeMode = PictureBoxSizeMode.StretchImage; // Use Zoom to maintain aspect ratio and fit within the PictureBox
            exitBtn.Image = Properties.Resources.exitPic; // Replace <ImageName> with the actual resource image name
            // Set the SizeMode to properly fit the image
            exitBtn.SizeMode = PictureBoxSizeMode.StretchImage; // Use Zoom to maintain aspect ratio and fit within the PictureBox
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            //(rectangleName, componentName) -jvp
            resizeControl(startBtnRec, startBtn);
            resizeControl(exitBtnRec, exitBtn);
            resizeControl(devMenuBtnRec, devMenuBtn);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            //Loading load = new Loading();
            //load.Show();
            //Task.Run(() =>
            //{
            //    System.Threading.Thread.Sleep(2000);
            //    this.Invoke((MethodInvoker)delegate
            //    {
            //        this.Hide();
            //        load.Hide();
            //        Map map = new Map();
            //        map.Show();
            //    });
            //});

            // Create and show the loading form
            Loading load = new Loading();
            load.Show();

            // Run the loading process asynchronously
            Task.Run(() =>
            {
                // Simulate loading with a delay (e.g., 2 seconds)
                System.Threading.Thread.Sleep(2000);

                // Invoke on the UI thread to update the UI safely
                this.Invoke((MethodInvoker)delegate
                {
                    // Load the Map form in the background
                    Map map = new Map();

                    // Hide the menu form and close the loading form
                    this.Hide();
                    load.Hide();

                    // Show the Map form
                    map.Show();
                });
            });

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void devMenuBtn_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void devMenuPB_Click(object sender, EventArgs e)
        {
            DevSettings dev = new DevSettings();
            dev.Show();
            //this.Hide();
        }
    }
}
