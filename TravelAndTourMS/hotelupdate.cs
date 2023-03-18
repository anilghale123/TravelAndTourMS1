using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace TravelAndTourMS
{
    public partial class hotelupdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");
        SqlCommand cmd;

        private DataGridViewRow _selectedRow;
        public hotelupdate(DataGridViewRow selectedRow)
        {
            InitializeComponent();

            _selectedRow = selectedRow;

            textBox1.Text = _selectedRow.Cells["id"].Value.ToString();
            textBox6.Text = _selectedRow.Cells["hotel"].Value.ToString();
            place.Text = _selectedRow.Cells["place"].Value.ToString();
            textBox8.Text = _selectedRow.Cells["description"].Value.ToString();
            textBox2.Text = _selectedRow.Cells["amenities"].Value.ToString();
            textBox3.Text = _selectedRow.Cells["price"].Value.ToString();

            textBox13.Text = _selectedRow.Cells["room1name"].Value.ToString();
            textBox4.Text = _selectedRow.Cells["room1price"].Value.ToString();

            textBox12.Text = _selectedRow.Cells["room2name"].Value.ToString();
            textBox5.Text = _selectedRow.Cells["room2price"].Value.ToString();

            textBox11.Text = _selectedRow.Cells["room3name"].Value.ToString();
            textBox7.Text = _selectedRow.Cells["room3price"].Value.ToString();

            textBox10.Text = _selectedRow.Cells["room4name"].Value.ToString();
            textBox9.Text = _selectedRow.Cells["room4price"].Value.ToString();




            byte[] imageData = (byte[])_selectedRow.Cells["picture1"].Value;
            MemoryStream ms = new MemoryStream(imageData);
            pictureBox1.Image = System.Drawing.Image.FromStream(ms);

            byte[] imageData1 = (byte[])_selectedRow.Cells["picture2"].Value;
            MemoryStream ms1 = new MemoryStream(imageData1);
            pictureBox3.Image = System.Drawing.Image.FromStream(ms1);

            byte[] imageData2 = (byte[])_selectedRow.Cells["picture3"].Value;
            MemoryStream ms2 = new MemoryStream(imageData2);
            pictureBox4.Image = System.Drawing.Image.FromStream(ms2);

            byte[] imageData3 = (byte[])_selectedRow.Cells["picture4"].Value;
            MemoryStream ms3 = new MemoryStream(imageData3);
            pictureBox2.Image = System.Drawing.Image.FromStream(ms3);

            byte[] imageData4 = (byte[])_selectedRow.Cells["room1"].Value;
            MemoryStream ms4 = new MemoryStream(imageData4);
            pictureBox5.Image = System.Drawing.Image.FromStream(ms4);

            byte[] imageData5 = (byte[])_selectedRow.Cells["room2"].Value;
            MemoryStream ms5 = new MemoryStream(imageData5);
            pictureBox6.Image = System.Drawing.Image.FromStream(ms5);

            byte[] imageData6 = (byte[])_selectedRow.Cells["room3"].Value;
            MemoryStream ms6 = new MemoryStream(imageData6);
            pictureBox7.Image = System.Drawing.Image.FromStream(ms6);

            byte[] imageData7 = (byte[])_selectedRow.Cells["room4"].Value;
            MemoryStream ms7 = new MemoryStream(imageData7);
            pictureBox8.Image = System.Drawing.Image.FromStream(ms7);

            byte[] imageData8 = (byte[])_selectedRow.Cells["qr"].Value;
            MemoryStream ms8 = new MemoryStream(imageData8);
            pictureBox9.Image = System.Drawing.Image.FromStream(ms8);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("UPDATE Hotel SET place = @place,hotel=@hotel ,description = @description,amenities = @amenities, price = @price,room1name = @room1name,room1price = @room1price,room2name = @room2name,room2price = @room2price,room3name = @room3name,room3price = @room3price,room4name = @room4name,room4price = @room4price,picture1 = @picture1,picture2 = @picture2,picture3 = @picture3,picture4 = @picture4,room1 = @room1,room2 = @room2,room3 = @room3,room4 = @room4, qr = @qr  WHERE id = @id", con);
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



            cmd.Parameters.AddWithValue("id", textBox1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Package Updated ");
            
            con.Close();
            this.Hide();
            hoteladmin form = new hoteladmin();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image =System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox9.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hoteladmin form = new hoteladmin();
            form.ShowDialog();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
