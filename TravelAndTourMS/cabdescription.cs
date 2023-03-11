﻿using System;
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
    }
}
