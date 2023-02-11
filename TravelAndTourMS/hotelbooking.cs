using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class hotelbooking : Form
    {
        private Image im;
        public hotelbooking( string a, string b, string c, string d,Image w)
     {
            InitializeComponent();
            textBox1.Text = d;
            textBox3.Text = c;
            im = w;
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
            MessageBox.Show("booking successful");

            switch (selectedItem)
            {
                case "esewa":
                    esewa1 form1 = new esewa1(Naam.Text, Addresses.Text, NTraveller.Text, PhoneNum.Text,  textBox4.Text,  textBox3.Text,dateTimePicker1.Text,dateTimePicker2.Text  ,textBox5.Text, textBox1.Text, textBox2.Text,comboBox1.Text, im);
                    form1.Show();
                    break;

                case "qr":
                    qr form2 = new qr();
                    form2.Show();
                    break;
                    // Add more cases as needed
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
    }
}
