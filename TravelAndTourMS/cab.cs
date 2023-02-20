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
       

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("INSERT INTO cab (type,brand,model,seatnum,number,cab1,cab2,cab3,feature,driverinfo,driver,price,offerinfo,offerprice,offer,qr,Status) VALUES " +
                "(@type,@brand,@model,@seatnum,@number,@cab1,@cab2,@cab3,@feature,@driverinfo,@driver,@price,@offerinfo,@offerprice,@offer,@qr,@Status)", con);
           
                 cmd.Parameters.AddWithValue("type", textBox1.Text);


            MemoryStream memstr = new MemoryStream();
            MemoryStream memstr1 = new MemoryStream();
            MemoryStream memstr2 = new MemoryStream();
            MemoryStream memstr3 = new MemoryStream();
            MemoryStream memstr4 = new MemoryStream();
            MemoryStream memstr5 = new MemoryStream();

            cmd.Parameters.AddWithValue("brand", textBox5.Text);
            cmd.Parameters.AddWithValue("model", textBox4.Text);
            cmd.Parameters.AddWithValue("seatnum", textBox9.Text);
            cmd.Parameters.AddWithValue("number", textBox7.Text);
            cmd.Parameters.AddWithValue("feature", textBox11.Text);
            cmd.Parameters.AddWithValue("driverinfo", textBox10.Text);
            cmd.Parameters.AddWithValue("price", textBox6.Text);
            cmd.Parameters.AddWithValue("offerinfo", textBox3.Text);
            cmd.Parameters.AddWithValue("offerprice", textBox2.Text);
            cmd.Parameters.AddWithValue("Status", comboBox1.Text);




            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab1", memstr.ToArray());

            pictureBox2.Image.Save(memstr1, pictureBox2.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab2", memstr1.ToArray());

            pictureBox3.Image.Save(memstr2, pictureBox3.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab3", memstr2.ToArray());

            pictureBox4.Image.Save(memstr3, pictureBox4.Image.RawFormat);
            cmd.Parameters.AddWithValue("driver", memstr3.ToArray());

            pictureBox5.Image.Save(memstr4, pictureBox5.Image.RawFormat);
            cmd.Parameters.AddWithValue("offer", memstr4.ToArray());

            pictureBox6.Image.Save(memstr5, pictureBox6.Image.RawFormat);
            cmd.Parameters.AddWithValue("qr", memstr5.ToArray());

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Added Successfullly");
            load_data();
        }

        private void cab_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
                pictureBox5.Image = Image.FromFile(openFileDialog1.FileName);

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

        private void button9_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("UPDATE cab SET  type = @type,brand = @brand,model = @model,seatnum = @seatnum,number = @number,cab1 = @cab1,cab2 = @cab2,cab3 = @cab3,feature = @feature,driverinfo = @driverinfo,driver = @driver,price = @price,offerinfo = @offerinfo,offerprice = @offerprice,offer = @offer, qr = @qr, Status = @Status WHERE id = @id", con);
            cmd.Parameters.AddWithValue("type", textBox1.Text);

            MemoryStream memstr = new MemoryStream();
            MemoryStream memstr1 = new MemoryStream();
            MemoryStream memstr2 = new MemoryStream();
            MemoryStream memstr3 = new MemoryStream();
            MemoryStream memstr4 = new MemoryStream();
            MemoryStream memstr5 = new MemoryStream();
            MemoryStream memstr6 = new MemoryStream();
            MemoryStream memstr7 = new MemoryStream();

            cmd.Parameters.AddWithValue("brand", textBox5.Text);
            cmd.Parameters.AddWithValue("model", textBox4.Text);
            cmd.Parameters.AddWithValue("seatnum", textBox9.Text);
            cmd.Parameters.AddWithValue("number", textBox7.Text);
            cmd.Parameters.AddWithValue("feature", textBox11.Text);
            cmd.Parameters.AddWithValue("driverinfo", textBox10.Text);
            cmd.Parameters.AddWithValue("price", textBox6.Text);
            cmd.Parameters.AddWithValue("offerinfo", textBox3.Text);
            cmd.Parameters.AddWithValue("offerprice", textBox2.Text);
            cmd.Parameters.AddWithValue("Status", comboBox1.Text);




            pictureBox1.Image.Save(memstr, pictureBox1.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab1", memstr.ToArray());

            pictureBox2.Image.Save(memstr1, pictureBox2.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab2", memstr1.ToArray());

            pictureBox3.Image.Save(memstr2, pictureBox3.Image.RawFormat);
            cmd.Parameters.AddWithValue("cab3", memstr2.ToArray());

            pictureBox4.Image.Save(memstr3, pictureBox4.Image.RawFormat);
            cmd.Parameters.AddWithValue("driver", memstr3.ToArray());

            pictureBox5.Image.Save(memstr4, pictureBox5.Image.RawFormat);
            cmd.Parameters.AddWithValue("offer", memstr4.ToArray());

            pictureBox6.Image.Save(memstr5, pictureBox6.Image.RawFormat);
            cmd.Parameters.AddWithValue("qr", memstr5.ToArray());

            cmd.Parameters.AddWithValue("id", id1.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Updated Successfullly");
            load_data();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
         textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();




            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[6].Value);
            MemoryStream ms1 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[7].Value);
            MemoryStream ms2 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[8].Value);
            MemoryStream ms3 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[11].Value);
            MemoryStream ms4 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[15].Value);
            MemoryStream ms5 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[16].Value);



            pictureBox1.Image = Image.FromStream(ms);
            pictureBox2.Image = Image.FromStream(ms1);
            pictureBox3.Image = Image.FromStream(ms2);
            pictureBox4.Image = Image.FromStream(ms3);
            pictureBox5.Image = Image.FromStream(ms4);
            pictureBox6.Image = Image.FromStream(ms5);







        }

        private void button8_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("DELETE FROM cab WHERE  id = @id", con);
            cmd.Parameters.AddWithValue("id", id1.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            load_data();
            pictureBox1.Image = null;
            //textBox8.Text = "";
            textBox6.Text = "";
            //categori.Text = "";
          //  place.Text = "";
            id1.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Select image(*.JpG;*.jpeg*.; png; *. Gif) | *.JpG; *. jpeg;  *. png; *. Gif ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox6.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }
    }
}
