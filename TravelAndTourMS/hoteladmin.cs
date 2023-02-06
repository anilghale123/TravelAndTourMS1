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
            load_data();
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            place.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            categori.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[5].Value);
            pictureBox1.Image = Image.FromStream(ms);
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

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("UPDATE Hotel SET place = @place,hotel=@hotel , category = @category,price = @price, photo = @photo WHERE id = @id", con);
            cmd.Parameters.AddWithValue("place", place.Text);
            MemoryStream memstr = new MemoryStream();

            cmd.Parameters.AddWithValue("hotel", textBox6.Text);
            cmd.Parameters.AddWithValue("category", categori.Text);
            cmd.Parameters.AddWithValue("price", textBox8.Text);



            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("photo", memstr.ToArray());

            cmd.Parameters.AddWithValue("id", id1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Package Updated ");
            load_data();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("DELETE FROM Hotel WHERE  id = @id", con);
            cmd.Parameters.AddWithValue("id", id1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            load_data();
            pictureBox1.Image = null;
            textBox8.Text = "";
            textBox6.Text = "";
            categori.Text = "";
            place.Text = "";
            id1.Text = "";
        }
    }
}
