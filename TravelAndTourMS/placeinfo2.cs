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
using DnsClient;
using System.Windows.Media;
using System.Drawing.Text;

namespace TravelAndTourMS
{
    public partial class placeinfo2 : Form
    {
        private const BorderStyle fixedSingle = BorderStyle.FixedSingle;
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;
        private String a;

       

        public placeinfo2()
        {
            InitializeComponent();
           
        }
        private void placeinfo2_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            // Create a new panel to hold the picture boxes
            Panel panel = new Panel();

            // Set the panel's Dock and AutoSize properties
            panel.Dock = DockStyle.Top;
            panel.AutoSize = false;

            // Set the panel's size to match the form's size
            panel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);

            // Set the panel's AutoScroll property to true to enable scrolling
            panel.AutoScroll = true;



            // Load the background image from a file
            Image backgroundImage = Image.FromFile(@"C:\photos\th-1339064553-01.jpeg");

            // Set the panel's background image and set its background image layout to stretch
            panel.BackgroundImage = backgroundImage;
            panel.BackgroundImageLayout = ImageLayout.Stretch;

            // Add the panel to the form's Controls collection
            this.Controls.Add(panel);


            panel.Controls.Add(comboBox1);
            panel.Controls.Add(button1);
            panel.Controls.Add(iconPictureBox1);
            panel.Controls.Add(iconButton10);
            panel.Controls.Add(iconButton3);
            panel.Controls.Add(iconButton4);
            panel.Controls.Add(iconButton2);
            panel.Controls.Add(iconButton8);

            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {

                // create a DataTable and fill it with data from the database
                DataTable dataTable = new DataTable();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Table1", connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
              
                }
                // set the initial location of the first PictureBox
                int x = 300;
                // set the initial y position to 120
                int currentY = 200;

                // loop through the rows of the DataTable
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                  
                    PictureBox pictureBox = new PictureBox();
                    // attach the Click event handler to the PictureBox control
                    pictureBox.Click += pictureBox_Click;

                    pictureBox.Name = dataTable.Rows[i]["id"].ToString();
                  
                    Label label1 = new Label();
                  //  panel1.BackColor = Color.LightGray;
                    label1.Text = "Tour Management System";
                    label1.Font = new Font("Arial", 47, FontStyle.Bold);
                    label1.AutoSize = true;
                    label1.ForeColor = System.Drawing.Color.White;
                    label1.BackColor = System.Drawing.Color.Orange;
                    label1.Location = new Point(450, 40);
                    panel.Controls.Add(label1);
                   // label1.BorderStyle  = fixedSingle;
                    //  this.Controls.Add(panel);


                    // create a new label to show package name
                    Label lblPackageName = new Label();
                    lblPackageName.AutoSize = true;
                    lblPackageName.Text = dataTable.Rows[i]["package_name"].ToString();
                    lblPackageName.Font = new Font("Sans-Serif", 20, FontStyle.Bold);
                    lblPackageName.BackColor = System.Drawing.Color.Transparent;
                    lblPackageName.Location = new Point(x +80, currentY - 45); // adjust y position as needed
                    panel.Controls.Add(lblPackageName);


                     RichTextBox lblPackageName1 = new RichTextBox();
                     lblPackageName1.AutoSize = true;
                     lblPackageName1.Width = 350;
                     lblPackageName1.Height = 150;
                     lblPackageName1.Text = dataTable.Rows[i]["description"].ToString();
                     lblPackageName1.Location = new Point(x, currentY + 300); // adjust y position as needed
                    lblPackageName1.BorderStyle = BorderStyle.None;
                    lblPackageName1.BackColor = System.Drawing.Color.LightYellow;
                     panel.Controls.Add(lblPackageName1);


                    Size currentSize = pictureBox.Size;
                    Size newSize = new Size((int)(currentSize.Width * 3.7), (int)(currentSize.Height * 6));
                    pictureBox.Size = newSize;


                   
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

                   
                    panel.Controls.Add(pictureBox);
                   // panel.Controls.Add(lblPackageName);
                    // increment the X coordinate by the width of the PictureBox plus the gap
                    x += pictureBox.Width + 40;

                   
                    if ((i + 1) % 4 == 0)
                    {
                        x = 300;
                        currentY += 500;
                        //currentY = panel.Controls.OfType<PictureBox>().Last().Bottom + 10;
                    }
                    
