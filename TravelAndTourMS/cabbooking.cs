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
    public partial class cabbooking : Form
    {
        public cabbooking(string a, string b, string c, Image d)
        {
            InitializeComponent();
            PhoneNum.Text = a;
            Naam.Text = b;
            textBox1.Text = c;
        }

        private void cabbooking_Load(object sender, EventArgs e)
        {

        }
    }
}
