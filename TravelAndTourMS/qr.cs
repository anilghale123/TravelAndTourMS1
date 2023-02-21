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
    public partial class qr : Form
    {
        public qr(string a, string b, string c, string d, string e, string f, string g, Image x)
        {
            InitializeComponent();
            pictureBox1.Image = x;
        }

        private void qr_Load(object sender, EventArgs e)
        {

        }
    }
}
