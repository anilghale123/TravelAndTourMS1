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
using System.Threading.Tasks;

namespace TravelAndTourMS
{
    public partial class image : Form
    {
       SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True; ");
        SqlCommand cmd;
        public image()
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
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn Pic1 = new DataGridViewImageColumn();
            Pic1 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            Pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void image_Load(object sender, EventArgs e)
        {
            load_data();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG;  *. png; *. Gif ";
              if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);     
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("INSERT INTO Table1 (package_name,price,Photo) VALUES (@package_name,@price,@Photo)", con);
            cmd.Parameters.AddWithValue("package_name", textBox1.Text);
            MemoryStream memstr = new MemoryStream();

            cmd.Parameters.AddWithValue("price", textBox2.Text);
            //MemoryStream memstr = new MemoryStream();


            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("Photo", memstr.ToArray());  
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Package Added Successfullly");
            load_data();

                }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)  
        {
           

        }

        private void id1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[3].Value);
            pictureBox1.Image = Image.FromStream(ms);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("UPDATE Table1 SET package_name = @package_name,price = @price, Photo = @Photo WHERE id = @id", con);
            cmd.Parameters.AddWithValue("package_name", textBox1.Text);
            MemoryStream memstr = new MemoryStream();

            cmd.Parameters.AddWithValue("price", textBox2.Text);

            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("Photo", memstr.ToArray());
            cmd.Parameters.AddWithValue("id", id1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Package Updated ");
            load_data();
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("DELETE FROM Table1 WHERE  id = @id", con);   
            cmd.Parameters.AddWithValue("id", id1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            load_data();
            pictureBox1.Image = null;
            textBox1.Text = "";
            id1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin employeeform = new admin();
            employeeform.ShowDialog();
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.Orange;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.Transparent;
        }
    }

}
