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
using FontAwesome.Sharp;

namespace TravelAndTourMS
{
    public partial class admin : Form
    {

        private Dictionary<Control, Size> originalSizes;
        private Dictionary<Control, Point> originalLocations;
        private Size originalFormSize;

        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
        public admin()
        {
            InitializeComponent();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = " select count(*) from adminlogin where username='" + textBox4.Text + "' and password='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Login  Successfully");
                    this.Hide();
                    image employeeform = new image();
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

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminregister employeeform = new adminregister();
            employeeform.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void admin_Load(object sender, EventArgs e)
        {
            // Store the original size and location of the controls
            originalSizes = new Dictionary<Control, Size>();
            originalLocations = new Dictionary<Control, Point>();
            foreach (Control control in this.Controls)
            {
                originalSizes[control] = control.Size;
                originalLocations[control] = control.Location;
            }

            // Store the original size of the form
            originalFormSize = this.ClientSize;
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void admin_Resize(object sender, EventArgs e)
        {
            // Calculate the scale factor
            float scaleX = (float)this.ClientSize.Width / (float)originalFormSize.Width;
            float scaleY = (float)this.ClientSize.Height / (float)originalFormSize.Height;

            // Resize and reposition the controls
            foreach (Control control in this.Controls)
            {
                control.Size = new Size((int)(originalSizes[control].Width * scaleX), (int)(originalSizes[control].Height * scaleY));
                control.Location = new Point((int)(originalLocations[control].X * scaleX), (int)(originalLocations[control].Y * scaleY));
            }
        }
    }
}
