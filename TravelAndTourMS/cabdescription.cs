using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class cabdescription : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;

        string id;
        string model;
        string feature;
        Image cab1;
        Image cab2;
        Image cab3;
        string price;
        public cabdescription(string id)
        {
            InitializeComponent();
            this.id = id;



            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT model, feature,price, cab1, cab2, cab3 FROM cab WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    model = reader.GetString(0);
                    feature = reader.GetString(1);
                    price = reader.GetString(2);
                    // Convert the byte array to an Image object
                    byte[] photo1Bytes = (byte[])reader.GetValue(3);
                    using (MemoryStream ms = new MemoryStream(photo1Bytes))
                    {
                        cab1 = Image.FromStream(ms);
                    }

                    // Convert the byte array to an Image object
                    byte[] photo2Bytes = (byte[])reader.GetValue(4);
                    using (MemoryStream ms = new MemoryStream(photo2Bytes))
                    {
                        cab2 = Image.FromStream(ms);
                    }
                    // Convert the byte array to an Image object
                    byte[] photo3Bytes = (byte[])reader.GetValue(5);
                    using (MemoryStream ms = new MemoryStream(photo3Bytes))
                    {
                        cab3 = Image.FromStream(ms);
                    }


                }

                reader.Close();
            }
            pictureBox1.Image = cab1;
            pictureBox2.Image = cab2;
            pictureBox3.Image = cab3;
            label1.Text = model;
            label3.Text = price;
            richTextBox1.Text = feature;
        }

        private void cabdescription_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabbooking form = new cabbooking(id);
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

        private void iconButton7_Click(object sender, EventArgs e)
        {

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

        private void iconButton10_MouseEnter(object sender, EventArgs e)
        {
            iconButton10.BackColor = Color.Orange;
        }

        private void iconButton10_MouseLeave(object sender, EventArgs e)
        {
            iconButton10.BackColor = Color.Transparent;
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.BackColor = Color.Orange;
        }

        private void iconButton10_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.BackColor = Color.Transparent;
        }

        private void iconButton7_MouseEnter(object sender, EventArgs e)
        {
            iconButton7.BackColor = Color.Orange;
        }

        private void iconButton7_MouseLeave(object sender, EventArgs e)
        {
            iconButton7.BackColor = Color.Transparent;
        }

        private void iconButton8_MouseEnter(object sender, EventArgs e)
        {
            iconButton8.BackColor = Color.Orange;
        }

        private void iconButton8_MouseLeave(object sender, EventArgs e)
        {
            iconButton8.BackColor = Color.Transparent;
        }

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Orange;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Transparent;
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Orange;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Transparent;
        }
    }
}
