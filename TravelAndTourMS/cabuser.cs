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
    public partial class cabuser : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");
        SqlCommand cmd;
        public cabuser()
        {
            InitializeComponent();
        }

        private void load_data()
        {
            cmd = new SqlCommand("Select * from cab order by id desc", con);
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


        private void cabuser_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var selectedCab = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                if (selectedCab == "Yatri" || selectedCab == "yatri")
                {
                    int selectedRowIndex = e.RowIndex;
                    string Category = dataGridView1.Rows[selectedRowIndex].Cells["Category"].Value.ToString();
                    string Name = dataGridView1.Rows[selectedRowIndex].Cells["Name"].Value.ToString();
                    string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();

                    byte[] byteArray = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["photo"].Value;
                    Image image;
                    using (var ms = new MemoryStream(byteArray))
                    {
                        image = Image.FromStream(ms);
                    }

                    this.Hide();
                    yatri employeeform = new yatri (Category, Name,price, image);
                    employeeform.ShowDialog();
                }
            }

            }
    }
}
