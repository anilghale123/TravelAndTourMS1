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
using Microsoft.Win32;

namespace TravelAndTourMS
{
    public partial class cab : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True; ");
        SqlCommand cmd;

        public cab()
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
       

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("INSERT INTO cab (Category,Name,price,photo) VALUES (@Category,@Name,@price,@photo)", con);
            cmd.Parameters.AddWithValue("Category", textBox1.Text);
            MemoryStream memstr = new MemoryStream();

            cmd.Parameters.AddWithValue("Name", textBox5.Text);
            cmd.Parameters.AddWithValue("price", textBox4.Text);
            


            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("photo", memstr.ToArray());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Added Successfullly");
            load_data();
        }

        private void cab_Load(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
