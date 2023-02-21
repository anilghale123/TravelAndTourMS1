using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver.Core.Misc;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;


namespace TravelAndTourMS
{
    public partial class cabuser : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");
        SqlCommand cmd;
        public cabuser()
        {
            InitializeComponent();
          //  dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font.FontFamily, 14, FontStyle.Bold);

            



            dataGridView1.DefaultCellStyle.Font = new Font(dataGridView1.Font.FontFamily,11, FontStyle.Regular);
          //  dataGridView1.DefaultCellStyle.Size = new Size(dataGridView1.Font.Size + 2, dataGridView1.Font.Size + 2);


        }

        private void load_data()
        {
            cmd = new SqlCommand("Select * from cab order by id desc", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = dt;
            //  DataGridViewImageColumn Pic1 = new DataGridViewImageColumn();
            //  Pic1 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            // Pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.Columns["cab1"].Visible = false;
            dataGridView1.Columns["cab2"].Visible = false;
            dataGridView1.Columns["cab3"].Visible = false;
            dataGridView1.Columns["feature"].Visible = false;
        //    dataGridView1.Columns["description"].Visible = false;
            dataGridView1.Columns["driverinfo"].Visible = false;
            dataGridView1.Columns["driver"].Visible = false;
            dataGridView1.Columns["offerinfo"].Visible = false;
            dataGridView1.Columns["offerprice"].Visible = false;
            dataGridView1.Columns["offer"].Visible = false;

          //  dataGridView1.Columns["seatnum"].Visible = false;
            dataGridView1.Columns["number"].Visible = false;
            dataGridView1.Columns["price"].Visible = false;

            dataGridView1.Columns["qr"].Visible = false;
            dataGridView1.Columns["brand"].Visible = false;


            //  dataGridView1.Columns["cab2"].Visible = false;



        }


        private void cabuser_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridView1.Columns["type"].Index)
                {

                    int selectedRowIndex = e.RowIndex;
                    string type = dataGridView1.Rows[selectedRowIndex].Cells["type"].Value.ToString();
                    string brand = dataGridView1.Rows[selectedRowIndex].Cells["brand"].Value.ToString();
                    string model = dataGridView1.Rows[selectedRowIndex].Cells["model"].Value.ToString();
                    string seatnum = dataGridView1.Rows[selectedRowIndex].Cells["seatnum"].Value.ToString();
                    string number = dataGridView1.Rows[selectedRowIndex].Cells["number"].Value.ToString();
                    string feature = dataGridView1.Rows[selectedRowIndex].Cells["feature"].Value.ToString();
                    string driverinfo = dataGridView1.Rows[selectedRowIndex].Cells["driverinfo"].Value.ToString();
                    string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
                    string offerinfo = dataGridView1.Rows[selectedRowIndex].Cells["offerinfo"].Value.ToString();
                    string offerprice = dataGridView1.Rows[selectedRowIndex].Cells["offerprice"].Value.ToString();


                    byte[] byteArray = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["cab1"].Value;
                    byte[] byteArray1 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["cab2"].Value;
                    byte[] byteArray2 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["cab3"].Value;

                    byte[] byteArray3 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["driver"].Value;
                    byte[] byteArray4 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["offer"].Value;

                    byte[] byteArray5 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["qr"].Value;




                    Image image, image1, image2, image3, image4, image5;


                    using (var ms = new MemoryStream(byteArray))
                    {
                        image = Image.FromStream(ms);
                    }


                    using (var ms1 = new MemoryStream(byteArray1))
                    {
                        image1 = Image.FromStream(ms1);
                    }

                    using (var ms = new MemoryStream(byteArray))
                    {
                        image = Image.FromStream(ms);
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



                    this.Hide();
                    yatri employeeform = new yatri(type, brand, model, seatnum, number, image, image1, image2, feature, driverinfo, image3, price, offerinfo, offerprice, image4, image5);
                    employeeform.ShowDialog();

                }
            }

            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "select * from cab where type=@type ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@type", place.Text);



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

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                //string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
               // string package_name = dataGridView1.Rows[selectedRowIndex].Cells["package_name"].Value.ToString();




                
                string type = dataGridView1.Rows[selectedRowIndex].Cells["type"].Value.ToString();
                string brand = dataGridView1.Rows[selectedRowIndex].Cells["brand"].Value.ToString();
                string model = dataGridView1.Rows[selectedRowIndex].Cells["model"].Value.ToString();
                string seatnum = dataGridView1.Rows[selectedRowIndex].Cells["seatnum"].Value.ToString();
                string number = dataGridView1.Rows[selectedRowIndex].Cells["number"].Value.ToString();
                string feature = dataGridView1.Rows[selectedRowIndex].Cells["feature"].Value.ToString();
                string driverinfo = dataGridView1.Rows[selectedRowIndex].Cells["driverinfo"].Value.ToString();
                string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
                string offerinfo = dataGridView1.Rows[selectedRowIndex].Cells["offerinfo"].Value.ToString();
                string offerprice = dataGridView1.Rows[selectedRowIndex].Cells["offerprice"].Value.ToString();


                byte[] byteArray = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["cab1"].Value;
                byte[] byteArray1 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["cab2"].Value;
                byte[] byteArray2 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["cab3"].Value;

                byte[] byteArray3 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["driver"].Value;
                byte[] byteArray4 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["offer"].Value;

                byte[] byteArray5 = (byte[])dataGridView1.Rows[selectedRowIndex].Cells["qr"].Value;




                Image image, image1, image2, image3, image4, image5;


                using (var ms = new MemoryStream(byteArray))
                {
                    image = Image.FromStream(ms);
                }


                using (var ms1 = new MemoryStream(byteArray1))
                {
                    image1 = Image.FromStream(ms1);
                }

                using (var ms = new MemoryStream(byteArray))
                {
                    image = Image.FromStream(ms);
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



                this.Hide();
                cabbooking employeeform = new cabbooking(type, brand, model, seatnum, number, image, image1, image2, feature, driverinfo, image3, price, offerinfo, offerprice, image4, image5);
                employeeform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null && e.Value.ToString() == "Booked")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
            }
         //   e.CellStyle.BackColor = Color.BurlyWood;
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            home form = new home();
            form.ShowDialog();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            image1 form = new image1();
            form.ShowDialog();


        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            place form = new place();
            form.ShowDialog();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            aboutus form = new aboutus();
            form.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelsearch form = new hotelsearch();
            form.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cabuser form = new cabuser();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
