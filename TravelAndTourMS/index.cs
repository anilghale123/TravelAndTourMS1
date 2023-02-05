using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace TravelAndTourMS
{
    public partial class index : Form
    {

        System.Windows.Forms.Timer timer;
        int index1;
        int index2;
        string[] messages = { "WELCOME TO TOUR MANAGEMENT SYSTEM" };

        public index()

        {
            index1 = 0;
            index2 = 0;

            InitializeComponent();
           timer = new Timer();
            timer.Interval = 40; // animation interval in milliseconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            string message = messages[index1];
            if (index2 < message.Length)
            {
                label1.Text = message.Substring(0, index2 + 1);
                index2++;
            }
            else
            {
                if (index1 == messages.Length - 1)
                {
                    timer.Stop();
                }
                else
                {
                    index1 = (index1 + 1) % messages.Length;
                    index2 = 0;
                }
            }
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

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void index_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
        }
    }
}
