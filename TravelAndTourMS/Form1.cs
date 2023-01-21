using System.Data.SqlClient;

namespace TravelAndTourMS
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ; ");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
           
            try
            {
                con.Open();
               
                if(textBox1.Text == textBox2.Text )
                {
                    MessageBox.Show("Password Matched");

                    string query = "INSERT INTO Login  (username,passwords) VALUES ('" + textBox4.Text + "','" + textBox1.Text + "') ";
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

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 employeeform = new Form2();
            employeeform.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

       
    }
