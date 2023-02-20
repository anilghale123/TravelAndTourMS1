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
using MongoDB.Driver.Core.Configuration;

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
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            con.Open();
            cmd = new SqlCommand("Select * from hotelBooking", con);
            SqlDataReader read = null;
            read=cmd.ExecuteReader();
            while(read.Read())
            {
                count++;
            }
            label7.Text=count.ToString();
           cmd.Dispose();
            read.Close();



            
            cmd = new SqlCommand("Select * from TBook", con);
             read=cmd.ExecuteReader();
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
    }
}
