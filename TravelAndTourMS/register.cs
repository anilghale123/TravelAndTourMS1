using System.Data.SqlClient;

namespace TravelAndTourMS
{
    public partial class register : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
        public register()
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
            login employeeform = new login();
            employeeform.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void register_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100,0,0,0);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login employeeform = new login();
            employeeform.ShowDialog();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (textBox1.Text == textBox2.Text)
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

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login employeeform = new login();
            employeeform.ShowDialog();
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.Orange;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.BackColor = Color.Transparent;
        }
    }

       
    }
