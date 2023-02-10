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
    public partial class cabbooking : Form
    {
        private Image x;
        public cabbooking(string a, string b, string c, string d,Image ee)
        {
            InitializeComponent();
            PhoneNum.Text = a;
            Naam.Text = b;
            textBox1.Text = c;
            x = ee;
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
            MessageBox.Show("booking successful");

            switch (selectedItem)
            {
                case "esewa":
                    esewa form1 = new esewa(Naam.Text, Addresses.Text, dateTimePicker1.Text, NTraveller.Text, textBox1.Text, textBox2.Text, textBox3.Text,x);
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

        }



    }
}
