using System.Data.SqlClient;

namespace TravelAndTourMS
{
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ; ");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 employeeform = new Form1();
            employeeform.ShowDialog();

            /*    try
                {
                    con.Open();
                    string query = "INSERT INTO Login  (username,passwords) VALUES ('"+textBox4.Text+"','"+textBox1.Text+"') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Saved Successfully");

                    con.Close();
                }

                catch (Exception ex)
                {

                    MessageBox.Show("Error:" + ex.Message);
                }

     */
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = " select count(*) from Login where username='" + textBox4.Text + "' and passwords='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Login  Successfully");
                    this.Hide();
                    Form7 employeeform = new Form7();
                    employeeform.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Login  fAILED");
                }



                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.InnerException);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {



        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
