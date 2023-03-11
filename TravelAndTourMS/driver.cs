using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAndTourMS
{
    public partial class driver : Form
    {
        


        private string o;
        private string p;
        private string c;

        private string d;
        private string ee;
        private string f;

        private string g;

        private string h;
        private string i;
        private string j;


        private Image x1;
        private Image x2;
        private Image x3;
        private Image x4;
        private Image x5;
        private Image x6;

        private string k;
        private string l;
        private string m;

        private string n;


        public driver(string v, string v1, string v2, string v3, string v4, Image i1, Image i2, Image i3, string v5, string v6, Image i4, string v7, string v8, string v9, Image i5,Image i6)
        {
            InitializeComponent();

            o = v;
            p = v1;
            c = v2;
            d = v3;
            ee = v4;
            f = v5;
            g = v6;
            h = v7;
            i = v8;
            j = v9;


             x1 = i1;
             x2 = i2;
            x3 = i3;
            x4 = i4;
             x5 = i5;
            x6 = i6;

            richTextBox1.Text = g;
            pictureBox1.Image = x4;
            
          //  pictureBox1.visible = true;


        }

        private void driver_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            yatri employeeform = new yatri(o  , p , c , d , ee , x1 , x2 , x3 , f , g , x4 , h , i , j , x5,x6 );
            employeeform.ShowDialog();

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
        
            
            this.Hide();
            cabbooking employeeform = new cabbooking(o);
            employeeform.ShowDialog();
        
        }
    }
}
