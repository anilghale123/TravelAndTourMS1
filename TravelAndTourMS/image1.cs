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
    public partial class image1 : Form
    {
        public image1()
        {
            InitializeComponent();
        }

        private void image1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
            //SqlCommand cmd = new SqlCommand("SELECT id, name, image_path, bookNow FROM images2", con);
            SqlCommand cmd = new SqlCommand("SELECT id, package_name, price, Photo FROM Table1", con);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);

            // dt.Columns.Add("image", Type.GetType("System.Bytes[]"));
          //  dt.Columns.Add("image", typeof(byte[]));
          //  dt.Columns["bookNow"].SetOrdinal(dt.Columns.Count - 1);
           

            // dt.Columns.Add("image", typeof(System.Byte[]));
            foreach (DataRow drow in dt.Rows)
            {
                // drow["image"] = File.ReadAllBytes(drow["image_path"].ToString());
                // drow["image"] = drow["Photo"];

               // drow["bookNow"] = "Book Now";

            }


            dataGridView1.DataSource = dt;
            //  dataGridView1.Columns.Remove("image_path");
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dataGridView1.RowTemplate.Height = 200;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
                this.Hide();
                tourbooking employeeform = new tourbooking(price);
                employeeform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
