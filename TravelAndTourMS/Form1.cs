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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.FromArgb(100, 0, 0, 0);
            
        }

        private void iconButton1_Paint(object sender, PaintEventArgs e)
        {
            iconButton1.BackColor = Color.FromArgb(90, 0, 0, 0);
        }
    }
}
