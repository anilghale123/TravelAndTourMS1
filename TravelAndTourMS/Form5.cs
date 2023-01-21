using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAndTourMS
{

    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password =  anil123 ; ");
        int total = 0;
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

            MessageBox.Show("Total Price is :   " + total);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            total += 1000;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            total += 2000;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            total += 1000;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*  try
              {
                  con.Open();
                  string query = "select count(*) from Room where @checkInDate <= CheckOutDate and @checkOutDate >= CheckInDate and RoomType=@roomType and hotel=@hotel";

                  SqlCommand cmd = new SqlCommand(query, con);
                  cmd.Parameters.AddWithValue("@checkInDate", dtpCheckIn.Text);
                  cmd.Parameters.AddWithValue("@checkOutDate", dtpCheckOut.Text);
                  cmd.Parameters.AddWithValue("@roomType", cmbRoomType.Text.ToString());
                  cmd.Parameters.AddWithValue("@hotel", cmbHotel.Text.ToString());
                  int count = Convert.ToInt32(cmd.ExecuteScalar());
                  if (count > 0)
                  {
                      MessageBox.Show("Rooms available");
                  }
                  else
                  {
                      MessageBox.Show("Rooms not available");
                  }
                  con.Close();
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Error:" + ex.InnerException);
              }  */




            try
            {
                con.Open();
                string query = "SELECT RoomNum, RoomType, hotel, 'Available' as RoomAvailability FROM Room WHERE RoomType=@roomType and hotel=@hotel ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@checkInDate", dtpCheckIn.Text);
                cmd.Parameters.AddWithValue("@checkOutDate", dtpCheckOut.Text);
                cmd.Parameters.AddWithValue("@roomType", cmbRoomType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@hotel", cmbHotel.Text.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Rooms available");
                }
                else
                {
                    query = "SELECT RoomNum, RoomType, hotel, 'Not Available' as RoomAvailability FROM Room WHERE  (CheckInDate = @checkInDate and CheckOutDate = @checkOutDate) and RoomType=@roomType and hotel=@hotel";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@checkInDate", dtpCheckIn.Text);
                    cmd.Parameters.AddWithValue("@checkOutDate", dtpCheckOut.Text);
                    cmd.Parameters.AddWithValue("@roomType", cmbRoomType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@hotel", cmbHotel.Text.ToString());
                    adapter = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                   
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.InnerException);
            }
        }







    }

             
    }


