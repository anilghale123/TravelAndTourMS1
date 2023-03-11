using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class qr : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;
        string id;
        string name;
        string address;
        string date;
        string ntraveller;
        string price;
        string totalprice;
        string place;

        public qr(string a, string b, string c, string d, string e, string f, string g, string id)
        {
            InitializeComponent();
            Image qr = null;
            this.id = id;
            // pictureBox1.Image = x;
            name = a;
            address = b;
            date = c;
            ntraveller = d;
            price = e;
            totalprice = f;
            place = g;



            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT  qr FROM Table1 WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    // Convert the byte array to an Image object
                    byte[] photo2Bytes = (byte[])reader.GetValue(0);
                    using (MemoryStream ms = new MemoryStream(photo2Bytes))
                    {
                        qr = Image.FromStream(ms);
                    }


                }

                reader.Close();
            }
            pictureBox1.Image = qr;
        }
        

        private void qr_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;

            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 15, FontStyle.Regular);

            // Draw the header text
            e.Graphics.DrawString("Tour Management System", headerFont, Brushes.Black, new Point(200, 10));
            e.Graphics.DrawString("YOUR RECEIPT", headerFont, Brushes.Black, new Point(240, 80));

            // Draw the border line
            e.Graphics.DrawRectangle(Pens.Black, 50, 120, 590, 180);

            // Draw the body text
            e.Graphics.DrawString("Name: " + name, bodyFont, Brushes.Black, new Point(60, 140));
            e.Graphics.DrawString("Address: " + address, bodyFont, Brushes.Black, new Point(60, 170));
            e.Graphics.DrawString("Travel Date: " + date, bodyFont, Brushes.Black, new Point(60, 200));
            e.Graphics.DrawString("No. of Travellers: " + ntraveller, bodyFont, Brushes.Black, new Point(60, 230));
            e.Graphics.DrawString("Price: " + price, bodyFont, Brushes.Black, new Point(60, 260));
            e.Graphics.DrawString("Place: " + place, bodyFont, Brushes.Black, new Point(350, 230));
            e.Graphics.DrawString("Total Price: " + totalprice, bodyFont, Brushes.Black, new Point(350, 260));
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Booking Sucessful");
            this.Hide();
            home form = new home();
            form.ShowDialog();
        }
    }
}
