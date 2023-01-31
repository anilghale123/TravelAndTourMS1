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
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login employeeform = new login();
            employeeform.ShowDialog();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin employeeform = new admin();
            employeeform.ShowDialog();

        }
    }
}
