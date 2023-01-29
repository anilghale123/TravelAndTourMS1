using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public tourbooking(string value)
        {
            InitializeComponent();
            textBox1.Text = value;

            
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



                string query = "INSERT INTO TBook (Naam,Addresses,Place,PhoneNum,NTraveller,TravelDate,Activities,Transportation) VALUES (@name, @address,@place,@phoneNum,@numTravelers, @travelDate, @activities, @transportation  )";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@phoneNum", PhoneNum.Text);
                cmd.Parameters.AddWithValue("@travelDate", TravelDate.Text);
                cmd.Parameters.AddWithValue("@activities", Activities.Text);
                cmd.Parameters.AddWithValue("@transportation", Transportation.Text);
                cmd.Parameters.AddWithValue("@place", Place.Text);
                cmd.Parameters.AddWithValue("@name", Naam.Text);
                cmd.Parameters.AddWithValue("@address", Addresses.Text);
                cmd.Parameters.AddWithValue("@numTravelers", NTraveller.Text);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Booking Successfully");
               
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
    }
}
