using System;
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
    public partial class Form13 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ; ");
        public Form13()
        {
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // code to check the availability of the selected room

            try
            {
                con.Open();
                string query = "select Count(*) from Room1";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@RoomNum", RoomNum.ToString);
                //cmd.Parameters.AddWithValue("@category", categori.Text);
                int Count = Convert.ToInt32(cmd.ExecuteScalar());



                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string roomNumber = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string query1 = "SELECT * FROM Room1";                                             //WHERE RoomNum = '\" + roomNumber + \"'\"
                    SqlCommand cmd2 = new SqlCommand(query1, con);




                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    dataGridView1.DataSource = dt;

                    dataGridView1.Visible = true;

                    //  con.Open();


                    //  string availability = cmd.ExecuteScalar().ToString();
                    string availability = cmd2.ExecuteScalar().ToString();

                    // con.Close();

                    if (availability == "True")
                    {
                        MessageBox.Show(roomNumber + " is available.");
                    }
                    else
                    {
                        MessageBox.Show(roomNumber + " is not available.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room number.");
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.InnerException);
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {

            

                // code to book the selected room
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string roomNumber = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string query = "UPDATE Room1 SET Available = 'False' WHERE RoomNum = '" + roomNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show(roomNumber + " is booked successfully.");
                    // RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Please select a room number.");
                }

                
        

            
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            // code to cancel the selected room
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string roomNumber = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string query = "UPDATE Room1 SET Available = 'True' WHERE RoomNum = '" + roomNumber + "'";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(roomNumber + " is cancel successfully.");
                // RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Please select a room number.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
