using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Win32;
//using ZstdSharp.Unsafe;

namespace TravelAndTourMS
{
    public partial class hotelsearch : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");

        public hotelsearch(SqlConnection con)
        {
            this.con = con;
        }

        SqlCommand cmd;
        public hotelsearch()
        {
            InitializeComponent();
             
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font.FontFamily, 14, FontStyle.Bold);





            dataGridView1.DefaultCellStyle.Font = new Font(dataGridView1.Font.FontFamily, 11, FontStyle.Regular);

            // dataGridView1.RowsDefaultCellStyle.BackColor = Color.Crimson;

        }

        private void load_data()
        {
            cmd = new SqlCommand("Select * from Hotel order by id desc", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("place", typeof(string));
            dt.Columns.Add("hotel", typeof(string));
            dt.Columns.Add("price", typeof(string));


           dt.Clear();
             da.Fill(dt);
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = dt;
            
            dataGridView1.Columns["description"].Visible = false;
            dataGridView1.Columns["amenities"].Visible = false;
            dataGridView1.Columns["picture2"].Visible = false;
            dataGridView1.Columns["picture3"].Visible = false;
            dataGridView1.Columns["picture4"].Visible = false;
            dataGridView1.Columns["room1name"].Visible = false;
            dataGridView1.Columns["room1price"].Visible = false;
            dataGridView1.Columns["room1"].Visible = false;

            dataGridView1.Columns["room2name"].Visible = false;
            dataGridView1.Columns["room2price"].Visible = false;
            dataGridView1.Columns["room2"].Visible = false;

            dataGridView1.Columns["room3name"].Visible = false;
            dataGridView1.Columns["room3price"].Visible = false;
            dataGridView1.Columns["room3"].Visible = false;

            dataGridView1.Columns["room4name"].Visible = false;
            dataGridView1.Columns["room4price"].Visible = false;
            dataGridView1.Columns["room4"].Visible = false;
            dataGridView1.Columns["qr"].Visible = false;

            dataGridView1.Columns["picture1"].Visible = false;
            dataGridView1.Columns["price"].Visible = false;








            //  DataGridViewImageColumn Pic1 = new DataGridViewImageColumn();
            //  Pic1 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            // Pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }


        private void button5_Click(object sender, EventArgs e)
        {
           try
            {
                con.Open();
               string query = "select * from Hotel where place=@place ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@place", place.Text);
               
                   
                    
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                   dataGridView1.Visible = true;

               
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.InnerException);
            }  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            roomsearch employeeform = new roomsearch();
            employeeform.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void hotelsearch_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                if (e.RowIndex >= 0)
                {
                
                        int selectedRowIndex = e.RowIndex;
                       
                        string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
                        string place = dataGridView1.Rows[selectedRowIndex].Cells["place"].Value.ToString();
                        string description = dataGridView1.Rows[selectedRowIndex].Cells["description"].Value.ToString();
                        string amenities = dataGridView1.Rows[selectedRowIndex].Cells["amenities"].Value.ToString();
                        string hotel = dataGridView1.Rows[selectedRowIndex].Cells["hotel"].Value.ToString();
                
                string room1name = dataGridView1.Rows[selectedRowIndex].Cells["room1name"].Value.ToString();
                string room2name = dataGridView1.Rows[selectedRowIndex].Cells["room2name"].Value.ToString();
                string room3name = dataGridView1.Rows[selectedRowIndex].Cells["room3name"].Value.ToString();
                string room4name = dataGridView1.Rows[selectedRowIndex].Cells["room4name"].Value.ToString();

                string room1price = dataGridView1.Rows[selectedRowIndex].Cells["room1price"].Value.ToString();
                string room2price = dataGridView1.Rows[selectedRowIndex].Cells["room2price"].Value.ToString();
                string room3price = dataGridView1.Rows[selectedRowIndex].Cells["room3price"].Value.ToString();
                string room4price = dataGridView1.Rows[selectedRowIndex].Cells["room4price"].Value.ToString();

                    byte[] byteArray = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["picture1"].Value;
                    byte[] byteArray1 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["picture2"].Value;
                byte[] byteArray2 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["picture3"].Value;
                byte[] byteArray3 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["picture4"].Value;

                byte[] byteArray4 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["room1"].Value;
                byte[] byteArray5 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["room2"].Value;
                byte[] byteArray6 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["room3"].Value;
                byte[] byteArray7 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["room4"].Value;

                byte[] byteArray8 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["qr"].Value;




                Image image,image1, image2, image3, image4, image5, image6, image7,image8;
                    using (var ms = new MemoryStream(byteArray))
                    {
                        image = Image.FromStream(ms);
                    }
                    using (var ms1 = new MemoryStream(byteArray1))
                    {
                        image1 = Image.FromStream(ms1);
                    }

                using (var ms2 = new MemoryStream(byteArray2))
                {
                    image2 = Image.FromStream(ms2);
                }

                using (var ms3 = new MemoryStream(byteArray3))
                {
                    image3 = Image.FromStream(ms3);
                }

                using (var ms4 = new MemoryStream(byteArray4))
                {
                    image4 = Image.FromStream(ms4);
                }
                using (var ms5 = new MemoryStream(byteArray5))
                {
                    image5 = Image.FromStream(ms5);
                }
                using (var ms6 = new MemoryStream(byteArray6))
                {
                    image6 = Image.FromStream(ms6);
                }
                using (var ms7 = new MemoryStream(byteArray7))
                {
                    image7 = Image.FromStream(ms7);
                }

                using (var ms8 = new MemoryStream(byteArray8))
                {
                    image8 = Image.FromStream(ms8);
                }





                this.Hide();
   marriot employeeform = new marriot(price, place,description,amenities,hotel,room1name,room2name,room3name,room4name,room1price,room2price,room3price,room4price, image,image1,image2,image3,image4,image5,image6,image7,image8);
                        employeeform.ShowDialog();
                    }

                  /*  else if(selectedHotel == "Yeti" || selectedHotel == "yeti")
                          {
                    int selectedRowIndex = e.RowIndex;
                    string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
                    string place = dataGridView1.Rows[selectedRowIndex].Cells["place"].Value.ToString();
                    string description = dataGridView1.Rows[selectedRowIndex].Cells["description"].Value.ToString();

                    byte[] byteArray = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["picture1"].Value;
                    Image image;
                    using (var ms = new MemoryStream(byteArray))
                    {
                        image = Image.FromStream(ms);
                    }


                    this.Hide();
                    marriot employeeform = new marriot(price, place,description,image);
                    employeeform.ShowDialog();

                }  */



                }

        private void dataGridView1_ColumnHeadersDefaultCellStyleChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


        }
    }
    }
