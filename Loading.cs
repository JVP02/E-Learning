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
    public partial class Loading : Form
    {
        private Rectangle originalFormSize;
        private Rectangle loadBarRec;
        private Rectangle loadBackRec, loadIconRec;

        public Loading()
        {
            InitializeComponent();
            this.Load += Loading_Load;
            this.Resize += Loading_Resize;
            
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            loadIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            // Save the original form size
            //originalFormSize = this.Size;
            loadBarRec = new Rectangle(loadbar.Location.X, loadbar.Location.Y, loadbar.Width, loadbar.Height);
            loadBackRec = new Rectangle(loadBack.Location.X, loadBack.Location.Y, loadBack.Width, loadBack.Height);
            loadIconRec = new Rectangle(loadIcon.Location.X, loadIcon.Location.Y, loadIcon.Width, loadIcon.Height);

            //add any components here -jvp
            //this.Width = 1310;
            //this.Height = 746;
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

        private void Loading_Resize(object sender, EventArgs e)
        {
            //(rectangleName, componentName) -jvp
            resizeControl(loadBarRec, loadbar);
            resizeControl(loadBackRec, loadBack);
            resizeControl(loadIconRec, loadIcon);
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            loadbar.Width += 15;
            if(loadbar.Width >= 300)
            {
                loadingTimer.Stop();
                //Map f1 = new Map();
                //f1.Show();
                //this.Hide();
            }
        }


    }
}
