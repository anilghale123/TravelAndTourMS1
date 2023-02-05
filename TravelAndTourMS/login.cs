using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Windows.Media;
//using System.Windows;
using Timer = System.Windows.Forms.Timer;

using MaterialDesignThemes.Wpf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Color = System.Drawing.Color;
using FontAwesome.Sharp;

namespace TravelAndTourMS
{
    public partial class login : Form
    {
        System.Windows.Forms.Timer timer;
        int index1;
        int index2;
        string[] messages = { "TOUR MANAGEMENT SYSTEM" };

        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
        public login()
        {

            InitializeComponent();
         //  label1.BringToFront();

           // label4.Location = new Point(40, 10);
          //  label4.ForeColor = System.Drawing.Color.Black;
          //  index1 = 0;
           // index2 = 0;

            
           // timer = new Timer();
           // timer.Interval = 80; // animation interval in milliseconds
           // timer.Tick += Timer_Tick;
           // timer.Start();


        }

       /* private void Timer_Tick(object sender, EventArgs e)
        {
            string message = messages[index1];
            if (index2 < message.Length)
            {
                label4.Text = message.Substring(0, index2 + 1);
                index2++;
            }
            else
            {
                index1 = (index1 + 1) % messages.Length;
                index2 = 0;
            }
        }
       */
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            register employeeform = new register();
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
                    home employeeform = new home();
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
            panel1.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var popupForm = new register();
            popupForm.StartPosition = FormStartPosition.CenterScreen;
            popupForm.ShowDialog();

            //register employeeform = new register();
           // employeeform.ShowDialog();

        }

        private void rjButton2_Click(object sender, EventArgs e)
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
                    home employeeform = new home();
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

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            index employeeform = new index();
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
