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
    public partial class hotelroom : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;
        string id;

        public hotelroom(string id)
        {
            InitializeComponent();
            string place = "";
            string hotel = "";
            string description = "";
            string amenities = "";
            int price;
            Image picture1 = null;
            Image picture2 = null;
            Image picture3 = null;
            Image picture4 = null;

            string room1name = "";
            string room1price = "";
            Image room1 = null;

            string room2name = "";
            string room2price = "";
            Image room2 = null;

            string room3name = "";
            string room3price = "";
            Image room3 = null;

            string room4name = "";
            string room4price = "";
            Image room4 = null;

            //  Image qr = null;
            // this.package_name = package_name;

            //  this.description = description;
            this.id = id;
            //  label1.Text = id;


            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Hotel WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    place = reader.GetString(1);
                    hotel = reader.GetString(2);
                    description = reader.GetString(3);
                    amenities = reader.GetString(4);

                    price = reader.GetInt32(5);



                    // Convert the byte array to an Image object
                    byte[] photo1Bytes = (byte[])reader.GetValue(6);
                    using (MemoryStream ms = new MemoryStream(photo1Bytes))
                    {
                        picture1 = Image.FromStream(ms);
                    }

                    // Convert the byte array to an Image object
                    byte[] photo2Bytes = (byte[])reader.GetValue(7);
                    using (MemoryStream ms = new MemoryStream(photo2Bytes))
                    {
                        picture2 = Image.FromStream(ms);
                    }

                    byte[] photo3Bytes = (byte[])reader.GetValue(8);
                    using (MemoryStream ms = new MemoryStream(photo3Bytes))
                    {
                        picture3 = Image.FromStream(ms);
                    }


                    byte[] photo4Bytes = (byte[])reader.GetValue(9);
                    using (MemoryStream ms = new MemoryStream(photo4Bytes))
                    {
                        picture4 = Image.FromStream(ms);
                    }




                    room1name = reader.GetString(10);
                    room1price = reader.GetString(11);
                    byte[] photo5Bytes = (byte[])reader.GetValue(12);
                    using (MemoryStream ms = new MemoryStream(photo5Bytes))
                    {
                        room1 = Image.FromStream(ms);
                    }


                    room2name = reader.GetString(13);
                    room2price = reader.GetString(14);
                    byte[] photo6Bytes = (byte[])reader.GetValue(15);
                    using (MemoryStream ms = new MemoryStream(photo6Bytes))
                    {
                        room2 = Image.FromStream(ms);
                    }


                    room3name = reader.GetString(16);
                    room3price = reader.GetString(17);
                    byte[] photo7Bytes = (byte[])reader.GetValue(18);
                    using (MemoryStream ms = new MemoryStream(photo7Bytes))
                    {
                        room3 = Image.FromStream(ms);
                    }


                    room4name = reader.GetString(19);
                    room4price = reader.GetString(20);
                    byte[] photo8Bytes = (byte[])reader.GetValue(21);
                    using (MemoryStream ms = new MemoryStream(photo8Bytes))
                    {
                        room4 = Image.FromStream(ms);
                    }





                }

                reader.Close();
            }

            // Assign the data to the controls on Form2
            label1.Text = hotel;
            label8.Text = room1price;
            // label1.Text = price;
            richTextBox1.Text = description;
            pictureBox1.Image = picture1;
            pictureBox2.Image = picture2;
            pictureBox3.Image = picture3;
            pictureBox4.Image = picture4;

            pictureBox5.Image = room1;
            label15.Text = room1price;
            label4.Text = room1name;

            pictureBox6.Image = room2;
            label13.Text = room2price;
            label5.Text = room2name;

            pictureBox7.Image = room3;
            label11.Text = room3price;
            label6.Text = room3name;

            pictureBox8.Image = room4;
            label8.Text = room4price;
            label7.Text = room4name;

            label16.Text = place;
        }

            private void hotelroom_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking form = new hotelbooking(label16.Text,label1.Text,label7.Text,label8.Text,id);
            form.ShowDialog();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking form = new hotelbooking(label16.Text, label1.Text, label6.Text, label11.Text,id);
            form.ShowDialog();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking form = new hotelbooking(label16.Text, label1.Text, label5.Text, label13.Text,id);
            form.ShowDialog();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking form = new hotelbooking(label16.Text, label1.Text, label4.Text, label15.Text,id);
            form.ShowDialog();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            home form = new home();
            form.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            placeinfo2 form = new placeinfo2();
            form.ShowDialog();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            aboutus form = new aboutus();
            form.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotel form = new hotel();
            form.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabs form = new cabs();
            form.ShowDialog();

        }
    }
}
