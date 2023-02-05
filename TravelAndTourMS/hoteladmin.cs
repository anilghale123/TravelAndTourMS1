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
    public partial class hoteladmin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");
        SqlCommand cmd;
        public hoteladmin()
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


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("INSERT INTO Hotel (place,hotel,category,price,photo) VALUES (@place,@hotel,@category,@price,@photo)", con);
            cmd.Parameters.AddWithValue("place", place.Text);
            MemoryStream memstr = new MemoryStream();

            cmd.Parameters.AddWithValue("hotel", textBox6.Text);
            cmd.Parameters.AddWithValue("category", categori.Text);
            cmd.Parameters.AddWithValue("price", textBox8.Text);



            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("photo", memstr.ToArray());

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Hotel Added Successfullly");
            load_data();
        }
    }
}
