﻿using System;
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
    public partial class marriot : Form
    {
        private string a;
        private string b;
        private string c;
        private string d;
        private string ee;
        private string f;
        private string g;
        private string h;
        private string ii;
        private string j;
        private string k;
        private string l;
        private string m;


        private Image n;
        private Image o;
        private Image p;
        private Image q;
        private Image r;
        private Image s;
        private Image t;
        private Image u;
        private Image w;

        public marriot(string v, string v1,string v2,string v3, string v4,string v5,string v6,string v7,string v8,string v9,string v10, string v11, string v12,Image i,Image i1,Image i2, Image i3, Image i4, Image i5, Image i6, Image i7, Image i8)
        {
            InitializeComponent();
           
            pictureBox1.Image = i;
            pictureBox2.Image = i1;
            pictureBox3.Image = i2;
            pictureBox4.Image = i3;
            pictureBox5.Image = i5;
            pictureBox6.Image = i4;
            pictureBox7.Image = i6;
            pictureBox8.Image = i7;



            // label4.Text = value3;
            richTextBox1.Text = v2;
            richTextBox2.Text = v3;
            label1.Text = v4;

            label7.Text = v5;
            label6.Text = v6;
            label5.Text = v7;
            label4.Text = v8;
           label8.Text = v9;
            label11.Text = v10;
            label13.Text = v11;
            label15.Text = v12;

            a = v;
            b = v1;
            c = v2;
            d = v3;
            ee = v4;
            f = v5;
            g = v6;
            h = v7;
            ii = v8;
            j = v9;
            k = v10;
            l = v11;
            m = v12;

            n = i;
            o = i1;
            p = i2;
            q = i3;
            r = i4;
            s = i5;
            t = i6;
            u = i7;
            w = i8;
   }

        public void rjButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking employeeform = new hotelbooking (b,ee,f,j);
            employeeform.ShowDialog();
        }

        private void marriot_Load(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking employeeform = new hotelbooking(b,ee,g,k);
            employeeform.ShowDialog();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking employeeform = new hotelbooking(b,ee,h,l);
            employeeform.ShowDialog();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotelbooking employeeform = new hotelbooking(b,ee,ii,m);
            employeeform.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void iconButton4_MouseEnter(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Orange;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.BackColor = Color.Transparent;
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Orange;
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            iconButton2.BackColor = Color.Transparent;
        }
    }
}
