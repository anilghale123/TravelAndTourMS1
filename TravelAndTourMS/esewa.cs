using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TravelAndTourMS
{
    public partial class esewa : Form


    {

        private string name;
        private string address;
        private string travelDate;
        private string nTraveller;
        private string price;
        private string totalPrice;
        private string place;

        private Image im;
        public esewa(string name, string address, string travelDate, string nTraveller, string price, string totalPrice, string place)
        {
            InitializeComponent();
            this.name = name;
            this.address = address;
            this.travelDate = travelDate;
            this.nTraveller = nTraveller;
            this.price = price;
            this.totalPrice = totalPrice;
            this.place = place;
           

            pictureBox1.Image = im;


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            e.Graphics.DrawString("Travel Date: " + travelDate, bodyFont, Brushes.Black, new Point(60, 200));
            e.Graphics.DrawString("No. of Travellers: " + nTraveller, bodyFont, Brushes.Black, new Point(60, 230));
            e.Graphics.DrawString("Price: " + price, bodyFont, Brushes.Black, new Point(60, 260));
            e.Graphics.DrawString("Place: " + totalPrice, bodyFont, Brushes.Black, new Point(350, 230));
            e.Graphics.DrawString("Total Price: " + place, bodyFont, Brushes.Black, new Point(350, 260));





        }

        private void esewa_Load(object sender, EventArgs e)
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
    }
}
