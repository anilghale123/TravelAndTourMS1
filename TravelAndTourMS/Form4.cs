using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");
        public Form4()
        {
            InitializeComponent();
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
                    MessageBox.Show("Here is list");
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

            if (e.RowIndex >= 0)
            {
                var selectedHotel = dataGridView1.Rows[e.RowIndex].Cells["hotel"].Value.ToString();
                if (selectedHotel == "Marriot")
                {
                    this.Hide();
                    Form5 employeeform = new Form5();
                    employeeform.ShowDialog();
                }
                else if (selectedHotel == "Yeti")
                {
                    //Form hotelBForm = new Form();
                    // hotelBForm.Show();
                    this.Hide();
                    Form8 employeeform = new Form8();
                    employeeform.ShowDialog();
                }
                // Add more else if statements for each hotel you want to handle
            }

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
            Form5 employeeform = new Form5();
            employeeform.ShowDialog();
        }
    }
}
