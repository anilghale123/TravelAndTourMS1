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
    public partial class adminregister : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
        public adminregister()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (textBox1.Text == textBox2.Text)
                {
                    MessageBox.Show("Password Matched");

                    string query = "INSERT INTO adminlogin  (username,password) VALUES ('" + textBox4.Text + "','" + textBox1.Text + "') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Password Not Matched : please check it once");

                }




                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.InnerException);
            }
        }
    }
}
