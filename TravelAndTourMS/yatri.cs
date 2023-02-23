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
    public partial class yatri : Form
    {
        private string a;
        private string b;
        private string c;

        private string d;
        private string ee;
        private string f;

        private string g;

        private string h;
        private string i;
        private string j;
     //   private string k;


        private Image x1;
        private Image x2;
        private Image x3;
        private Image x4;
        private Image x5;
        private Image x6;

        public yatri(string v, string v1,string v2, string v3,string v4, Image i1,Image i2, Image i3, string v5, string v6, Image i4, string v7, string v8, string v9, Image i5, Image i6)
        {
            InitializeComponent();
            a = v;
            b = v1;
            c = v2;
            d = v3;
            ee = v4;
            f = v5;
            g = v6;
            h = v7;
            i = v8;
            j = v9;


            x1 = i1;
             x2 = i2;
           x3 = i3;
             x4 = i4;
           x5 = i5;
            x6 = i6;
           
            label1.Text = v1;
            label2.Text = v2;
            richTextBox1.Text = v5;
           
            pictureBox1.Image = x1;
            pictureBox2.Image = x2;
            pictureBox3.Image = x3;
            label3.Text = v7;
           
           // pictureBox4.I

        }

        private void yatri_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabbooking employeeform = new cabbooking(a, b, c, d, ee, x1, x2, x3, f, g, x4, h, i, j, x5, x6);
            employeeform.ShowDialog(); 
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {

            

            this.Hide();
            driver employeeform = new driver(a,b,c,d,ee,x1,x2,x3,f,g,x4,h,i,j,x5,x6);
            employeeform.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Orange;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Transparent;
        }

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Orange;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Transparent;
        }
    }
}
