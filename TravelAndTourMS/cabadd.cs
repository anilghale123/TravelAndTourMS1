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
    public partial class cabadd : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True; ");
        SqlCommand cmd;
        public cabadd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("INSERT INTO cab (type,brand,model,seatnum,number,cab1,cab2,cab3,feature,price,qr) VALUES " +
               "(@type,@brand,@model,@seatnum,@number,@cab1,@cab2,@cab3,@feature,@price,@qr)", con);

            cmd.Parameters.AddWithValue("type", textBox1.Text);


            MemoryStream memstr = new MemoryStream();
            MemoryStream memstr1 = new MemoryStream();
            MemoryStream memstr2 = new MemoryStream();
            MemoryStream memstr3 = new MemoryStream();
            MemoryStream memstr4 = new MemoryStream();
            

            cmd.Parameters.AddWithValue("brand", textBox5.Text);
            cmd.Parameters.AddWithValue("model", textBox4.Text);
            cmd.Parameters.AddWithValue("seatnum", textBox9.Text);
            cmd.Parameters.AddWithValue("number", textBox7.Text);
            cmd.Parameters.AddWithValue("feature", textBox11.Text);
           
            cmd.Parameters.AddWithValue("price", textBox6.Text);
            



            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab1", memstr.ToArray());

            pictureBox2.Image.Save(memstr1, pictureBox2.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab2", memstr1.ToArray());

            pictureBox3.Image.Save(memstr2, pictureBox3.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab3", memstr2.ToArray());

            pictureBox4.Image.Save(memstr3, pictureBox4.Image.RawFormat);
            cmd.Parameters.AddWithValue("qr", memstr3.ToArray());

          

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Added Successfullly");

            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
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
                pictureBox4.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }
    }
}
