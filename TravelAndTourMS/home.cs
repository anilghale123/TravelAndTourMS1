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
    public partial class home : Form
    {
        private Dictionary<Control, Size> originalSizes;
        private Dictionary<Control, Point> originalLocations;
        private Size originalFormSize;

        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelsearch employeeform = new hotelsearch();
            employeeform.ShowDialog();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelsearch employeeform = new hotelsearch();
            employeeform.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            placeinfo2 employeeform = new placeinfo2();
            employeeform.ShowDialog();
        }

        private void home_Load(object sender, EventArgs e)
        {
            // Store the original size and location of the controls
            originalSizes = new Dictionary<Control, Size>();
            originalLocations = new Dictionary<Control, Point>();
            foreach (Control control in this.Controls)
            {
                originalSizes[control] = control.Size;
                originalLocations[control] = control.Location;
            }

            // Store the original size of the form
            originalFormSize = this.ClientSize;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            place employeeform = new place();
            employeeform.ShowDialog();*/

            place employeeform = new place();
            employeeform.ShowDialog(); 



        }

        private void iconButton10_MouseEnter(object sender, EventArgs e)
        {
            iconButton10.BackColor = Color.Orange;
        }

        private void iconButton10_MouseLeave(object sender, EventArgs e)
        {
            iconButton10.BackColor = Color.Transparent;
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.BackColor = Color.Orange;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.BackColor = Color.Transparent;
        }

        private void iconButton7_MouseEnter(object sender, EventArgs e)
        {
            iconButton7.BackColor = Color.Orange;
        }

        private void iconButton7_MouseLeave(object sender, EventArgs e)
        {
            iconButton7.BackColor = Color.Transparent;
        }

        private void iconButton8_MouseEnter(object sender, EventArgs e)
        {
            iconButton8.BackColor = Color.Orange;
        }

        private void iconButton8_MouseLeave(object sender, EventArgs e)
        {
            iconButton8.BackColor = Color.Transparent;
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
           aboutus employeeform = new aboutus();
            employeeform.ShowDialog();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            login employeeform = new login();
            employeeform.ShowDialog();
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            //iconButton1.BackColor = Color.Orange;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
           // iconButton1.BackColor = Color.Transparent;
        }

        private void home_Resize(object sender, EventArgs e)
        {
            // Calculate the scale factor
            float scaleX = (float)this.ClientSize.Width / (float)originalFormSize.Width;
            float scaleY = (float)this.ClientSize.Height / (float)originalFormSize.Height;

            // Resize and reposition the controls
            foreach (Control control in this.Controls)
            {
                control.Size = new Size((int)(originalSizes[control].Width * scaleX), (int)(originalSizes[control].Height * scaleY));
                control.Location = new Point((int)(originalLocations[control].X * scaleX), (int)(originalLocations[control].Y * scaleY));
            }
        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            hotel employeeform = new hotel();
            employeeform.ShowDialog();
        }

        private void iconButton2_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            cabuser employeeform = new cabuser();
            employeeform.ShowDialog();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            login employeeform = new login();
            employeeform.ShowDialog();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Orange;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Transparent;
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Orange;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Transparent;
        }

        private void iconButton5_MouseEnter(object sender, EventArgs e)
        {
            iconButton5.BackColor = Color.Orange;
        }

        private void iconButton5_MouseLeave(object sender, EventArgs e)
        {
            iconButton5.BackColor = Color.Transparent;
        }
    }
}
