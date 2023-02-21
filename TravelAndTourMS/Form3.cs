using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class Form3 : Form
    {
        private string aa;
        
        private string cc;
        private Image x;

        public Form3(string a, string b, string c, Image i1, Image i2, Image i3, Image i4)
        {
            InitializeComponent();
            pictureBox1.Image = i1;
            pictureBox2.Image = i2;
            pictureBox3.Image = i3;
            richTextBox1.Text = b;

            aa = a;
           
            cc = c;
            x = i4;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            tourbooking employeeform = new tourbooking(cc, aa,x);
            employeeform.ShowDialog();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            home form = new home();
            form.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            image1 form = new image1();
            form.ShowDialog();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            place form = new place();
            form.ShowDialog();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            aboutus form = new aboutus();
            form.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelsearch form = new hotelsearch();
            form.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabuser form = new cabuser();
            form.ShowDialog();
        }
    }
}
