using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Windows.Forms.Integration;
using PieChart;




namespace TravelAndTourMS
{
    public partial class piechart : Form
    {
        public piechart()
        {
            InitializeComponent();
           

            // Create a new PieChart control and add it to the form
            var chart = new LiveCharts.WinForms.PieChart();
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);

            Panel panel = new Panel();
            panel.Controls.Add(chart);
            panel.Location = new Point(300, 100); // set the location of the panel
            panel.Size = new Size(300, 300); // set the size of the panel
            this.Controls.Add(panel);

            // Set the data for the chart
            chart.Series.Add(new PieSeries
            {
                Title = "Upasana Expense ",
                Values = new ChartValues<double> { 10 },
                DataLabels = true
            });
            chart.Series.Add(new PieSeries
            {
                Title = "Sova Expense",
                Values = new ChartValues<double> { 20 },
                DataLabels = true
            });
            chart.Series.Add(new PieSeries
            {
                Title = "Rinjha Expense",
                Values = new ChartValues<double> { 30 },
                DataLabels = true
            });
            chart.Series.Add(new PieSeries
            {
                Title = "Srijana Expense",
                Values = new ChartValues<double> { 15 },
                DataLabels = true
            });
        }
       

        
            private void piechart_Load(object sender, EventArgs e)
        {

        }

        private void piechart_Load_1(object sender, EventArgs e)
        {

        }

        private void pieChart2_ChildChanged(object sender, ChildChangedEventArgs e)
        {

        }
    }
}
