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

        public Form3(string a, string b, string c, Image i1, Image i2, Image i3, Image i4)
        {
            InitializeComponent();
            pictureBox1.Image = i1;
            pictureBox2.Image = i2;
            pictureBox3.Image = i3;
            richTextBox1.Text = b;

            aa = a;
           
            cc = c;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            tourbooking employeeform = new tourbooking(cc, aa);
            employeeform.ShowDialog();
        }
    }
}
