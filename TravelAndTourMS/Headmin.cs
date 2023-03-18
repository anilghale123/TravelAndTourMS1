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
using System.Xml.Linq;

namespace TravelAndTourMS
{
    public partial class Headmin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True; ");
        SqlCommand cmd;
        public Headmin()
        {
            InitializeComponent();
        }
        private void load_data()
        {
            cmd = new SqlCommand("Select * from adminlogin ", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = dt;

        }

        private void Headmin_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            image form = new image();
            form.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hoteladmin form = new hoteladmin();
            form.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            cab form = new cab();
            form.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            User form = new User();
            form.ShowDialog();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Headmin form = new Headmin();
            form.ShowDialog();
        }
    }
}
