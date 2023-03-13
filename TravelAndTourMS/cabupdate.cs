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

namespace TravelAndTourMS
{
    public partial class cabupdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True; ");
        SqlCommand cmd;
        private DataGridViewRow _selectedRow;
        public cabupdate(DataGridViewRow selectedRow)
        {
            InitializeComponent();

            
            _selectedRow = selectedRow;

            textBox2.Text = _selectedRow.Cells["id"].Value.ToString();
            textBox1.Text = _selectedRow.Cells["type"].Value.ToString();
            textBox5.Text = _selectedRow.Cells["brand"].Value.ToString();
            textBox4.Text = _selectedRow.Cells["model"].Value.ToString();
            textBox9.Text = _selectedRow.Cells["seatnum"].Value.ToString();
            textBox7.Text = _selectedRow.Cells["number"].Value.ToString();
            textBox6.Text = _selectedRow.Cells["price"].Value.ToString();
            textBox11.Text = _selectedRow.Cells["feature"].Value.ToString();


            byte[] imageData = (byte[])_selectedRow.Cells["cab1"].Value;
            MemoryStream ms = new MemoryStream(imageData);
            pictureBox1.Image = System.Drawing.Image.FromStream(ms);

            byte[] imageData1 = (byte[])_selectedRow.Cells["cab2"].Value;
            MemoryStream ms1 = new MemoryStream(imageData1);
            pictureBox2.Image = System.Drawing.Image.FromStream(ms1);

            byte[] imageData2 = (byte[])_selectedRow.Cells["cab3"].Value;
            MemoryStream ms2 = new MemoryStream(imageData2);
            pictureBox4.Image = System.Drawing.Image.FromStream(ms2);

            byte[] imageData3 = (byte[])_selectedRow.Cells["qr"].Value;
            MemoryStream ms3 = new MemoryStream(imageData3);
            pictureBox3.Image = System.Drawing.Image.FromStream(ms3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("UPDATE cab SET  type = @type,brand = @brand,model = @model,seatnum = @seatnum,number = @number,cab1 = @cab1,cab2 = @cab2,cab3 = @cab3,feature = @feature,price = @price, qr = @qr WHERE id = @id", con);
            cmd.Parameters.AddWithValue("type", textBox1.Text);

            MemoryStream memstr = new MemoryStream();
            MemoryStream memstr1 = new MemoryStream();
            MemoryStream memstr2 = new MemoryStream();
            MemoryStream memstr3 = new MemoryStream();
          
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

            

            cmd.Parameters.AddWithValue("id", textBox2.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Updated Successfullly");

            this.Hide();
            cab form = new cab();
            form.ShowDialog();
        }

        private void cabupdate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

            }
        }
    }
}
