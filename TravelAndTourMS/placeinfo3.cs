using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class placeinfo3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS01; Initial Catalog= TravelandTour ; user id = sa;password = anil123 ");
        SqlCommand cmd;
        public placeinfo3()
        {
            InitializeComponent();

        }




        private void hotel_Load(object sender, EventArgs e)
        {
            // ...

            // Create a ComboBox to select the place
            /*    ComboBox comboBox = new ComboBox();
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Items.Add("All Places");

                // Load the places from the database
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT place FROM Hotel", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["place"]);
                    }
                    con.Close();
                }

                comboBox.SelectedIndex = 0;
                comboBox.Location = new Point(10, 10);
                //panel.Controls.Add(comboBox);

                // Create a Button to filter the hotels
              //  Button button = new Button();
              //  button.Text = "Filter";
                button.Location = new Point(200, 10);
                panel.Controls.Add(button);

                // Handle the Click event of the button
                button.Click += (object sender, EventArgs e) =>
                {
                    string selectedPlace = comboBox.SelectedItem.ToString();
                    string query = "SELECT * FROM Hotel";
                    if (selectedPlace != "All Places")
                    {
                        query += " WHERE place = @place";
                    }

                    // create a DataTable and fill it with data from the database
                    DataTable dataTable = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (selectedPlace != "All Places")
                        {
                            cmd.Parameters.AddWithValue("@place", selectedPlace);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }

                    // ...

                    // loop through the rows of the DataTable
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        // ...

                    }
                };
            }
    private void pictureBox_Click(object sender, EventArgs e)
    {
        // cast the sender object to a PictureBox control
        PictureBox clickedPictureBox = sender as PictureBox;
        string id = clickedPictureBox.Name;

        // Create an instance of the form you want to open
        hotelroom form2 = new hotelroom(id);

        // Show the form
        form2.Show();

        // Hide the current form if needed
        this.Hide();
    }*/
        }
    }
}
        



