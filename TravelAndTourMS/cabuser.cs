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

namespace TravelAndTourMS
{
    public partial class cabuser : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS01; Initial Catalog = TravelandTour;  user id = sa;password = anil123");
        SqlCommand cmd;
        public cabuser()
        {
            InitializeComponent();
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

            dataGridView1.Columns["cab2"].Visible = false;
            dataGridView1.Columns["cab3"].Visible = false;
            dataGridView1.Columns["feature"].Visible = false;
        //    dataGridView1.Columns["description"].Visible = false;
            dataGridView1.Columns["driverinfo"].Visible = false;
            dataGridView1.Columns["driver"].Visible = false;
            dataGridView1.Columns["offerinfo"].Visible = false;
            dataGridView1.Columns["offerprice"].Visible = false;
            dataGridView1.Columns["offer"].Visible = false;



        }


        private void cabuser_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
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



                Image image,image1,image2,image3,image4;


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



                this.Hide();
                    yatri employeeform = new yatri (type, brand,model,seatnum,number,image,image1,image2,feature,driverinfo,image3,price,offerinfo,offerprice,image4);
                    employeeform.ShowDialog();
                
            }

            }
    }
}
