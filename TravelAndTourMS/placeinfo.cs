using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class placeinfo : Form
    {
        public placeinfo()
        {
            InitializeComponent();
        }

        private void placeinfo_Load(object sender, EventArgs e)
        {
            // Create a new instance of PictureBox
            PictureBox pictureBox = new PictureBox();

            // Set the image location
            pictureBox.ImageLocation = @"C:\photos\bpoy.jpeg";

            // Get the current size of the PictureBox control
            Size currentSize = pictureBox.Size;

            // Increase the size of the PictureBox control by 50%
            Size newSize = new Size((int)(currentSize.Width * 3), (int)(currentSize.Height * 5.5));
            pictureBox.Size = newSize;

            // Set the picture box size mode to stretch the image
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


           // pictureBox.Size = new Size(200, 300);
            pictureBox.Location = new Point(300, 120);

            // Set the picture box to display the image
            pictureBox.Load();

            // Add the picture box to the form
            this.Controls.Add(pictureBox);

        }
    }
}
