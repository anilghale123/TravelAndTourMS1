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
    public partial class hoteladd : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");
        SqlCommand cmd;
        public hoteladd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("INSERT INTO Hotel (place,hotel,description,amenities,price,room1name,room1price,room2name,room2price,room3name,room3price,room4name,room4price,picture1,picture2,picture3,picture4,room1,room2,room3,room4,qr) VALUES (@place,@hotel,@description,@amenities,@price,@room1name,@room1price,@room2name,@room2price,@room3name,@room3price,@room4name,@room4price,@picture1,@picture2,@picture3,@picture4,@room1,@room2,@room3,@room4,@qr)", con);
            cmd.Parameters.AddWithValue("place", place.Text);
            MemoryStream memstr = new MemoryStream();
            MemoryStream memstr1 = new MemoryStream();
            MemoryStream memstr2 = new MemoryStream();
            MemoryStream memstr3 = new MemoryStream();
            MemoryStream memstr4 = new MemoryStream();
            MemoryStream memstr5 = new MemoryStream();
            MemoryStream memstr6 = new MemoryStream();
            MemoryStream memstr7 = new MemoryStream();
            MemoryStream memstr8 = new MemoryStream();

            cmd.Parameters.AddWithValue("hotel", textBox6.Text);
            cmd.Parameters.AddWithValue("description", textBox8.Text);
            cmd.Parameters.AddWithValue("amenities", textBox2.Text);

            cmd.Parameters.AddWithValue("price", textBox3.Text);

            cmd.Parameters.AddWithValue("room1name", textBox13.Text);
            cmd.Parameters.AddWithValue("room1price", textBox4.Text);

            cmd.Parameters.AddWithValue("room2name", textBox12.Text);
            cmd.Parameters.AddWithValue("room2price", textBox5.Text);

            cmd.Parameters.AddWithValue("room3name", textBox11.Text);
            cmd.Parameters.AddWithValue("room3price", textBox7.Text);

            cmd.Parameters.AddWithValue("room4name", textBox10.Text);
            cmd.Parameters.AddWithValue("room4price", textBox9.Text);



            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("picture1", memstr.ToArray());

            pictureBox2.Image.Save(memstr1, pictureBox2.Image.RawFormat);
            cmd.Parameters.AddWithValue("picture2", memstr1.ToArray());

            pictureBox3.Image.Save(memstr2, pictureBox3.Image.RawFormat);
            cmd.Parameters.AddWithValue("picture3", memstr2.ToArray());

            pictureBox4.Image.Save(memstr3, pictureBox4.Image.RawFormat);
            cmd.Parameters.AddWithValue("picture4", memstr3.ToArray());

            pictureBox5.Image.Save(memstr4, pictureBox5.Image.RawFormat);
            cmd.Parameters.AddWithValue("room1", memstr4.ToArray());

            pictureBox6.Image.Save(memstr5, pictureBox6.Image.RawFormat);
            cmd.Parameters.AddWithValue("room2", memstr5.ToArray());

            pictureBox7.Image.Save(memstr6, pictureBox7.Image.RawFormat);
            cmd.Parameters.AddWithValue("room3", memstr6.ToArray());

            pictureBox8.Image.Save(memstr7, pictureBox8.Image.RawFormat);
            cmd.Parameters.AddWithValue("room4", memstr7.ToArray());

            pictureBox9.Image.Save(memstr8, pictureBox9.Image.RawFormat);
            cmd.Parameters.AddWithValue("qr", memstr8.ToArray());






            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Hotel Added Successfullly");
           
            this.Hide();
            hoteladmin form = new hoteladmin();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

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

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox9.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hoteladmin form = new hoteladmin();
            form.ShowDialog();
        }
    }
}
