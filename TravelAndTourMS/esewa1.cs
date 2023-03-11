using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TravelAndTourMS
{
    public partial class esewa1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;

        private string name;
        private string address;
        private string nGuest;
        private string phone;
        private string Nroom;
        private string place;
        private string checkIn;
        private string checkOut;
        private string Ndays;
        private string price;
        private string totalPrice;
        private string payment;

        private Image qr;
        string id;
        public esewa1(string name, string address, string nGuest, string phone, string Nroom, string place, string checkIn,string checkOut,string Ndays,string price,string totalPrice,string payment,string id)
        {
            InitializeComponent();
            this.name = name;
            this.address = address;
            this.nGuest = nGuest;
            this.phone = phone;
            this.Nroom = Nroom;
            this.place = place;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.Ndays = Ndays;
            this.price = price;
            this.totalPrice = totalPrice;
            this.payment = payment;




            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT  qr FROM Hotel WHERE id = @id", connection);
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

            // this.im = i;

            //pictureBox1.Image = i;
        }

        private void esewa1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 16, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 15, FontStyle.Regular);

            // Draw the header text
            e.Graphics.DrawString("Tour Management System", headerFont, Brushes.Black, new Point(250, 50));
            e.Graphics.DrawString("YOUR RECEIPT", subHeaderFont, Brushes.Black, new Point(290, 100));

            // Draw the border line
            e.Graphics.DrawRectangle(Pens.Black, 50, 120, 770, 300);

            // Draw the body text
            e.Graphics.DrawString("Name :  ", bodyFont, Brushes.Black, new Point(60, 140));
            e.Graphics.DrawString(name, bodyFont, Brushes.Black, new Point(200, 140));
            e.Graphics.DrawString("Address :  ", bodyFont, Brushes.Black, new Point(60, 170));
            e.Graphics.DrawString(address, bodyFont, Brushes.Black, new Point(200, 170));
            e.Graphics.DrawString("Number of Guests :  ", bodyFont, Brushes.Black, new Point(60, 200));
            e.Graphics.DrawString(nGuest, bodyFont, Brushes.Black, new Point(200, 200));
            e.Graphics.DrawString("Quantity of Rooms :  ", bodyFont, Brushes.Black, new Point(60, 230));
            e.Graphics.DrawString(Nroom, bodyFont, Brushes.Black, new Point(200, 230));
            e.Graphics.DrawString("Place :  ", bodyFont, Brushes.Black, new Point(60, 260));
            e.Graphics.DrawString(place, bodyFont, Brushes.Black, new Point(200, 260));
            e.Graphics.DrawString("Check-In Date :  ", bodyFont, Brushes.Black, new Point(350, 140));
            e.Graphics.DrawString(checkIn, bodyFont, Brushes.Black, new Point(500, 140));
            e.Graphics.DrawString("Check-Out Date :  ", bodyFont, Brushes.Black, new Point(350, 170));
            e.Graphics.DrawString(checkOut, bodyFont, Brushes.Black, new Point(500, 170));
            e.Graphics.DrawString("Stay Days Number :  ", bodyFont, Brushes.Black, new Point(350, 200));
            e.Graphics.DrawString(Ndays, bodyFont, Brushes.Black, new Point(500, 200));
            e.Graphics.DrawString("Price :  ", bodyFont, Brushes.Black, new Point(350, 230));
            e.Graphics.DrawString(price, bodyFont, Brushes.Black, new Point(500, 230));
            e.Graphics.DrawString("Total Price :  ", bodyFont, Brushes.Black, new Point(350, 260));
            e.Graphics.DrawString(totalPrice, bodyFont, Brushes.Black, new Point(500, 260));



        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
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

        private void rjButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Booking SUcessful");
            this.Hide();
            home form = new home();
            form.ShowDialog();
        }
    }
}
