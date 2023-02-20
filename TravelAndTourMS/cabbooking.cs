using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WinFormAnimation_NET5;
using Timer = System.Windows.Forms.Timer;

namespace TravelAndTourMS
{
    public partial class cabbooking : Form

    {

        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
        SqlCommand cmd;
        private Image x;
        public string p1;
        public cabbooking(string a,string  b,string  c,string d,string ee,Image x1,Image x2,Image x3,string f,string g,Image x4,string h,string i,string j,Image x5,Image x6)
        {
            InitializeComponent();
            PhoneNum.Text = a;
            textBox8.Text = b;
            textBox9.Text = c;
            textBox5.Text = d;
            textBox4.Text = ee;
            textBox1.Text = h;
            x = x6;
            p1 = h;
            CalculateTotalPrice();
        }
        // Create a timer that runs every minute


        /* private  void Timer_Tick(object sender, ElapsedEventArgs e)
         {
             DateTime currentTime = DateTime.Now;
             string query = "SELECT * FROM cabBooking WHERE status = 'booked' AND EndTime < @currentTime";
             SqlCommand cmd = new SqlCommand(query, con);
             cmd.Parameters.AddWithValue("@currentTime", currentTime);
             SqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 int bookingId = reader.GetInt32(0);
                 // Update the status of the booking to "free" in the database
                 // You can use a similar update query like the one used to book the cab
             }
             reader.Close();
         }
 */

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            string query = "SELECT * FROM cabBooking WHERE status = 'booked' AND EndTime < @currentTime";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@currentTime", currentTime);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int bookingId = reader.GetInt32(0);
                // Update the status of the booking to "free" in the database
                // You can use a similar update query like the one used to book the cab
            }
            reader.Close();

            // Update the UI controls on the main thread
            BeginInvoke(new Action(() => {
                // Update UI controls here
            }));
        }


        private void CalculateTotalPrice()
        {
            if (double.TryParse(textBox1.Text, out double price) && double.TryParse(comboBox2.Text, out double numDays))
            {
                double totalPrice = price * numDays;
                textBox2.Text = totalPrice.ToString();


            }

            
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }
        private string selectedItem;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // selectedItem = comboBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();



                string query = "INSERT INTO cabBooking (Name,PickUpLocation,Destination,StartTime,EndTime,Status,SeatCapacity,NumPassenger,CitizenNum,VehicleType,VehicleNum,BookingOption,Price,TotalPrice,PaymentOption,brand,model,driverNum) VALUES (@Name,@PickUpLocation,@Destination,@StartTime,@EndTime,'Booked',@SeatCapacity,@NumPassenger,@CitizenNum,@VehicleType,@VehicleNum,@BookingOption,@Price,@TotalPrice,@PaymentOption,@brand,@model,@driveNum)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", Naam.Text);
                cmd.Parameters.AddWithValue("@PickUpLocation", Addresses.Text);
                cmd.Parameters.AddWithValue("@Destination", textBox3.Text);
                cmd.Parameters.AddWithValue("@StartTime", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@EndTime", dateTimePicker2.Text);
              //  cmd.Parameters.AddWithValue("@Status",);


                cmd.Parameters.AddWithValue("@SeatCapacity", textBox5.Text);
                cmd.Parameters.AddWithValue("@NumPassenger", NTraveller.Text);
                cmd.Parameters.AddWithValue("@CitizenNum", PhoneNum.Text);
                cmd.Parameters.AddWithValue("@VehicleType", textBox6.Text);
                cmd.Parameters.AddWithValue("@VehicleNum", textBox4.Text);
                cmd.Parameters.AddWithValue("@BookingOption", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Price", textBox1.Text);

                cmd.Parameters.AddWithValue("@TotalPrice", textBox2.Text);
                
                cmd.Parameters.AddWithValue("@PaymentOption", comboBox1.Text);
                cmd.Parameters.AddWithValue("@brand", textBox8.Text);
                cmd.Parameters.AddWithValue("model", textBox9.Text);
                cmd.Parameters.AddWithValue("driverNum", textBox7.Text);

              /*  string formattedDateTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters.AddWithValue("@StartTime", formattedDateTime);

                string formattedDateTime1 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters.AddWithValue("@EndTime", formattedDateTime1);
*/



                cmd.ExecuteNonQuery();
                MessageBox.Show("Booking sucess");

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




                con.Close();
            }

            catch (Exception ex)
            {
                
                MessageBox.Show("Error:" + ex.InnerException);
            }







            

        }

        private void cabbooking_Load(object sender, EventArgs e)
        {
            /*comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            comboBox2.Items.Add("daily");
            comboBox2.Items.Add("weekly");
            comboBox2.Items.Add("monthly");*/

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

        private void calculateDays()
        {
            DateTime checkInDate = dateTimePicker1.Value;
            DateTime checkOutDate = dateTimePicker2.Value;

            TimeSpan diff = checkOutDate - checkInDate;
            int numberOfDays = diff.Days;

            comboBox2.Text = numberOfDays.ToString();





            }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateDays();
            CalculateTotalPrice();
           /* if (double.TryParse(textBox1.Text, out double price) && price > 0)
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
            }*/

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
           

               
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string formattedDateTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //cmd.Parameters.AddWithValue("@StartTime", formattedDateTime);

           // dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm tt";
            calculateDays();
            CalculateTotalPrice();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string formattedDateTime = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //cmd.Parameters.AddWithValue("@EndTime", formattedDateTime);

           // dateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm tt";
            calculateDays();
            CalculateTotalPrice();
        }
    }
}
