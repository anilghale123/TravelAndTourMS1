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
    public partial class hotelbooking : Form
    {
        public hotelbooking(string a, string b, Image c)
        {
            InitializeComponent();
            textBox1.Text = a;
            textBox3.Text = b;
           
        }

        private void hotelbooking_Load(object sender, EventArgs e)
        {

        }
    }
}
