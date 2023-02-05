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
        private Image d;

        public yatri(string value, string value1,string value2, Image value3)
        {
            InitializeComponent();
            a = value;
            b = value1;
            c = value2;
            Image d = value3;
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
