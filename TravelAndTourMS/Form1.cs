using System.Data.SqlClient;

namespace TravelAndTourMS
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog= bit3rdsem ; user id = sa;password = kist@123 ; ");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 employeeform = new Form2();
            employeeform.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = " select *from Login where username = '" + textBox4.Text + "' AND password = '" + textBox4.Text + "';";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Login Successfully Successfully");
                con.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.InnerException);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 employeeform = new Form2();
            employeeform.ShowDialog();
        }
    }

       
    }
