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
    public partial class hotelbooking : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
        private Image im;
        string id;
        public hotelbooking( string a, string b, string c, string d,string id)
     {
            InitializeComponent();
            textBox3.Text = a;
            textBox6.Text = b;
            textBox7.Text = c;
            textBox1.Text = d;
            this.id = id;
         //   im = w;
        }

        private void CalculateTotalPrice()
        {
            if (double.TryParse(textBox1.Text, out double price) && double.TryParse(textBox4.Text, out double numRoom) && double.TryParse(textBox5.Text, out double numDays))
            {
                textBox2.Text = (price * numRoom * numDays ).ToString();
            }
        }

        private void hotelbooking_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private string selectedItem;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = comboBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();



                string query = "INSERT INTO hotelBooking (Name,NumGuest,NumRoom,Address,PhoneNum,Place,CheckInDate,CheckOutDate,NumOfDays,Price,TotalPrice,PaymentOption) VALUES (@Name,@NumGuest,@NumRoom,@Address,@PhoneNum,@Place,@CheckInDate,@CheckOutDate,@NumOfDays,@Price,@TotalPrice,@PaymentOption )";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", Naam.Text);
                cmd.Parameters.AddWithValue("@NumGuest", NTraveller.Text);
                cmd.Parameters.AddWithValue("@NumRoom", textBox4.Text);
                cmd.Parameters.AddWithValue("@Address", Addresses.Text);
                cmd.Parameters.AddWithValue("@PhoneNum", PhoneNum.Text);
                cmd.Parameters.AddWithValue("@Place", textBox3.Text);
                string formattedStartTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters.AddWithValue("@CheckInDate", formattedStartTime);

                string formattedEndTime = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters.AddWithValue("@CheckOutDate", formattedEndTime);
                cmd.Parameters.AddWithValue("@NumOfDays", textBox5.Text);
                cmd.Parameters.AddWithValue("@Price", textBox1.Text);
                cmd.Parameters.AddWithValue("@TotalPrice", textBox2.Text);
                cmd.Parameters.AddWithValue("@PaymentOption", comboBox1.Text);



                cmd.ExecuteNonQuery();


                //MessageBox.Show("Booking Successfull");

                con.Close();
                switch (selectedItem)
                {
                    case "esewa":
                        esewa1 form1 = new esewa1(Naam.Text, Addresses.Text, NTraveller.Text, PhoneNum.Text, textBox4.Text, textBox3.Text, dateTimePicker1.Text, dateTimePicker2.Text, textBox5.Text, textBox1.Text, textBox2.Text, comboBox1.Text, id);
                        form1.Show();
                        break;

                        /*case "cash":
                            qr form2 = new qr();
                            form2.Show();
                            break;*/
                        // Add more cases as needed
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message + "\n\n" + ex.StackTrace);
            }







        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            calculateDays();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            calculateDays();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            calculateDays();
            CalculateTotalPrice();
        }

        private void calculateDays()
        {
            DateTime checkInDate = dateTimePicker1.Value;
            DateTime checkOutDate = dateTimePicker2.Value;

            TimeSpan diff = checkOutDate - checkInDate;
            int numberOfDays = diff.Days;

            textBox5.Text = numberOfDays.ToString();
        }

        private void NTraveller_TextChanged(object sender, EventArgs e)
        {
            int numOfPassengers;
            int seatCapacity;

            // Check if the user has entered valid integers for the number of passengers and seat capacity
            if (int.TryParse(NTraveller.Text, out numOfPassengers) && int.TryParse(textBox4.Text, out seatCapacity))
            {
                // Compare the number of passengers and seat capacity
                if (numOfPassengers > seatCapacity*5)
                {
                    // Display error message
                    MessageBox.Show("Please enter number of guest less than 6 for 1 room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
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

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            place employeeform = new place();
            employeeform.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            image1 employeeform = new image1();
            employeeform.ShowDialog();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            home employeeform = new home();
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

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Orange;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Transparent;
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Orange;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Transparent;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
