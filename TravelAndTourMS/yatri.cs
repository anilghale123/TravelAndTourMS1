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
        private string e;
        private string f;

        private string g;

        private string h;
        private string i;
        private string j;


        private Image x1;
        private Image x2;
        private Image x3;
        private Image x4;
        private Image x5;

        public yatri(string v, string v1,string v2, string v3,string v4, Image i1,Image i2, Image i3, string v5, string v6, Image i4, string v7, string v8, string v9, Image i5)
        {
            InitializeComponent();
            a = v;
            b = v1;
            c = v2;
            d = v3;
            e = v4;
            f = v5;
            g = v6;
            h = v7;
            i = v8;
            j = v9;


            Image x1 = i1;
            Image x2 = i2;
            Image x3 = i3;
            Image x4 = i4;
            Image x5 = i5;
            label1.Text = v1;
            label2.Text = v2;
            richTextBox1.Text = v5;
            richTextBox2.Text = v6;
            pictureBox1.Image = x1;
            pictureBox2.Image = x2;
            pictureBox3.Image = x3;
           // pictureBox4.I

        }

        private void yatri_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabbooking employeeform = new cabbooking(a, b, c, d);
            employeeform.ShowDialog(); 
        }
    }
}
