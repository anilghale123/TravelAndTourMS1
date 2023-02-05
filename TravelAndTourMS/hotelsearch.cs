using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Win32;
using ZstdSharp.Unsafe;

namespace TravelAndTourMS
{
    public partial class hotelsearch : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");
        SqlCommand cmd;
        public hotelsearch()
        {
            InitializeComponent();
        }

        private void load_data()
        {
            cmd = new SqlCommand("Select * from Hotel order by id desc", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = dt;
            //  DataGridViewImageColumn Pic1 = new DataGridViewImageColumn();
            //  Pic1 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            // Pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "select count(*) from Hotel where place=@place and category=@category";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@place", place.Text);
                cmd.Parameters.AddWithValue("@category", categori.Text);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                   // MessageBox.Show("Here is list");
                    string query2 = "select * from Hotel where place='" + place.Text + "' and category='" + categori.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                   dataGridView1.Visible = true;

                }
                else
                {
                    MessageBox.Show("no data");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.InnerException);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            roomsearch employeeform = new roomsearch();
            employeeform.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void hotelsearch_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                if (e.RowIndex >= 0)
                {
                    var selectedHotel = dataGridView1.Rows[e.RowIndex].Cells["hotel"].Value.ToString();
                    if (selectedHotel == "Marriot" || selectedHotel == "marriot")
                    {
                        int selectedRowIndex = e.RowIndex;
                        string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
                        string place = dataGridView1.Rows[selectedRowIndex].Cells["place"].Value.ToString();
                    byte[] byteArray = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["photo"].Value;
                    Image image;
                    using (var ms = new MemoryStream(byteArray))
                    {
                        image = Image.FromStream(ms);
                    }

                    this.Hide();
                        marriot employeeform = new marriot(price, place, image);
                        employeeform.ShowDialog();
                    }

                    else if(selectedHotel == "Yeti" || selectedHotel == "yeti")
                          {
                    int selectedRowIndex = e.RowIndex;
                    string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
                    string place = dataGridView1.Rows[selectedRowIndex].Cells["place"].Value.ToString();
                    byte[] byteArray = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["photo"].Value;
                    Image image;
                    using (var ms = new MemoryStream(byteArray))
                    {
                        image = Image.FromStream(ms);
                    }


                    this.Hide();
                    marriot employeeform = new marriot(price, place,image);
                    employeeform.ShowDialog();

                }



                }
            

        }
    }
}
