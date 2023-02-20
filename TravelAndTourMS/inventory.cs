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
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed is the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // Retrieve the barcode data from the textbox
                string barcodeData = textBox1.Text;

                System.Diagnostics.Debug.WriteLine("Barcode data: " + barcodeData);
                textBox1.Text = barcodeData;

                // Pass the barcode data to your inventory management system
                // (replace this with your actual inventory management code)
                //  UpdateInventory(barcodeData);

                // Clear the textbox for the next scan
                textBox1.Clear();
            }
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            // Set focus to the textbox control
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }

}