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
        
        public placeinfo(string id)
        {
            
            InitializeComponent();
            string packageName = "";
            string description = "";
            string price ;
            Image photo1 = null;
            Image photo2 = null;
            // this.package_name = package_name;
            
          //  this.description = description;
            this.id = id;
            //  label1.Text = id;


            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT package_name, description, price, photo1, photo2 FROM Table1 WHERE id = @id", connection);
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

          
           
          //  richTextBox1.Text = description;

            /*  // Create a new instance of PictureBox
              PictureBox pictureBox = new PictureBox();

              // Set the image location
              pictureBox.ImageLocation = @"C:\photos\bpoy.jpeg";

              // Get the current size of the PictureBox control
              Size currentSize = pictureBox.Size;

              // Increase the size of the PictureBox control by 50%
              Size newSize = new Size((int)(currentSize.Width * 3), (int)(currentSize.Height * 5.5));
              pictureBox.Size = newSize;

              // Set the picture box size mode to stretch the image
              pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


             // pictureBox.Size = new Size(200, 300);
              pictureBox.Location = new Point(300, 120);

              // Set the picture box to display the image
              pictureBox.Load();

              // Add the picture box to the form
              this.Controls.Add(pictureBox);*/


            //  using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            //  {
            /*  // Open the connection to the database
              connection.Open();
              PictureBox pictureBox = new PictureBox();
              Size currentSize = pictureBox.Size;
              // Create a command to select the image data from the database
              SqlCommand command = new SqlCommand("SELECT photo1 FROM Table1 ", connection);

              // Execute the command and read the image data as a byte array
              byte[] imageData = (byte[])command.ExecuteScalar();

              if (imageData != null && imageData.Length > 0)
              {
                  // Create a new MemoryStream from the byte array
                  MemoryStream memoryStream2 = new MemoryStream(imageData);

                  // Create a new Image object from the MemoryStream
                  Image image2 = Image.FromStream(memoryStream2);

                  // Create a new PictureBox control and set its properties

                 // pictureBox.Dock = DockStyle.Fill;
                  pictureBox.Image = image2;


                  // Increase the size of the PictureBox control by 50%
                  Size newSize = new Size((int)(currentSize.Width * 3), (int)(currentSize.Height * 5.5));
                  pictureBox.Size = newSize;

                  // Set the picture box size mode to stretch the image
                  pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                  // pictureBox.Size = new Size(200, 300);
                  pictureBox.Location = new Point(300, 120);

                  // Set the picture box to display the image
                  //pictureBox.Load();

                  // Add the PictureBox control to the form
                  this.Controls.Add(pictureBox);

                  // Close the MemoryStream and database connection
                  memoryStream2.Close();
                  connection.Close();
              }
              else
              {
                  MessageBox.Show("No image data found.");
              }
          }




      }
  }*/

            /*  // Open the connection to the database
              connection.Open();
              PictureBox pictureBox = new PictureBox();
              Size currentSize = pictureBox.Size;
              // Create a command to select the image data from the database
              SqlCommand command = new SqlCommand("SELECT photo1 ,photo2 FROM Table1", connection);

              // Execute the command and read the image data as a byte array
              SqlDataReader reader = command.ExecuteReader();
              int count = 0;

              while (reader.Read())
              {
                  // Create a new MemoryStream from the byte array
                  MemoryStream memoryStream = new MemoryStream((byte[])reader["photo1"]);
                  MemoryStream memoryStream1 = new MemoryStream((byte[])reader["photo2"]);


                  // Create a new Image object from the MemoryStream
                  Image image = Image.FromStream(memoryStream);
                  Image image1 = Image.FromStream(memoryStream1);

                  // Create a new PictureBox and set its properties

                  pictureBox.Name = "pictureBox" + count.ToString();
                  // Increase the size of the PictureBox control by 50%
                  Size newSize = new Size((int)(currentSize.Width * 3), (int)(currentSize.Height * 5.5));
                  pictureBox.Size = newSize;

                  // Set the picture box size mode to stretch the image
                  pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                  // pictureBox.Size = new Size(200, 300);
                 // pictureBox.Location = new Point(300, 120);
                  pictureBox.Location = new Point(300 + (count * 220), 120+ (count * 220));
                  pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                  pictureBox.Image = image;
                  pictureBox.Image = image1;

                  // Add the PictureBox to the form's Controls collection
                  this.Controls.Add(pictureBox);

                  // Close the MemoryStream
                  memoryStream.Close();

                  count++;
              }

              // Close the SqlDataReader and database connection
              reader.Close();
              connection.Close();*/

            /*  // Open the connection to the database
              connection.Open();

              // Create a command to select the image data from the database
              SqlCommand command = new SqlCommand("SELECT photo1, photo2 FROM Table1", connection);

              // Execute the command and read the image data as a byte array
              SqlDataReader reader = command.ExecuteReader();

              // Set the initial x and y coordinates for the first PictureBox
              int x = 300;
              int y = 120;

              // Loop through the result set and create a PictureBox for each image
              while (reader.Read())
              {
                  // Create a new PictureBox and set its properties
                  PictureBox pictureBox = new PictureBox();
                  pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                  pictureBox.Size = new Size(200, 200);

                  // Create a new MemoryStream from the image data
                  MemoryStream memoryStream = new MemoryStream((byte[])reader["photo1"]);

                  // Set the Image property of the PictureBox control to display the image
                  pictureBox.Image = Image.FromStream(memoryStream);

                  // Set the location of the PictureBox and add it to the form
                  pictureBox.Location = new Point(x, y);
                  this.Controls.Add(pictureBox);

                  // Increase the x coordinate for the next PictureBox
                  x += pictureBox.Width + 30;

                  // Repeat the same steps for photo2
                  pictureBox = new PictureBox();
                  pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                  pictureBox.Size = new Size(200, 200);

                  memoryStream = new MemoryStream((byte[])reader["photo2"]);

                  pictureBox.Image = Image.FromStream(memoryStream);

                  pictureBox.Location = new Point(x, y);
                  this.Controls.Add(pictureBox);

                  // Increase the y coordinate for the next row of PictureBoxes
                  y += pictureBox.Height + 10;

                  // Reset the x coordinate for the next row
                  x = 10;
              }

              // Close the SqlDataReader and database connection
              reader.Close();
              connection.Close();*/


            /*   // Open the connection to the database
               connection.Open();

               // Create a command to select the image data from the database
               SqlCommand command = new SqlCommand("SELECT photo1, photo2 FROM Table1 ", connection);

               // Execute the command and read the image data as a byte array
               SqlDataReader reader = command.ExecuteReader();
               int x = 300;
               int y = 120;
               int imageWidth = 300;
               int imageHeight = 300;*/
            /* while (reader.Read())
             {
                 // Get the image data as a byte array
                 byte[] imageData = (byte[])reader["photo1"];

                 // Create a new MemoryStream from the byte array
                 MemoryStream memoryStream = new MemoryStream(imageData);

                 // Create a new Image object from the MemoryStream
                 Image image = Image.FromStream(memoryStream);

                 // Create a new PictureBox control and set its properties
                 PictureBox pictureBox = new PictureBox();
                 pictureBox.Image = image;
                 pictureBox.Location = new Point(x, y);
                 pictureBox.Size = new Size(imageWidth, imageHeight);
                 pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                 // Add the PictureBox control to the form
                 this.Controls.Add(pictureBox);

                 // Update the position for the next PictureBox control
                 x += imageWidth + 10;

                 // Close the MemoryStream
                 memoryStream.Close();

                 // Repeat the same process for photo2 column
                 imageData = (byte[])reader["photo2"];
                 memoryStream = new MemoryStream(imageData);
                 image = Image.FromStream(memoryStream);
                 pictureBox = new PictureBox();
                 pictureBox.Image = image;
                 pictureBox.Location = new Point(x, y);
                 pictureBox.Size = new Size(imageWidth, imageHeight);
                 pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                 this.Controls.Add(pictureBox);
                 x += imageWidth + 10;
                 memoryStream.Close();
             }

             // Close the reader and database connection
             reader.Close();
             connection.Close();*/

            // assume we have a list of column names that contain the image data
            /* List<string> columnNames = new List<string> { "photo1", "photo2" };


             foreach (string columnName in columnNames)
             {
                 // read the image data from the database using the column name
                 byte[] imageData = (byte[])reader[columnName];

                 // create a memory stream from the image data
                 using (MemoryStream memoryStream = new MemoryStream(imageData))
                 {
                     // create a new image from the memory stream
                     Image image = Image.FromStream(memoryStream);

                     // create a new picture box
                     PictureBox pictureBox = new PictureBox();
                     pictureBox.Image = image;
                     pictureBox.Location = new Point(x, y);
                     pictureBox.Size = new Size(imageWidth, imageHeight);
                     pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                     // add the picture box to the form
                     this.Controls.Add(pictureBox);

                     // update the x coordinate for the next picture box
                     x += imageWidth + 10;*/
            //    }
            // }

            // create a DataTable and fill it with data from the database
            /*DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Table1", connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            // set the initial location of the first PictureBox
            int x = 300;
            // set the initial y position to 120
            int currentY = 120;

            // loop through the rows of the DataTable
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                // create a new PictureBox control and set its properties
                PictureBox pictureBox = new PictureBox();
                Size currentSize = pictureBox.Size;
                Size newSize = new Size((int)(currentSize.Width * 3), (int)(currentSize.Height * 5.5));
                pictureBox.Size = newSize;


                //pictureBox.Size = new Size(100, 100);
                // pictureBox.Location = new Point(i * 110 + 300, 120);
                *//* pictureBox.Location = new Point(x, y);*//*
                pictureBox.Location = new Point(x, currentY);

                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // get the image data from the appropriate column in the current row
                byte[] imageData = (byte[])dataTable.Rows[i]["photo" + (1)];

                // create a MemoryStream from the image data and set it as the PictureBox's image
                using (MemoryStream memoryStream = new MemoryStream(imageData))
                {
                    pictureBox.Image = Image.FromStream(memoryStream);
                }

                // add the PictureBox to the form
                this.Controls.Add(pictureBox);
                // increment the X coordinate by the width of the PictureBox plus the gap
                x += pictureBox.Width + 40;

                // update the currentY position to be below the current PictureBox
currentY = pictureBox.Bottom + 10;
            }


        }
    }*/
        }
    }
}
