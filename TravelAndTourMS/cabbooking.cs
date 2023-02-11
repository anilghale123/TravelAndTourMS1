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
    public partial class cabbooking : Form

    {

        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");

        private Image x;
        public cabbooking(string a, string b, string c, string d,Image ee,string v)
        {
            InitializeComponent();
            PhoneNum.Text = a;
            Naam.Text = b;
            textBox1.Text = v;
           
            x = ee;
        }
       
        private void CalculateTotalPrice()
        {
            if (double.TryParse(textBox1.Text, out double price) && double.TryParse(textBox2.Text, out double totalPrice))
            {

              
                switch (comboBox2.SelectedItem.ToString().ToLower())
                {
                    case "daily":
                        totalPrice = price;
                        break;
                    case "weekly":
                        totalPrice = price * 7;
                        break;
                    case "monthly":
                        totalPrice = price * 30;
                        break;
                    default:
                        totalPrice = 0;
                        break;
                }


                textBox2.Text = totalPrice.ToString();
            }

               // textBox2.Text = (price * numTravellers).ToString();
            
             
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }
        private string selectedItem;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = comboBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            /*
                        try
                        {
                            con.Open();



                            string query = "INSERT INTO TBook (Naam,Addresses,Place,PhoneNum,NTraveller,TravelDate) VALUES (@name, @address,@Place,@phoneNum,@numTravelers, @travelDate )";
                            SqlCommand cmd = new SqlCommand(query, con);

                            cmd.Parameters.AddWithValue("@phoneNum", PhoneNum.Text);
                            cmd.Parameters.AddWithValue("@travelDate", Trav.Text);
                            cmd.Parameters.AddWithValue("@place", textBox3.Text);
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
            */










                MessageBox.Show("booking successful");

                switch (selectedItem)
                {
                    case "esewa":
                        esewa form1 = new esewa(Naam.Text, Addresses.Text, dateTimePicker1.Text, NTraveller.Text, textBox1.Text, textBox2.Text, textBox3.Text, x);
                        form1.Show();
                        break;

                    case "qr":
                        qr form2 = new qr();
                        form2.Show();
                        break;
                        // Add more cases as needed
                }
            

        }

        private void cabbooking_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            comboBox2.Items.Add("daily");
            comboBox2.Items.Add("weekly");
            comboBox2.Items.Add("monthly");

        }

        private void NTraveller_TextChanged(object sender, EventArgs e)
        {
            int numOfPassengers;
            int seatCapacity;

            // Check if the user has entered valid integers for the number of passengers and seat capacity
            if (int.TryParse(NTraveller.Text, out numOfPassengers) && int.TryParse(textBox5.Text, out seatCapacity))
            {
                // Compare the number of passengers and seat capacity
                if (numOfPassengers > seatCapacity)
                {
                    // Display error message
                    MessageBox.Show("Please enter number of guest less than seat capacity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Clear the text in the number of passengers textbox
                    NTraveller.Text = "";
                }
                else
                {
                    // Continue with the rest of your code here...
                }
            }
            else
            {
                // Display error message
               // MessageBox.Show("Please enter valid integers for number of passengers and seat capacity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Clear the text in both textboxes
                NTraveller.Text = "";
               // textBox5.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double price) && price > 0)
            {
                switch (comboBox2.SelectedItem.ToString().ToLower())
                {
                    case "daily":
                        textBox2.Text = (price * 1).ToString();
                        break;
                    case "weekly":
                        textBox2.Text = (price * 7).ToString();
                        break;
                    case "monthly":
                        textBox2.Text = (price * 30).ToString();
                        break;
                    default:
                        textBox2.Text = "Invalid Selection";
                        break;
                }
            }
            else
            {
                textBox2.Text = "Invalid Price";
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //CalculateTotalPrice();
           

               
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // CalculateTotalPrice();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
