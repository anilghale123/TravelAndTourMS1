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
    public partial class hotel : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;
        public hotel()
        {
            InitializeComponent();
            
        }


        private void hotel_Load(object sender, EventArgs e)
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




            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {

                // create a DataTable and fill it with data from the database
                DataTable dataTable = new DataTable();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Hotel", connection))
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


                    //  pictureBox1.Image = Image.FromFile(dataTable.Rows[i]["image_path"].ToString());
                    pictureBox.Name = dataTable.Rows[i]["id"].ToString();
                  
                    Label label1 = new Label();
                    //  panel1.BackColor = Color.LightGray;
                    label1.Text = "Hotel Management System";
                    label1.Font = new Font("Arial", 47, FontStyle.Bold);
                    label1.AutoSize = true;
                    label1.ForeColor = System.Drawing.Color.White;
                    label1.BackColor = System.Drawing.Color.Transparent;
                    label1.Location = new Point(450, 40);
                    panel.Controls.Add(label1);
                    // label1.BorderStyle  = fixedSingle;
                    //  this.Controls.Add(panel);


                    // create a new label to show package name
                    Label lblPackageName = new Label();
                    lblPackageName.AutoSize = true;
                    lblPackageName.Text = dataTable.Rows[i]["hotel"].ToString();
                    lblPackageName.Location = new Point(x + 100, currentY - 45); // adjust y position as needed
                    lblPackageName.BackColor = System.Drawing.Color.Transparent;
                    lblPackageName.ForeColor = System.Drawing.Color.White;
                    lblPackageName.Font = new Font("Arial", 20, FontStyle.Bold);
                   
                    panel.Controls.Add(lblPackageName);


                    RichTextBox lblPackageName1 = new RichTextBox();
                    lblPackageName1.AutoSize = true;
                    lblPackageName1.Width = 350;
                    lblPackageName1.Height = 150;
                    lblPackageName1.Text = dataTable.Rows[i]["description"].ToString();
                    lblPackageName1.Location = new Point(x, currentY + 300); // adjust y position as needed
                    lblPackageName1.BorderStyle = BorderStyle.None;
                    lblPackageName1.BackColor = Color.LightYellow;
                    panel.Controls.Add(lblPackageName1);

                    Size currentSize = pictureBox.Size;
                    Size newSize = new Size((int)(currentSize.Width * 3.5), (int)(currentSize.Height * 6));
                    pictureBox.Size = newSize;

                    pictureBox.Location = new Point(x, currentY);

                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    // get the image data from the appropriate column in the current row
                    byte[] imageData = (byte[])dataTable.Rows[i]["picture" + (1)];

                    // create a MemoryStream from the image data and set it as the PictureBox's image
                    using (MemoryStream memoryStream = new MemoryStream(imageData))
                    {
                        pictureBox.Image = Image.FromStream(memoryStream);
                    }

                    
                    panel.Controls.Add(pictureBox);
                  
                    x += pictureBox.Width + 40;

                    if ((i + 1) % 4 == 0)
                    {
                        x = 300;
                        currentY += 500;
                       
                    }
                  
                    panel.AutoScrollMargin = new Size(0, 250);

                }


            }

        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            // cast the sender object to a PictureBox control
            PictureBox clickedPictureBox = sender as PictureBox;
            string id = clickedPictureBox.Name;
           
            // Create an instance of the form you want to open
            hotelroom form2 = new hotelroom(id);

            // Show the form
            form2.Show();

            // Hide the current form if needed
            this.Hide();
        }
    }
}
