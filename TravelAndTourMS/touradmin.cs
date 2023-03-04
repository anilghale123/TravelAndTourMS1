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
    public partial class touradmin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True; ");
        SqlCommand cmd;
        public touradmin()
        {
            InitializeComponent();
        }
        private void load_data()
        {
            cmd = new SqlCommand("Select * from Table1 order by id desc", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
         //   dataGridView1.RowTemplate.Height = 100;
          //  dataGridView1.DataSource = dt;
            //  DataGridViewImageColumn Pic1 = new DataGridViewImageColumn();
            //  Pic1 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            // Pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("INSERT INTO Table1 (package_name,description,price,photo,photo1,photo2,qr) VALUES (@package_name,@description,@price,@photo,@photo1,@photo2,@qr)", con);
            cmd.Parameters.AddWithValue("package_name", textBox1.Text);
            MemoryStream memstr = new MemoryStream();
            MemoryStream memstr1 = new MemoryStream();
            MemoryStream memstr2 = new MemoryStream();
            MemoryStream memstr3 = new MemoryStream();

            cmd.Parameters.AddWithValue("price", textBox2.Text);
            cmd.Parameters.AddWithValue("description", richTextBox1.Text);



            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("photo", memstr.ToArray());

            pictureBox3.Image.Save(memstr1, pictureBox3.Image.RawFormat);
            cmd.Parameters.AddWithValue("photo1", memstr1.ToArray());

            pictureBox4.Image.Save(memstr2, pictureBox4.Image.RawFormat);
            cmd.Parameters.AddWithValue("photo2", memstr2.ToArray());

            pictureBox2.Image.Save(memstr3, pictureBox2.Image.RawFormat);
            cmd.Parameters.AddWithValue("qr", memstr3.ToArray());



            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Package Added Successfullly");

            
            load_data();
            this.Hide();
            image form = new image();
            form.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }
    }
}
