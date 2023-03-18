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
       

     

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabadd form = new cabadd();
            form.ShowDialog();
        }

        private void cab_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      

       

      

        

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // Pass the selected row data to the next form
                cabupdate form2 = new cabupdate(selectedRow);
                form2.Show();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            try
            {
                id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
               /* textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
              




                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[6].Value);
                MemoryStream ms1 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[7].Value);
                MemoryStream ms2 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[8].Value);

                textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

                MemoryStream ms3 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[11].Value);

                pictureBox1.Image = Image.FromStream(ms);
                pictureBox2.Image = Image.FromStream(ms1);
                pictureBox3.Image = Image.FromStream(ms2);
                pictureBox4.Image = Image.FromStream(ms3);*/
               
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\n\n" + ex.StackTrace);
            }






        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
                {
                con.Open();
                cmd = new SqlCommand("DELETE FROM cab WHERE  id = @id", con);
                cmd.Parameters.AddWithValue("id", id1.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load_data();
               
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\n\n" + ex.StackTrace);
            }



        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();

        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            image form = new image();
            form.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hoteladmin form = new hoteladmin();
            form.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cab form = new cab();
            form.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            User form = new User();
            form.ShowDialog();

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Headmin form = new Headmin();
            form.ShowDialog();
        }
    }
}
