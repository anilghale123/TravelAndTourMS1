using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircularProgressBar_NET5;
using MongoDB.Driver.Core.Configuration;
using CircularProgressBar;
using WinFormAnimation;
using LiveCharts.Wpf;
using LiveCharts;
//using System.Windows.Forms.DataVisualization.Charting;


namespace TravelAndTourMS
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
        SqlCommand cmd;
        // SqlCommand cmd1;
        public Form1()
        {
            InitializeComponent();





            decimal count = 0;
            decimal tc = 0;
            int count1 = 0;
            int count2 = 0;
            con.Open();
            cmd = new SqlCommand("Select * from hotelBooking", con);
            SqlDataReader read = null;
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                count++;
            }
            tc = count;
            label7.Text = count.ToString();
            cmd.Dispose();
            read.Close();




            cmd = new SqlCommand("Select * from TBook", con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                count1++;
            }
            label10.Text = count1.ToString();
            read.Close();

            cmd = new SqlCommand("Select * from cabBooking", con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                count2++;
            }
            label8.Text = count2.ToString();
            read.Close();

            // SqlCommand cmd;
            //  SqlDataReader read;
            decimal totalPrice = 0;
            string connectionString = (@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True; ");
            string sql = "SELECT SUM(TotalPrice) FROM cabBooking WHERE YEAR(StartTime) = 2023";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                cmd = new SqlCommand(sql, con);
                read = cmd.ExecuteReader();
                if (read.Read() && !read.IsDBNull(0))
                {
                    totalPrice = read.GetDecimal(0);
                }
                read.Close();
            }

            label3.Text = totalPrice.ToString("N2");





            // Create a new PieChart control and add it to the form
            var chart = new LiveCharts.WinForms.PieChart();
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);

            Panel panel = new Panel();
            panel.Controls.Add(chart);
            panel.Location = new Point(1300, 450); // set the location of the panel
            panel.Size = new Size(300, 300); // set the size of the panel
            this.Controls.Add(panel);

            // Set the data for the chart
            chart.Series.Add(new PieSeries
            {
                Title = "Upasana Expense ",
                Values = new ChartValues<decimal> {15 },
                DataLabels = true
            });
            chart.Series.Add(new PieSeries
            {
                Title = "Sova Expense",
                Values = new ChartValues<decimal> { tc },
                DataLabels = true
            });
            chart.Series.Add(new PieSeries
            {
                Title = "Rinjha Expense",
                Values = new ChartValues<double> { 30 },
                DataLabels = true
            });
            chart.Series.Add(new PieSeries
            {
                Title = "Srijana Expense",
                Values = new ChartValues<double> { 15 },
                DataLabels = true
            });




        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //iconButton1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        private void iconButton1_Paint(object sender, PaintEventArgs e)
        {
            // iconButton1.BackColor = Color.FromArgb(90, 0, 0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            image form = new image();
            form.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hoteladmin form = new hoteladmin();
            form.ShowDialog();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cab form = new cab();
            form.ShowDialog();
        }

        private void iconButton10_MouseEnter(object sender, EventArgs e)
        {
            iconButton10.BackColor = Color.Orange;
        }

        private void iconButton10_MouseLeave(object sender, EventArgs e)
        {
            iconButton10.BackColor = Color.Transparent;
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.BackColor = Color.Orange;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.BackColor = Color.Transparent;
        }

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Orange;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Transparent;
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Orange;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Transparent;
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.Orange;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.Transparent;
        }

        private void iconButton5_MouseEnter(object sender, EventArgs e)
        {
            iconButton5.BackColor = Color.Orange;
        }

        private void iconButton5_MouseLeave(object sender, EventArgs e)
        {
            iconButton5.BackColor = Color.Transparent;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
