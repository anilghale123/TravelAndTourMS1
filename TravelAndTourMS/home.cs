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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelsearch employeeform = new hotelsearch();
            employeeform.ShowDialog();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelsearch employeeform = new hotelsearch();
            employeeform.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            image1 employeeform = new image1();
            employeeform.ShowDialog();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }
    }
}
