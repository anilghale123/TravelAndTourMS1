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

namespace TravelAndTourMS
{
    public partial class placeinfo2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;
        public placeinfo2()
        {
            InitializeComponent();
        }

        private void placeinfo2_Load(object sender, EventArgs e)
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

            // Add the panel to the form's Controls collection
            this.Controls.Add(panel);



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
                int currentY = 120;

                int a = 20, b = 20;
                int pictureBoxWidth = 200, pictureBoxHeight = 200;
                int spacing = 10;
                int descriptionWidth = 200;
                Font font = new Font("Arial", 12);


                // loop through the rows of the DataTable
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    // create a new label to show package name
                    Label lblPackageName = new Label();
                    lblPackageName.AutoSize = true;
                    lblPackageName.Text = dataTable.Rows[i]["package_name"].ToString();
                    lblPackageName.Location = new Point(x, currentY - 20); // adjust y position as needed
                    panel.Controls.Add(lblPackageName);


                    // Create RichTextBox for displaying the description
                    RichTextBox rtb = new RichTextBox();
                    rtb.Size = new Size(descriptionWidth, 0);
                    rtb.Location = new Point(a, b + pictureBoxHeight + spacing);
                    rtb.Font = font;
                    rtb.Text = dataTable.Rows[i]["description"].ToString();
                    rtb.ReadOnly = true;
                    rtb.BorderStyle = BorderStyle.None;
                    rtb.BackColor = this.BackColor;
                    this.Controls.Add(rtb);
                    rtb.Height = rtb.GetPreferredSize(rtb.Size).Height;

                    // Calculate new position for next PictureBox and RichTextBox
                    a += pictureBoxWidth + spacing;

                    if (a + pictureBoxWidth + spacing + descriptionWidth > this.ClientSize.Width)
                    {
                        a = 20;
                        b += pictureBoxHeight + spacing + rtb.Height + spacing;
                    }

                    // create a new PictureBox control and set its properties



                    Size currentSize = pictureBox.Size;
                    Size newSize = new Size((int)(currentSize.Width * 3), (int)(currentSize.Height * 5.5));
                    pictureBox.Size = newSize;


                    //pictureBox.Size = new Size(100, 100);
                    // pictureBox.Location = new Point(i * 110 + 300, 120);
                    /* pictureBox.Location = new Point(x, y);*/
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
                    //this.Controls.Add(pictureBox);
                    // add the PictureBox to the panel instead of directly to the form's Controls collection
                    panel.Controls.Add(pictureBox);
                   // panel.Controls.Add(lblPackageName);
                    // increment the X coordinate by the width of the PictureBox plus the gap
                    x += pictureBox.Width + 40;

                    // update the currentY position to be below the current PictureBox
                    /*if(dataTable.Rows.Count >= 4)
                    {
                        currentY = pictureBox.Bottom + 10;
                    }
                   */
                    if ((i + 1) % 4 == 0)
                    {
                        x = 300;
                        currentY += 500;
                        //currentY = panel.Controls.OfType<PictureBox>().Last().Bottom + 10;
                    }
                    //panel.Padding = new Padding(0, 0, 0, 100);
                    //panel.Controls.OfType<PictureBox>().Last().Margin = new Padding(0, 0, 0, 50);

                    panel.AutoScrollMargin = new Size(0, 250);

                }


            }
           
        }

    }


}
