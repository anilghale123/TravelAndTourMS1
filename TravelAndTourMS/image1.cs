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
    public partial class image1 : Form
    {
        public image1()
        {
            InitializeComponent();
        }

        private void image1_Load(object sender, EventArgs e)
        {
            image1_Load(sender, e, dataGridView1);
        }

        private void image1_Load(object sender, EventArgs e, DataGridView dataGridView1)
        {
             SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; Integrated Security = True ; ");
             SqlCommand cmd = new SqlCommand("SELECT id, package_name, price, Photo FROM Table1", con);
             SqlDataAdapter sd = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sd.Fill(dt);

            // dt.Columns.Add("image", Type.GetType("System.Bytes[]"));
          //  dt.Columns.Add("image", typeof(byte[]));
          //  dt.Columns["bookNow"].SetOrdinal(dt.Columns.Count - 1);
           

            // dt.Columns.Add("image", typeof(System.Byte[]));
            foreach (DataRow drow in dt.Rows)
            {
                // drow["image"] = File.ReadAllBytes(drow["image_path"].ToString());
                // drow["image"] = drow["Photo"];

               // drow["bookNow"] = "Book Now";

            }


            dataGridView1.DataSource = dt;
            //  dataGridView1.Columns.Remove("image_path");
           // dataGridView1.DefaultCellStyle.ForeColor = Color.Gray;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         /*   dataGridView1.BackgroundColor = Color.SkyBlue;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;  */
      }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // dataGridView1.DefaultCellStyle.ForeColor = Color.Gray;
            //dataGridView1.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string price = dataGridView1.Rows[selectedRowIndex].Cells["price"].Value.ToString();
                string package_name = dataGridView1.Rows[selectedRowIndex].Cells["package_name"].Value.ToString();


                this.Hide();
                tourbooking employeeform = new tourbooking(price,package_name);
                employeeform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           // e.CellStyle.BackColor = Color.Transparent;
            e.CellStyle.ForeColor = Color.Black;
            e.CellStyle.Font = new Font("Arial", 16, FontStyle.Bold);
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
           /* e.PaintParts &= ~DataGridViewPaintParts.SelectionBackground;
            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                using (Brush brush = new SolidBrush(Color.Orange))
                {
                    e.Graphics.FillRectangle(brush, e.RowBounds);
                }
            } */
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.BackColor = Color.Black;
                column.HeaderCell.Style.ForeColor = Color.White;
                column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            }
        }

        private void iconButton10_MouseEnter(object sender, EventArgs e)
        {
            iconButton10.BackColor = Color.Orange;

        }

        private void iconButton10_MouseLeave(object sender, EventArgs e)
        {
            iconButton10.BackColor = Color.Transparent;
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.BackColor = Color.Orange;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.BackColor = Color.Transparent;
        }


        private void iconButton7_MouseEnter(object sender, EventArgs e)
        {
            iconButton7.BackColor = Color.Orange;
        }

        private void iconButton7_MouseLeave(object sender, EventArgs e)
        {
            iconButton7.BackColor = Color.Transparent;
        }

        private void iconButton8_MouseEnter(object sender, EventArgs e)
        {
            iconButton8.BackColor = Color.Orange;

        }

        private void iconButton8_MouseLeave(object sender, EventArgs e)
        {
            iconButton8.BackColor = Color.Transparent;
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            home employeeform = new home();
            employeeform.ShowDialog();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            place employeeform = new place();
            employeeform.ShowDialog();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            aboutus employeeform = new aboutus();
            employeeform.ShowDialog();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.Transparent);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          /* if (e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
            else
            {
                e.CellStyle.BackColor = Color.Transparent;
            } */
        }
    }
}