                    panel.AutoScrollMargin = new Size(0, 250);

                }


            }
           
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            // cast the sender object to a PictureBox control
            PictureBox clickedPictureBox = sender as PictureBox;

       
            // get the package name and other data associated with the clicked PictureBox
            string id = clickedPictureBox.Name;
          //  Image photo1 = clickedPictureBox.Image;
           // string description = clickedPictureBox.Name; // set the Tag property of each PictureBox to the description when you create them

            // Create an instance of the form you want to open
            placeinfo form2 = new placeinfo(id);

            // Show the form
            form2.Show();

            // Hide the current form if needed
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

            // Create a new panel to hold the picture boxes
            Panel panel = new Panel();

            // Set the panel's Dock and AutoSize properties
            panel.Dock = DockStyle.Top;
            panel.AutoSize = false;

            // Set the panel's size to match the form's size
            panel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);

            // Set the panel's AutoScroll property to true to enable scrolling
            panel.AutoScroll = true;



            // Load the background image from a file
            Image backgroundImage = Image.FromFile(@"C:\photos\th-1339064553-01.jpeg");

            // Set the panel's background image and set its background image layout to stretch
            panel.BackgroundImage = backgroundImage;
            panel.BackgroundImageLayout = ImageLayout.Stretch;

            // Add the panel to the form's Controls collection
            this.Controls.Add(panel);

            panel.Controls.Add(comboBox1);
            panel.Controls.Add(button1);
            panel.Controls.Add(iconPictureBox1);
            panel.Controls.Add(iconButton10);
            panel.Controls.Add(iconButton3);
            panel.Controls.Add(iconButton4);
            panel.Controls.Add(iconButton2);
            panel.Controls.Add(iconButton8);

            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {

                // create a DataTable and fill it with data from the database
                DataTable dataTable = new DataTable();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Table1 where package_name = @package_name", connection))
                {
                    cmd.Parameters.AddWithValue("package_name", comboBox1.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                }
                // set the initial location of the first PictureBox
                int x = 300;
                // set the initial y position to 120
                int currentY = 200;

                // loop through the rows of the DataTable
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {

                    PictureBox pictureBox = new PictureBox();
                    // attach the Click event handler to the PictureBox control
                    pictureBox.Click += pictureBox_Click;

                    pictureBox.Name = dataTable.Rows[i]["id"].ToString();

                    Label label1 = new Label();
                    //  panel1.BackColor = Color.LightGray;
                    label1.Text = "Tour Management System";
                    label1.Font = new Font("Arial", 47, FontStyle.Bold);
                    label1.AutoSize = true;
                    label1.ForeColor = System.Drawing.Color.White;
                    label1.BackColor = System.Drawing.Color.Orange;
                    label1.Location = new Point(450, 40);
                    panel.Controls.Add(label1);
                    // label1.BorderStyle  = fixedSingle;
                    //  this.Controls.Add(panel);


                    // create a new label to show package name
                    Label lblPackageName = new Label();
                    lblPackageName.AutoSize = true;
                    lblPackageName.Text = dataTable.Rows[i]["package_name"].ToString();
                    lblPackageName.Font = new Font("Sans-Serif", 20, FontStyle.Bold);
                    lblPackageName.BackColor = System.Drawing.Color.Transparent;
                    lblPackageName.Location = new Point(x + 80, currentY - 45); // adjust y position as needed
                    panel.Controls.Add(lblPackageName);


                    RichTextBox lblPackageName1 = new RichTextBox();
                    lblPackageName1.AutoSize = true;
                    lblPackageName1.Width = 350;
                    lblPackageName1.Height = 150;
                    lblPackageName1.Text = dataTable.Rows[i]["description"].ToString();
                    lblPackageName1.Location = new Point(x, currentY + 300); // adjust y position as needed
                    lblPackageName1.BorderStyle = BorderStyle.None;
                    lblPackageName1.BackColor = System.Drawing.Color.LightYellow;
                    panel.Controls.Add(lblPackageName1);


                    Size currentSize = pictureBox.Size;
                    Size newSize = new Size((int)(currentSize.Width * 3.7), (int)(currentSize.Height * 6));
                    pictureBox.Size = newSize;



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


                    panel.Controls.Add(pictureBox);
                    // panel.Controls.Add(lblPackageName);
                    // increment the X coordinate by the width of the PictureBox plus the gap
                    x += pictureBox.Width + 40;


                    if ((i + 1) % 4 == 0)
                    {
                        x = 300;
                        currentY += 500;
                        //currentY = panel.Controls.OfType<PictureBox>().Last().Bottom + 10;
                    }

                    panel.AutoScrollMargin = new Size(0, 250);

                }


            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            home form = new home();
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
            iconButton10.BackColor = System.Drawing.Color.Orange;
        }

        private void iconButton10_MouseLeave(object sender, EventArgs e)
        {
            iconButton10.BackColor = System.Drawing.Color.Transparent;
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.BackColor = System.Drawing.Color.Orange;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.BackColor = System.Drawing.Color.Transparent;
        }

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            iconButton4.BackColor = System.Drawing.Color.Orange;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.BackColor = System.Drawing.Color.Transparent;
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.BackColor = System.Drawing.Color.Orange;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.BackColor = System.Drawing.Color.Transparent;
        }

        private void iconButton8_MouseEnter(object sender, EventArgs e)
        {
            iconButton8.BackColor = System.Drawing.Color.Orange;
        }

        private void iconButton8_MouseLeave(object sender, EventArgs e)
        {
            iconButton8.BackColor = System.Drawing.Color.Transparent;
        }
    }

}
