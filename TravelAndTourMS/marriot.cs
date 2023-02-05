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
    public partial class marriot : Form
    {
        private string a;
        private string b;
        private Image c;

        public marriot(string value, string value1,Image value2)
        {
            InitializeComponent();
            textBox1.Text = value;
            textBox2.Text = value1;
            pictureBox1.Image = value2;
                a = value;
             b = value1;
            Image c = value2;

        }

        public void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking employeeform = new hotelbooking (a,b,c);
            employeeform.ShowDialog();
        }
    }
}
