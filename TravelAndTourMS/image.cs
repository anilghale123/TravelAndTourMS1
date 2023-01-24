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
using MongoDB.Driver.Core.Configuration;

namespace TravelAndTourMS
{
    public partial class image : Form
    {
      //  SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ; ");
        public image()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "image_path")
            {
                string imagePath = e.Value as string;
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    Image image = Image.FromFile(imagePath);
                    e.Value = image;
                    e.FormattingApplied = true;
                }
            }

        }
        


        private void button1_Click(object sender, EventArgs e)
        {

          
            

        }

        private void image_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ; ");


            SqlCommand cmd = new SqlCommand("SELECT id, name, image_path FROM images1", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
          //  da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* try
            {
                using SqlConnection con = new SqlConnection();
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name, image_path FROM images1", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Add the data to a DataTable
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
