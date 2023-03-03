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
    public partial class tourbooking : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");

        /*  public string Price
          {
              get { return textBox1.Text; }
              set { textBox1.Text = value; }
          }
        */
        private Image x;
        string id;
        public tourbooking(string id ,string a, Image b)
        {
            InitializeComponent();
            string packageName = "";
           
            string price = "";
            this.id = id;
            // textBox1.Text = id;
            /*textBox3.Text = value1;
            x = i1;*/
           using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT package_name, price FROM Table1 WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    packageName = reader.GetString(0);
                    
                    price = reader.GetString(1);
                
                }

                reader.Close();
            }
            textBox1.Text = price;
            textBox3.Text = packageName;

        }
        private void printButton_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.Print();
        }



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();



                string query = "INSERT INTO TBook (Naam,Addresses,Place,PhoneNum,NTraveller,TravelDate) VALUES (@name, @address,@Place,@phoneNum,@numTravelers, @travelDate )";
                SqlCommand cmd = new SqlCommand(query, con);
                
                cmd.Parameters.AddWithValue("@phoneNum", PhoneNum.Text);
                cmd.Parameters.AddWithValue("@travelDate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@place", textBox3.Text);
                cmd.Parameters.AddWithValue("@name", Naam.Text);
                cmd.Parameters.AddWithValue("@address", Addresses.Text);
                cmd.Parameters.AddWithValue("@numTravelers", NTraveller.Text);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Booking Successfully");

                switch (selectedItem)
                {
                    case "esewa":
                        qr form1 = new qr(Naam.Text, Addresses.Text,dateTimePicker1.Text,NTraveller.Text,textBox1.Text,textBox2.Text,textBox3.Text,id);
                        form1.Show();
                        break;

                   /* case "cash":
                        qr form2 = new qr();
                        form2.Show();
                        break;*/
                        // Add more cases as needed
                }

                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.InnerException);
            }
        }



        private void CalculateTotalPrice()
        {
            if (double.TryParse(textBox1.Text, out double price) && double.TryParse(NTraveller.Text, out double numTravellers))
            {
                textBox2.Text = (price * numTravellers).ToString();
            }
        }




        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void NTraveller_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
            // if(rjButton1.Text =)
            // textBox1.Text = "5000";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 15, FontStyle.Regular);

            // Draw the header text
            e.Graphics.DrawString("Tour Management System", headerFont, Brushes.Black, new Point(200, 10));
            e.Graphics.DrawString("YOUR RECEIPT", headerFont, Brushes.Black, new Point(240, 80));

            // Draw the border line
            e.Graphics.DrawRectangle(Pens.Black, 50, 120, 590, 180);

            // Draw the body text
            e.Graphics.DrawString("Name: " + Naam.Text, bodyFont, Brushes.Black, new Point(60, 140));
            e.Graphics.DrawString("Address: " + Addresses.Text, bodyFont, Brushes.Black, new Point(60, 170));
            e.Graphics.DrawString("Travel Date: " + dateTimePicker1.Text, bodyFont, Brushes.Black, new Point(60, 200));
            e.Graphics.DrawString("No. of Travellers: " + NTraveller.Text, bodyFont, Brushes.Black, new Point(60, 230));
            e.Graphics.DrawString("Price: " + textBox1.Text, bodyFont, Brushes.Black, new Point(60, 260));
            e.Graphics.DrawString("Place: " + textBox3.Text, bodyFont, Brushes.Black, new Point(350, 230));
            e.Graphics.DrawString("Total Price: " + textBox2.Text, bodyFont, Brushes.Black, new Point(350, 260));
        }


        private void button3_Click(object sender, EventArgs e)
        {

            PrintPreviewDialog printPreviewDialog2 = new PrintPreviewDialog();
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();

            //PrintDialog printDialog2 = new PrintDialog();
            //printDialog2.Document = printDocument2;

            // printDocument2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Bill Paper", 285, 600);
            //   printPreviewDialog2.ShowDialog();

            //   printDocument2.Print();

            /*   DialogResult result = printDialog2.ShowDialog();
               if (result == DialogResult.OK)
               {
                   printDocument2.Print();
               }   */
        }

        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            PrintDialog printDialog2 = new PrintDialog();
            printDialog2.Document = printDocument2;

            DialogResult result = printDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument2.Print();
            }

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog2 = new PrintDialog();
            printDialog2.Document = printDocument2;

            DialogResult result = printDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

            PrintPreviewDialog printPreviewDialog2 = new PrintPreviewDialog();
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            PrintPreviewDialog printPreviewDialog2 = new PrintPreviewDialog();
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PrintDialog printDialog2 = new PrintDialog();
            printDialog2.Document = printDocument2;

            DialogResult result = printDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }


       



















        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            home employeeform = new home();
            employeeform.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            image1 employeeform = new image1();
            employeeform.ShowDialog();
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

        private void iconButton10_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            home employeeform = new home();
            employeeform.ShowDialog();
        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            image1 employeeform = new image1();
            employeeform.ShowDialog();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            place employeeform = new place();
            employeeform.ShowDialog();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            aboutus employeeform = new aboutus();
            employeeform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            image1 employeeform = new image1();
            employeeform.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelsearch employeeform = new hotelsearch();
            employeeform.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabuser employeeform = new cabuser();
            employeeform.ShowDialog();
        }
        private string selectedItem;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = comboBox1.SelectedItem.ToString();
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.Orange;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.Transparent;
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Orange;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton8.BackColor = Color.Transparent;
        }
    }
}
