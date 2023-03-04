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

       
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
          /*  place.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox13.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            textBox11.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();

            textBox12.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();

            textBox10.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();







            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[6].Value);
            MemoryStream ms1 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[7].Value);
            MemoryStream ms2 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[8].Value);
            MemoryStream ms3 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[9].Value);
            MemoryStream ms4 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[12].Value);
            MemoryStream ms5 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[15].Value);
            MemoryStream ms6 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[18].Value);
            MemoryStream ms7 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[21].Value);
            MemoryStream ms8 = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[22].Value);


            pictureBox1.Image = Image.FromStream(ms);
            pictureBox2.Image = Image.FromStream(ms1);
            pictureBox3.Image = Image.FromStream(ms2);
            pictureBox4.Image = Image.FromStream(ms3);
            pictureBox5.Image = Image.FromStream(ms4);
            pictureBox6.Image = Image.FromStream(ms5);
            pictureBox7.Image = Image.FromStream(ms6);
            pictureBox8.Image = Image.FromStream(ms7);
            pictureBox9.Image = Image.FromStream(ms8);*/


        }
        private void button1_Click(object sender, EventArgs e)
        {
            /* cmd = new SqlCommand("INSERT INTO Hotel (place,hotel,description,amenities,price,room1name,room1price,room2name,room2price,room3name,room3price,room4name,room4price,picture1,picture2,picture3,picture4,room1,room2,room3,room4,qr) VALUES (@place,@hotel,@description,@amenities,@price,@room1name,@room1price,@room2name,@room2price,@room3name,@room3price,@room4name,@room4price,@picture1,@picture2,@picture3,@picture4,@room1,@room2,@room3,@room4,@qr)", con);
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
                      load_data();*/
            this.Hide();
            hoteladd form = new hoteladd();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* cmd = new SqlCommand("UPDATE Hotel SET place = @place,hotel=@hotel ,description = @description,amenities = @amenities, price = @price,room1name = @room1name,room1price = @room1price,room2name = @room2name,room2price = @room2price,room3name = @room3name,room3price = @room3price,room4name = @room4name,room4price = @room4price,picture1 = @picture1,picture2 = @picture2,picture3 = @picture3,picture4 = @picture4,room1 = @room1,room2 = @room2,room3 = @room3,room4 = @room4, qr = @qr  WHERE id = @id", con);
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
                hotelupdate form2 = new hotelupdate(selectedRow);
                form2.Show();
            }
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
          /*  pictureBox1.Image = null;
            textBox8.Text = "";
            textBox6.Text = "";
            //categori.Text = "";
            place.Text = "";
            id1.Text = "";*/
        }

       

      


        
    }
}
