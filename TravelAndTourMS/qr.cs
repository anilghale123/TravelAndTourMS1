using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class qr : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;
        string id;

        public qr(string a, string b, string c, string d, string e, string f, string g, string id)
        {
            InitializeComponent();
            Image qr = null;
            this.id = id;
            // pictureBox1.Image = x;



            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT  qr FROM Table1 WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    // Convert the byte array to an Image object
                    byte[] photo2Bytes = (byte[])reader.GetValue(0);
                    using (MemoryStream ms = new MemoryStream(photo2Bytes))
                    {
                        qr = Image.FromStream(ms);
                    }


                }

                reader.Close();
            }
            pictureBox1.Image = qr;
        }
        

        private void qr_Load(object sender, EventArgs e)
        {

        }
    }
}
