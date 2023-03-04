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
    public partial class tourupdate : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True; ");
        SqlCommand cmd;

        private DataGridViewRow _selectedRow;
        public tourupdate(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            _selectedRow = selectedRow;

            textBox3.Text = _selectedRow.Cells["id"].Value.ToString();
            textBox2.Text = _selectedRow.Cells["price"].Value.ToString();
            textBox1.Text = _selectedRow.Cells["package_name"].Value.ToString();
            richTextBox1.Text = _selectedRow.Cells["description"].Value.ToString();
           
            byte[] imageData = (byte[])_selectedRow.Cells["photo"].Value;
            MemoryStream ms = new MemoryStream(imageData);
            pictureBox1.Image = Image.FromStream(ms);

            byte[] imageData1 = (byte[])_selectedRow.Cells["photo1"].Value;
            MemoryStream ms1 = new MemoryStream(imageData1);
            pictureBox3.Image = Image.FromStream(ms1);

            byte[] imageData2 = (byte[])_selectedRow.Cells["photo2"].Value;
            MemoryStream ms2 = new MemoryStream(imageData2);
            pictureBox4.Image = Image.FromStream(ms2);

            byte[] imageData3 = (byte[])_selectedRow.Cells["qr"].Value;
            MemoryStream ms3 = new MemoryStream(imageData3);
            pictureBox2.Image = Image.FromStream(ms3);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("UPDATE Table1 SET package_name = @package_name,description = @description, price = @price, photo = @photo, photo1 = @photo1,photo2 = @photo2, qr = @qr  WHERE id = @id", con);
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

            cmd.Parameters.AddWithValue("id", textBox3.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Package Updated ");
            
            con.Close();

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

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

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

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }
    }
}
