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
    
    public partial class Form5 : Form
    {
        int total=0;
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 employeeform = new Form4();
            employeeform.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 employeeform = new Form6();
            employeeform.ShowDialog();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           total += 2000;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Total Price is :   "+total);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            total += 1000;
        }
    }
}
