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

using System.IO;
using MongoDB.Driver.Core.Configuration;
using System.Diagnostics;

namespace TravelAndTourMS
{
    public partial class placeinfo : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;

        string id;
        string d;
        Image a;
        public placeinfo(string id)
        {
            
            InitializeComponent();
            string packageName = "";
            string description = "";
            string price ;
            Image photo1 = null;
            Image photo2 = null;
          //  Image qr = null;
            // this.package_name = package_name;
            
          //  this.description = description;
            this.id = id;
            //  label1.Text = id;


            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT package_name, description, price, photo1, photo2, qr FROM Table1 WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    packageName = reader.GetString(0);
                    description = reader.GetString(1);
                    price = reader.GetString(2);
                    // Convert the byte array to an Image object
                    byte[] photo1Bytes = (byte[])reader.GetValue(3);
                    using (MemoryStream ms = new MemoryStream(photo1Bytes))
                    {
                        photo1 = Image.FromStream(ms);
                    }

                    // Convert the byte array to an Image object
                    byte[] photo2Bytes = (byte[])reader.GetValue(4);
                    using (MemoryStream ms = new MemoryStream(photo2Bytes))
                    {
                        photo2 = Image.FromStream(ms);
                    }

                  
                }

                reader.Close();
            }

            // Assign the data to the controls on Form2
            label1.Text = packageName;
           // label1.Text = price;
            richTextBox1.Text = description;
            pictureBox1.Image = photo1;
            pictureBox2.Image = photo2;
            //  priceLabel.Text = price.ToString();
            //  photo1PictureBox.Image = Image.FromStream(new MemoryStream(photo1));
            //  photo2PictureBox.Image = Image.FromStream(new MemoryStream(photo2));
        }




        private void placeinfo_Load(object sender, EventArgs e)
        {

            // Create a new panel to hold the picture boxes
            Panel panel = new Panel();

            // Set the panel's Dock and AutoSize properties
            panel.Dock = DockStyle.Top;
            panel.AutoSize = true;

            // Add the panel to the form's Controls collection
            this.Controls.Add(panel);



        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            tourbooking form = new tourbooking(id,d,a);
            form.ShowDialog();
        }
    }
}
