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
          //  DataGridViewImageColumn Pic1 = new DataGridViewImageColumn();
          //  Pic1 = (DataGridViewImageColumn)dataGridView1.Columns[3];
           // Pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void image_Load(object sender, EventArgs e)
        {
            load_data();
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
           // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            /*  cmd = new SqlCommand("INSERT INTO Table1 (package_name,description,price,photo,photo1,photo2,qr) VALUES (@package_name,@description,@price,@photo,@photo1,@photo2,@qr)", con);
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
              load_data();*/
            this.Hide();
            touradmin form = new touradmin();
            form.ShowDialog();

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
           /* textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();





            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[4].Value);
            pictureBox1.Image = Image.FromStream(ms);

            MemoryStream ms1 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[5].Value);
            pictureBox3.Image = Image.FromStream(ms1);

            MemoryStream ms2 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[6].Value);
            pictureBox4.Image = Image.FromStream(ms2);

            MemoryStream ms3 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[7].Value);
            pictureBox2.Image = Image.FromStream(ms3);*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*cmd = new SqlCommand ( "UPDATE Table1 SET package_name = @package_name,description = @description, price = @price, photo = @photo, photo1 = @photo1,photo2 = @photo2, qr = @qr  WHERE id = @id", con);
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

            cmd.Parameters.AddWithValue("id", id1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Package Updated ");
            load_data();
            con.Close();*/
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // Pass the selected row data to the next form
                tourupdate form2 = new tourupdate(selectedRow);
                form2.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("DELETE FROM Table1 WHERE  id = @id", con);   
            cmd.Parameters.AddWithValue("id", id1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            load_data();
           /* pictureBox1.Image = null;
            textBox1.Text = "";
            id1.Text = "";*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 employeeform = new Form1();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       
       

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}
